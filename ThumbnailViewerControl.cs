using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovieBrowser
{
	public partial class ThumbnailViewerControl : FlowLayoutPanel
	{
		public event EventHandler<string> OnOpen;
		public ThumbnailViewerControl()
		{
			InitializeComponent();
			this.AutoScroll = true;
			this.AllowDrop = true;
			this.DoubleBuffered = true;
		}
		
		public void MakeThumbnail(string text, Stream image, string key)
		{
			var hidden = new System.Windows.Forms.Label();
			hidden.Text = key;
			hidden.Name = "hidden";
			hidden.Hide();

			var label = new System.Windows.Forms.Label();
			label.Dock = DockStyle.Bottom;
			label.Width= 128;
			label.MaximumSize = new Size(128, 0);
			label.AutoSize = true;			
			label.ForeColor= Color.White;
			label.BackColor = Color.Black;
			label.Text = Path.GetFileName(text);
			

			PictureBox thumb = new PictureBox();
			thumb.MaximumSize = new Size(128, 128);
			thumb.MinimumSize = new Size(128, 128);
			thumb.Size = new Size(128, 128);
			thumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			thumb.SizeMode = PictureBoxSizeMode.Zoom;
			thumb.Left= 0;
			thumb.Top= 0;

			thumb.MouseEnter += new EventHandler(thumb_MouseEnter);
			thumb.MouseLeave += new EventHandler(thumb_MouseLeave);
			thumb.DoubleClick += new EventHandler(thumb_DoubleClick);

			thumb.Image = Image.FromStream(image).GetThumbnailImage(thumb.Width - 2, thumb.Height - 2, null, new IntPtr());

			thumb.Controls.Add(label);			
			thumb.Controls.Add(hidden);
			this.Controls.Add(thumb);
		}

		void thumb_DoubleClick(object sender, EventArgs e)
		{
			if (OnOpen != null)
			{
				var pb = (PictureBox)sender;
				var hidden = pb.Controls.Find("hidden", false);
				if (hidden != null)
				{
					OnOpen(this, ((System.Windows.Forms.Label)hidden[0]).Text);
				}
			}
		}

		void thumb_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Invalidate();
		}

		void thumb_MouseEnter(object sender, EventArgs e)
		{
			var rc = ((PictureBox)sender).ClientRectangle;
			rc.Inflate(-2, -2);
			ControlPaint.DrawBorder(((PictureBox)sender).CreateGraphics()
				, ((PictureBox)sender).ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
			ControlPaint.DrawBorder3D(((PictureBox)sender).CreateGraphics()
				, rc, Border3DStyle.Bump);
		}

		public void Clear()
		{
			this.Controls.Clear();
		}
	}
}
