using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageGS
{
    public partial class frmGerchbergSaxton : Form
    {
        Bitmap Target;

        PictureBox PhasePicture;
        Form PhaseForm;
        frmSpatialLightModulator SLM;

        SaveFileDialog SaveImageDialog;

        public frmGerchbergSaxton()
        {
            InitializeComponent();

            SaveImageDialog = new SaveFileDialog();
            SaveImageDialog.InitialDirectory = "c:\\";
            SaveImageDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|tiff files (*.tiff)|*.tif|gif files (*.gif)|*.gif";
            SaveImageDialog.RestoreDirectory = false;
            SaveImageDialog.FilterIndex = 1;

            SaveHologramButton.Enabled = false;
        }

        #region Form modifications
        // disable close button
        // https://www.codeproject.com/Articles/20379/Disabling-Close-Button-on-Forms
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #endregion

        #region get/set parameters

        public void GetInput()
        {
            Target = Images.InputBitmap;
        }

        public void SetTarget(Form output, PictureBox picture, frmSpatialLightModulator slm)
        {
            PhaseForm = output;
            PhasePicture = picture;

            SLM = slm;
        }

        public void SetLimits()
        {
            Iterations.Minimum = 1;
            Iterations.Maximum = Int32.MaxValue;

            OutputHeight.Minimum = 0;
            OutputHeight.Maximum = Int32.MaxValue;

            OutputWidth.Minimum = 0;
            OutputWidth.Maximum = Int32.MaxValue;
        }

        public void SetIterations(int iterations)
        {
            Iterations.Value = iterations;
        }

        public void GetIterations(out int iterations)
        {
            iterations = Convert.ToInt32(Iterations.Value);
        }

        public void SetResizeMode(bool resizeTarget, bool cropTarget)
        {
            ResizeTarget.Checked = resizeTarget;
            CropTarget.Checked = cropTarget;
        }

        public void GetResizeMode(out bool resizeTarget, out bool resizeCanvas)
        {
            resizeTarget = ResizeTarget.Checked;
            resizeCanvas = CropTarget.Checked;
        }

        public void SetOutputSize()
        {
            OutputWidth.Value = SpatialLightModulator.Width;
            OutputHeight.Value = SpatialLightModulator.Height;
        }

        public void GetOutputSize(out int width, out int height)
        {
            width = Convert.ToInt32(OutputWidth.Value);
            height = Convert.ToInt32(OutputHeight.Value);
        }
        #endregion

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateButton.Enabled = false;
            SaveHologramButton.Enabled = false;

            SLM.RemoveBitmap("Computed Hologram");

            PhaseForm.Text = "Computing Hologram ...";

            GerchbergSaxton.CopyParameters(this);

            GetInput();

            GerchbergSaxton.Free(Images.PhaseBitmap);

            Images.PhaseBitmap = GerchbergSaxton.Compute(Target);

            if (Images.PhaseBitmap != null)
            {
                RenderBitmap(ref Images.PhaseBitmap);
                SaveHologramButton.Enabled = true;

                SLM.AddBitmap("Computed Hologram", Images.PhaseBitmap);
            }

            CalculateButton.Enabled = true;
            PhaseForm.Text = "ImageGS";
        }

        private void ResizePatternWindow(int sizex, int sizey)
        {
            PhaseForm.Width = sizex + 16;
            PhaseForm.Height = sizey + 40;
            PhaseForm.Width = sizex;
            PhaseForm.Height = sizey;
            PhasePicture.Width = sizex;
            PhasePicture.Height = sizey;

            GerchbergSaxton.Free(PhasePicture.Image);

            PhasePicture.Image = new Bitmap(sizex, sizey);

            using (var gr = Graphics.FromImage(PhasePicture.Image))
            {
                gr.Clear(Color.Black);
            }
        }

        void RenderBitmap(ref Bitmap bitmap)
        {
            if (bitmap != null)
            {
                GerchbergSaxton.Free(PhasePicture.Image);

                PhasePicture.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
            }
        }

        private void SaveHologramButton_Click(object sender, EventArgs e)
        {
            if (SaveImageDialog.FileName != null && SaveImageDialog.FileName.Length > 0)
            {
                SaveImageDialog.InitialDirectory = System.IO.Path.GetDirectoryName(SaveImageDialog.FileName);
                SaveImageDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(SaveImageDialog.FileName);
            }
            else
            {
                SaveImageDialog.FileName = "phase";
            }

            if (SaveImageDialog.ShowDialog() == DialogResult.OK)
            {
                if (Images.PhaseBitmap != null)
                {
                    if (SaveImageDialog.FilterIndex == 1)
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Png);
                    }
                    else if (SaveImageDialog.FilterIndex == 2)
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Jpeg);
                    }
                    else if (SaveImageDialog.FilterIndex == 3)
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Bmp);
                    }
                    else if (SaveImageDialog.FilterIndex == 4)
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Tiff);
                    }
                    else if (SaveImageDialog.FilterIndex == 5)
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Gif);
                    }
                    else
                    {
                        Images.PhaseBitmap.Save(SaveImageDialog.FileName, ImageFormat.Png);
                    }
                }
            }
        }

        private void OutputWidth_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Width = Convert.ToInt32(OutputWidth.Value);

            SpatialLightModulator.Resize();
        }

        private void OutputHeight_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Height = Convert.ToInt32(OutputHeight.Value);

            SpatialLightModulator.Resize();
        }

        private void frmGerchbergSaxton_Activated(object sender, EventArgs e)
        {
            SetOutputSize();
        }
    }
}
