using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageGS
{
    unsafe public partial class ImageGSForm : Form
    {
        OpenFileDialog OpenImageDialog;

        frmGerchbergSaxton GerchbergSaxtonForm;
        frmSpatialLightModulator SpatialLightModulatorForm;

        Form PhaseForm;
        PictureBox PhasePicture;

        public ImageGSForm()
        {
            InitializeComponent();

            Initialize();
            InitializeBitmaps();
            InitializePhaseForm();

            SpatialLightModulator.Initialize();

            SpatialLightModulatorForm = new frmSpatialLightModulator();
            SpatialLightModulatorForm.SetLimits();
            SpatialLightModulatorForm.SetParameters();
            
            SpatialLightModulatorForm.AddBitmap("Target", Images.InputBitmap);

            GerchbergSaxtonForm = new frmGerchbergSaxton();
            GerchbergSaxtonForm.SetLimits();

            GerchbergSaxtonForm.SetTarget(this, PhaseImage, SpatialLightModulatorForm);
        }

        void Initialize()
        {
            OpenImageDialog = new OpenFileDialog();
            OpenImageDialog.InitialDirectory = "c:\\";
            OpenImageDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|tiff files (*.tiff)|*.tif|gif files (*.gif)|*.gif|All files (*.*)|*.*";
            OpenImageDialog.FilterIndex = 1;
        }

        void InitializeBitmaps()
        {
            Images.InputBitmap = NewBitmap(TargetImage.Width, TargetImage.Height);
            Images.PhaseBitmap = NewBitmap(PhaseImage.Width, PhaseImage.Height);

            RenderBitmap(Images.InputBitmap, TargetImage);
            RenderBitmap(Images.PhaseBitmap, PhaseImage);
        }

        private void PreventClose(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            return;
        }

        private void InitializePhaseForm()
        {
            PhaseForm = new Form();
            PhaseForm.FormClosing += PreventClose;
            PhaseForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            PhaseForm.Hide();
            PhaseForm.Width = 816;
            PhaseForm.Height = 640;
            PhaseForm.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            PhaseForm.MinimumSize = new Size(0, 0);
            PhaseForm.ControlBox = true;
            PhaseForm.MaximizeBox = false;
            PhasePicture = new PictureBox();
            PhasePicture.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            PhasePicture.MinimumSize = new Size(0, 0);
            PhasePicture.Width = 800;
            PhasePicture.Height = 600;
            PhasePicture.BackColor = Color.Black;
            PhasePicture.SizeMode = PictureBoxSizeMode.Normal;
            PhaseForm.Controls.Add(PhasePicture);
            PhasePicture.Top = 0;
            PhasePicture.Left = 0;
            PhasePicture.Padding = new Padding(0, 0, 0, 0);
            
            PhaseForm.Hide();
        }

        public static void Free(params IDisposable[] trash)
        {
            foreach (var item in trash)
            {
                if (item != null)
                    item.Dispose();
            }
        }

        unsafe void Free(params double*[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                    Marshal.FreeHGlobal((IntPtr)item);
            }
        }

        unsafe void Free(params byte*[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                    Marshal.FreeHGlobal((IntPtr)item);
            }
        }

        void RenderBitmap(Bitmap bitmap, PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }

            pictureBox.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
        }

        Bitmap ConvertTo24bpp(Bitmap bitmap32)
        {
            var bitmap24 = new Bitmap(bitmap32.Width, bitmap32.Height, PixelFormat.Format24bppRgb);

            using (var graphics = Graphics.FromImage(bitmap24))
            {
                graphics.DrawImage(bitmap32, new Rectangle(0, 0, bitmap32.Width, bitmap32.Height));
            }

            return bitmap24;
        }

        BitmapData LockBits(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

                return bmpData;
            }

            return null;
        }

        double* PrepareBitmap(Bitmap bitmap)
        {
            var xdim = bitmap.Width;
            var ydim = bitmap.Height;

            var IsNotRGB24 = (bitmap.PixelFormat != PixelFormat.Format24bppRgb);
            var temp = IsNotRGB24 ? ConvertTo24bpp(bitmap) : bitmap;

            var buffer = (double*)Marshal.AllocHGlobal(xdim * ydim * sizeof(double));

            var readData = LockBits(temp);

            var Depth = Image.GetPixelFormatSize(temp.PixelFormat);
            var Channels = Depth / 8;

            for (var y = 0; y < ydim; y++)
            {
                for (var x = 0; x < xdim; x++)
                {
                    var startIndex = y * readData.Stride + x * Channels;

                    var index = (y * xdim + x);

                    var R = Marshal.ReadByte(readData.Scan0, startIndex);
                    var G = Marshal.ReadByte(readData.Scan0, startIndex + 1);
                    var B = Marshal.ReadByte(readData.Scan0, startIndex + 2);

                    buffer[index] = (0.299 * (double)R + 0.587 * (double)G + 0.114 * (double)B);
                }
            }

            UnlockBits(temp, readData);

		    if (IsNotRGB24)
                Free(temp);

            return buffer;
	    }

        unsafe byte* PrepareImage(Bitmap bitmap)
        {
            var Channels = 3;

            var xdim = bitmap.Width;
            var ydim = bitmap.Height;

            var IsNotRGB24 = (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var temp = IsNotRGB24 ? ConvertTo24bpp(bitmap) : bitmap;

            var buffer = (byte*)Marshal.AllocHGlobal(xdim * ydim * Channels);

            var readData = LockBits(temp);

            var Depth = Image.GetPixelFormatSize(temp.PixelFormat);

            for (var y = 0; y < ydim; y++)
            {
                for (var x = 0; x < xdim; x++)
                {
                    var startIndex = y * readData.Stride + x * Channels;
                    var dst = (y * xdim + x) * Channels;

                    buffer[dst] = Marshal.ReadByte(readData.Scan0, startIndex);
                    buffer[dst + 1] = Marshal.ReadByte(readData.Scan0, startIndex + 1);
                    buffer[dst + 2] = Marshal.ReadByte(readData.Scan0, startIndex + 2);
                }
            }

            UnlockBits(temp, readData);

		    if (IsNotRGB24)

                Free(temp);

		    return buffer;
	    }

        void UnlockBits(Bitmap bitmap, BitmapData bmpData)
        {
            if (bitmap != null && bmpData != null)
                bitmap.UnlockBits(bmpData);
        }

        Bitmap NewBitmap(int Width, int Height)
        {
            var bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.Black);
            }

            return bitmap;
        }

        Bitmap WritePhaseBitmap(double* image, int srcx, int srcy)
        {
            var pixbuf = NewBitmap(srcx, srcy);
            var bmpData = LockBits(pixbuf);
            var Depth = Image.GetPixelFormatSize(pixbuf.PixelFormat);
            var Channels = Depth / 8;

            if (image != null)
            {
                for (var y = 0; y < pixbuf.Height; y++)
                {
                    var offset = y * srcx;

                    for (var x = 0; x < pixbuf.Width; x++)
                    {
                        var magnitude = image[offset + x];

                        var startIndex = y * bmpData.Stride + x * Channels;

                        var byteVal = (byte)(255.0 * (magnitude) / (2.0 * Math.PI));

                        Marshal.WriteByte(bmpData.Scan0, startIndex, byteVal);
                        Marshal.WriteByte(bmpData.Scan0, startIndex + 1, byteVal);
                        Marshal.WriteByte(bmpData.Scan0, startIndex + 2, byteVal);
                    }
                }
            }

            UnlockBits(pixbuf, bmpData);

            return pixbuf;
        }

        void CleanShutdown()
        {
            Free(Images.InputBitmap, Images.PhaseBitmap);
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            if (OpenImageDialog.FileName != null && OpenImageDialog.FileName.Length > 0)
            {
                OpenImageDialog.InitialDirectory = System.IO.Path.GetDirectoryName(OpenImageDialog.FileName);
            }

            if (OpenImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SpatialLightModulatorForm.RemoveBitmap("Target");

                    var src = new Bitmap(OpenImageDialog.FileName);

                    Free(Images.InputBitmap);

                    Images.InputBitmap = ConvertTo24bpp(src);

                    Free(src);

                    RenderBitmap(Images.InputBitmap, TargetImage);

                    SpatialLightModulatorForm.AddBitmap("Target", Images.InputBitmap);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void GSButton_Click(object sender, EventArgs e)
        {
            GerchbergSaxton.SetParameters(GerchbergSaxtonForm);

            GerchbergSaxtonForm.Show();
            GerchbergSaxtonForm.BringToFront();

            if (GerchbergSaxtonForm.WindowState == FormWindowState.Minimized)
                GerchbergSaxtonForm.WindowState = FormWindowState.Normal;
        }

        private void SLMButton_Click(object sender, EventArgs e)
        {
            SpatialLightModulator.Detect();

            SpatialLightModulatorForm.Show();
            SpatialLightModulatorForm.BringToFront();

            if (SpatialLightModulatorForm.WindowState == FormWindowState.Minimized)
                SpatialLightModulatorForm.WindowState = FormWindowState.Normal;
        }

        private void ImageGSTimer_Tick(object sender, EventArgs e)
        {
            if (SpatialLightModulator.IsVisible())
            {
                SpatialLightModulator.Render();
                SpatialLightModulator.Show();
            }
        }
    }
}
