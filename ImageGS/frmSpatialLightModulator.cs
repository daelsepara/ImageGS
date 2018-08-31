using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageGS
{
    public partial class frmSpatialLightModulator : Form
    {
        public static List<BitmapItem> Bitmaps = new List<BitmapItem>();

        public frmSpatialLightModulator()
        {
            InitializeComponent();
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

        public void SetLimits()
        {
            SLMWidth.Minimum = 0;
            SLMWidth.Maximum = Int32.MaxValue;

            SLMHeight.Minimum = 0;
            SLMHeight.Maximum = Int32.MaxValue;

            SLMTop.Minimum = Int32.MinValue;
            SLMTop.Maximum = Int32.MaxValue;

            SLMLeft.Minimum = Int32.MinValue;
            SLMLeft.Maximum = Int32.MaxValue;

            OffsetX.Minimum = Int32.MinValue;
            OffsetX.Maximum = Int32.MaxValue;

            OffsetY.Minimum = Int32.MinValue;
            OffsetY.Maximum = Int32.MaxValue;
        }

        public void SetParameters()
        {
            SLMWidth.Value = SpatialLightModulator.Width;
            SLMHeight.Value = SpatialLightModulator.Height;
        }

        private void DetectButton_Click(object sender, System.EventArgs e)
        {
            SpatialLightModulator.Detect();

            SetParameters();
        }

        public void AddBitmap(string name, Bitmap bitmap)
        {
            if (bitmap != null)
            {
                bool found = false;

                for (var i = 0; i < Bitmaps.Count; i++)
                {
                    var item = Bitmaps[i];

                    if (name.Equals(item.Name))
                    {
                        found = true;

                        break;
                    }
                }

                if (!found)
                {
                    Bitmaps.Add(new BitmapItem(name, bitmap));
                    BitmapList.Items.Add(name);
                    BitmapList.SelectedIndex = BitmapList.Items.Count - 1;

                    SpatialLightModulator.SetBitmap(ref bitmap);
                }
            }
        }

        public void RemoveBitmap(string name)
        {
            bool found = false;
            int index = -1;

            for (var i = 0; i < Bitmaps.Count; i++)
            {
                var item = Bitmaps[i];

                if (name.Equals(item.Name))
                {
                    found = true;

                    index = i;
                }
            }

            if (found && index >= 0)
            {
                Bitmaps.RemoveAt(index);
                BitmapList.Items.RemoveAt(index);

                SpatialLightModulator.ResetBitmap();
            }
        }

        private void SetBitmapButton_Click(object sender, System.EventArgs e)
        {
            if (BitmapList.SelectedIndex >= 0 && Bitmaps.Count > 0 && BitmapList.SelectedIndex <= Bitmaps.Count)
            {
                SpatialLightModulator.SetBitmap(ref Bitmaps[BitmapList.SelectedIndex].Bitmap);

                SpatialLightModulator.Show();
            }
        }

        private void Width_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Width = Convert.ToInt32(SLMWidth.Value);

            SpatialLightModulator.Resize();
        }

        private void Height_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Height = Convert.ToInt32(SLMHeight.Value);

            SpatialLightModulator.Resize();
        }

        private void Left_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Left = Convert.ToInt32(SLMLeft.Value);

            SpatialLightModulator.Move();
        }

        private void Top_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.Top = Convert.ToInt32(SLMTop.Value);

            SpatialLightModulator.Move();
        }

        private void frmSpatialLightModulator_Activated(object sender, EventArgs e)
        {
            SetParameters();
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            SpatialLightModulator.Hide();
        }

        private void OffsetX_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.OffsetX = Convert.ToInt32(OffsetX.Value);
        }

        private void OffsetY_ValueChanged(object sender, EventArgs e)
        {
            SpatialLightModulator.OffsetY = Convert.ToInt32(OffsetY.Value);
        }
    }
}
