using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

using Microsoft.Data.Sqlite;

using Threading;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace MovieBrowser;

public class ThumbnailJob : Job
{
	protected override JobCompletionStatus Execute()
	{
		var data = (VideoData)this.State;
		var fullFilename = Path.Combine(data.rootPath, data.uploader, data.filename);
		var buffer = BuildThumbnail(fullFilename, 5);

		var insertCommand = data.connection.CreateCommand();
		insertCommand.CommandText = "insert into thumbnail(id, filename, image, title, size, width, height, duration, uploader, downloaddate) values ($id, $filename, $image, $title, $size, $width, $height, $duration, $uploader, $downloaddate);";
		insertCommand.Parameters.AddWithValue("$id", data.id);
		insertCommand.Parameters.AddWithValue("$filename", data.filename);
		insertCommand.Parameters.AddWithValue("$image", buffer);
		insertCommand.Parameters.AddWithValue("$title", data.title);
		insertCommand.Parameters.AddWithValue("$size", data.size);
		insertCommand.Parameters.AddWithValue("$width", data.width);
		insertCommand.Parameters.AddWithValue("$height", data.height);
		insertCommand.Parameters.AddWithValue("$duration", data.duration);
		insertCommand.Parameters.AddWithValue("$uploader", data.uploader);
		insertCommand.Parameters.AddWithValue("$downloaddate", data.downloaddate);
		insertCommand.ExecuteNonQuery();
		return JobCompletionStatus.Success;
	}

	private byte[] BuildThumbnail(string filename, int offset)
	{
		MemoryStream ms = new MemoryStream();
		var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
		ffMpeg.GetVideoThumbnail(filename, ms, offset);
		ms.Seek(0, SeekOrigin.Begin);
		var buf = new byte[ms.Length];
		ms.Read(buf, 0, buf.Length);
		ms.Close();
		return buf;
	}
}


public class VideoData {
	public int id { get; set; }
	public string uploader { get; set; }
	public string filename { get; set; }
	public string title { get; set; }
	public long size { get; set; }
	public int width { get; set; }
	public int height { get; set; }
	public int duration { get; set; }
	public float downloaddate { get; set; }
	public SqliteConnection connection {get;set;}
	public string rootPath { get; set; }
}

public partial class MainForm : Form
{
    

    public MainForm()
    {
        InitializeComponent();

    }

	private void buttonOpenMetadata_Click(object sender, EventArgs e)
	{
        openFileDialog.FileName = textMetadataFilename.Text;
        if (openFileDialog.ShowDialog() == DialogResult.OK )
        {
            textMetadataFilename.Text = openFileDialog.FileName;
        }
        
	}

	private void buttonOpenThumbnail_Click(object sender, EventArgs e)
	{
		openFileDialog.FileName = textThumbnailFilename.Text;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textThumbnailFilename.Text = openFileDialog.FileName;
		}
	}

	

	private void buttonRebuild_Click(object sender, EventArgs e)
	{
		using (var writerConnection = new SqliteConnection($"Data Source={textThumbnailFilename.Text}"))
		{
			writerConnection.Open();

			var insertCommand = writerConnection.CreateCommand();
			insertCommand.CommandText = "insert into thumbnail(id, filename, image, title, size, width, height, duration, uploader, downloaddate) values ($id, $filename, $image, $title, $size, $width, $height, $duration, $uploader, $downloaddate);";
			insertCommand.Parameters.Add("$id", SqliteType.Integer);
			insertCommand.Parameters.Add("$filename", SqliteType.Text);
			insertCommand.Parameters.Add("$image", SqliteType.Blob);
			insertCommand.Parameters.Add("$title", SqliteType.Text);
			insertCommand.Parameters.Add("$size", SqliteType.Integer);
			insertCommand.Parameters.Add("$width", SqliteType.Integer);
			insertCommand.Parameters.Add("$height", SqliteType.Integer);
			insertCommand.Parameters.Add("$duration", SqliteType.Integer);
			insertCommand.Parameters.Add("$uploader", SqliteType.Text);
			insertCommand.Parameters.Add("$downloaddate", SqliteType.Real);

			var existsCommand = writerConnection.CreateCommand();
			existsCommand.CommandText = "select count(*) from thumbnail where id = $id;";
			existsCommand.Parameters.Add("$id", SqliteType.Integer);

			var videos = new List<VideoData>();

			using (var readerConnection = new SqliteConnection($"Data Source={textMetadataFilename.Text}"))
			{
				readerConnection.Open();

				var command = readerConnection.CreateCommand();

				command.CommandText = "select count(*) from video_catalog where complete = 1";
				var numberOfRecords = command.ExecuteScalar();
				var currentCount = 0;
				command.CommandText = "select id, uploader, filename, title, size, width, height, duration, downloaddate from video_catalog where complete = 1";

				var queue = new MemoryJobQueue();
				var pool = new Threading.ThreadPool(queue, 10, "video");

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Application.DoEvents();

						currentCount++;
						var id = reader.GetInt32(0);
						var uploader = reader.GetString(1);
						uploader = uploader.Replace(' ', '_');
						var filename = reader.GetString(2);
						var title = reader.GetString(3);
						var size = reader.GetInt64(4);
						var width = reader.GetInt32(5);
						var height = reader.GetInt32(6);
						var duration = reader.GetInt32(7);
						var downloaddate = reader.GetFloat(8);


						existsCommand.Parameters["$id"].Value = id;
						if (((long)existsCommand.ExecuteScalar()) == 1)
						{
							labelStatus.Text = $"Skipping - {currentCount} of {numberOfRecords}";
						}
						else
						{							
							var fullFilename = Path.Combine(textFileRoot.Text, uploader, filename);
							if (!File.Exists(fullFilename))
							{
								labelStatus.Text = $"Skipping - {currentCount} of {numberOfRecords}";
							}
							else
							{
								var video = new VideoData
								{
									id = id,
									uploader = uploader,
									filename = filename,
									title = title,
									size = size,
									width = width,
									height = height,
									duration = duration,
									downloaddate = downloaddate,
									connection = writerConnection,
									rootPath=textFileRoot.Text
								};

								queue.QueueJob(new ThumbnailJob() { State = video });
								labelStatus.Text = $"Queuing - {currentCount} of {numberOfRecords}";
							}
						}
					}
				}									

				while (pool.Busy)
				{
					labelStatus.Text = $"Rebuilding - {pool.WaitingJobs} jobs remaining";
					Thread.Sleep(100);
					Application.DoEvents();
				}
			}
		}
	}

	

	//private void BuildThumbnailProcess()
	//{
	//	var buffer = BuildThumbnail(fullFilename, 5);

	//	insertCommand.Parameters["$id"].Value = id;
	//	insertCommand.Parameters["$filename"].Value = filename;
	//	insertCommand.Parameters["$title"].Value = title;
	//	insertCommand.Parameters["$size"].Value = size;
	//	insertCommand.Parameters["$width"].Value = width;
	//	insertCommand.Parameters["$height"].Value = height;
	//	insertCommand.Parameters["$duration"].Value = duration;
	//	insertCommand.Parameters["$uploader"].Value = uploader;
	//	insertCommand.Parameters["$downloaddate"].Value = downloaddate;
	//	insertCommand.Parameters["$image"].Value = buffer;

	//	var result = insertCommand.ExecuteNonQuery();
	//	if (result == 0)
	//	{
	//		MessageBox.Show("Error");
	//	}
	//	else
	//	{
	//		labelStatus.Text = $"Rebuilding - {currentCount} of {numberOfRecords}";
	//	}
	//}

	private void buttonFileRoot_Click(object sender, EventArgs e)
	{
		folderBrowserDialog.InitialDirectory = textFileRoot.Text;
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			textFileRoot.Text = folderBrowserDialog.SelectedPath;
		}
	}

	private void buttonSearch_Click(object sender, EventArgs e)
	{
		thumbnailViewerControl.Clear();
		using (var connection = new SqliteConnection($"Data Source={textThumbnailFilename.Text}"))
		{
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = $"select id, uploader, filename, title, size, width, height, duration, downloaddate, image from thumbnail {textQuery.Text}";

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					var id = reader.GetInt32(0);
					var filename = reader.GetString(2);
					var image = reader.GetStream(9);
					thumbnailViewerControl.MakeThumbnail(filename, image, id.ToString());
					image.Close();
				}
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		thumbnailViewerControl.Clear();
	}

	private void thumbnailViewerControl_OnOpen(object sender, string e)
	{
		using (var connection = new SqliteConnection($"Data Source={textThumbnailFilename.Text}"))
		{
			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText = $"select uploader, filename from thumbnail where id = $id";
			command.Parameters.AddWithValue("$id", int.Parse(e));
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{					
					var uploader = reader.GetString(0);
					var filename = reader.GetString(1);

					Process.Start(new ProcessStartInfo(Path.Combine(textFileRoot.Text, uploader, filename)) { UseShellExecute=true});					
				}
			}
		}

		
	}
}
