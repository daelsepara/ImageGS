using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageGS
{
    class SpatialLightModulator
    {
        public static int Width = 800;
        public static int Height = 600;
        public static int Top = 0;
        public static int Left = 0;
        public static int OffsetX = 0;
        public static int OffsetY = 0;
        private static Bitmap Target;
        private static Form Hardware;
        private static PictureBox Display;

        public static void Initialize()
        {
            Hardware = new Form();
            Hardware.FormBorderStyle = FormBorderStyle.None;
            Hardware.ControlBox = false;
            Hardware.MaximizeBox = false;
            Hardware.MinimizeBox = false;

            Hardware.Hide();
            Hardware.Width = Width;
            Hardware.Height = Height;
            Hardware.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            Hardware.MinimumSize = new Size(0, 0);
            Hardware.ControlBox = false;
            Hardware.Top = Top;
            Hardware.Left = Left;

            Display = new PictureBox();
            Display.MaximumSize = new Size(int.MaxValue, int.MaxValue);
            Display.MinimumSize = new Size(0, 0);
            Display.Width = Width;
            Display.Height = Height;
            Display.BackColor = Color.Black;
            Display.SizeMode = PictureBoxSizeMode.Normal;
            Display.Top = 0;
            Display.Left = 0;
            Display.Padding = new Padding(0, 0, 0, 0);

            Hardware.Controls.Add(Display);
        }

        public static void Detect()
        {
            var screens = Screen.AllScreens;

            if (screens.Length > 1)
            {
                var location = screens[1].WorkingArea.Location;

                Top = location.Y;
                Left = location.X;
                Width = screens[1].Bounds.Width;
                Height = screens[1].Bounds.Height;
            }
        }

        public static void Render()
        {
            if (Target != null)
            {
                Free(Display.Image);

                var bitmap = new Bitmap(Width, Height, Target.PixelFormat);

                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Black);

                    graphics.DrawImage(Target, OffsetX, OffsetY);
                }

                Display.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);

                Free(bitmap);
            }
        }

        public static bool IsVisible()
        {
            return Hardware.Visible;
        }

        public static void Hide()
        {
            Hardware.Hide();
        }

        public static void Show()
        {
            Hardware.Show();

            Move();
        }

        public static void ResetBitmap()
        {
            Target = null;
        }

        public static void SetBitmap(ref Bitmap bitmap)
        {
            Target = bitmap;

            Render();
        }

        public static void Resize()
        {
            Hardware.Width = Width;
            Hardware.Height = Height;

            Display.Width = Width;
            Display.Height = Height;

            Free(Display.Image);

            Display.Image = new Bitmap(Width, Height);
        }

        public static void Move()
        {
            Hardware.Top = Top;
            Hardware.Left = Left;
        }

        private static void Free(params IDisposable[] trash)
        {
            foreach (var item in trash)
            {
                if (item != null)
                    item.Dispose();
            }
        }
    }
}
