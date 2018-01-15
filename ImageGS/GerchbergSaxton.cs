using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageGS
{
    unsafe internal static class GerchbergSaxton
    {
        internal static int Iterations = 50;
        internal static bool ResizeTarget = true;
        internal static bool CropTarget = false;

        internal static void SetParameters(frmGerchbergSaxton form)
        {
            form.SetOutputSize();
            form.SetResizeMode(ResizeTarget, CropTarget);
            form.SetIterations(Iterations);
        }

        internal static void CopyParameters(frmGerchbergSaxton form)
        {
            form.GetOutputSize(out SpatialLightModulator.Width, out SpatialLightModulator.Height);
            form.GetResizeMode(out ResizeTarget, out CropTarget);
            form.GetIterations(out Iterations);
        }

        [DllImport("GerchbergSaxton.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void Calculate(int argc, void** argv);

        [DllImport("GerchbergSaxton.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void Release();

        [DllImport("GerchbergSaxton.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern double* Phase();

        static BitmapData LockBits(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

                return bmpData;
            }

            return null;
        }

        private static void UnlockBits(Bitmap bitmap, BitmapData bmpData)
        {
            if (bitmap != null && bmpData != null)
                bitmap.UnlockBits(bmpData);
        }

        private static double* PrepareBitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                var xdim = ResizeTarget ? bitmap.Width : (bitmap.Width < SpatialLightModulator.Width ? bitmap.Width : SpatialLightModulator.Width);
                var ydim = ResizeTarget ? bitmap.Height : (bitmap.Height < SpatialLightModulator.Height ? bitmap.Height : SpatialLightModulator.Height);

                var dstWidth = ResizeTarget ? xdim : SpatialLightModulator.Width;
                var dstHeight = ResizeTarget ? ydim : SpatialLightModulator.Height;

                var srcx = ResizeTarget ? 0 : (bitmap.Width > SpatialLightModulator.Width ? (bitmap.Width - SpatialLightModulator.Width) / 2 : 0);
                var srcy = ResizeTarget ? 0 : (bitmap.Height > SpatialLightModulator.Height ? (bitmap.Height - SpatialLightModulator.Height) / 2 : 0);
                var dstx = ResizeTarget ? 0 : (SpatialLightModulator.Width > bitmap.Width ? (SpatialLightModulator.Width - bitmap.Width) / 2 : 0);
                var dsty = ResizeTarget ? 0 : (SpatialLightModulator.Height > bitmap.Height ? (SpatialLightModulator.Height - bitmap.Height) / 2 : 0);

                var buffer = (double*)Marshal.AllocHGlobal(dstWidth * dstHeight * sizeof(double));

                for (var i = 0; i < dstWidth * dstHeight; i++)
                    buffer[i] = 0.0;

                var readData = LockBits(bitmap);

                var Depth = Image.GetPixelFormatSize(bitmap.PixelFormat);
                var Channels = Depth / 8;

                for (var y = 0; y < ydim; y++)
                {
                    for (var x = 0; x < xdim; x++)
                    {
                        var startIndex = (y + srcy) * readData.Stride + (x + srcx) * Channels;

                        var index = (y + dsty) * dstWidth + (x + dstx);

                        var R = Marshal.ReadByte(readData.Scan0, startIndex);
                        var G = Marshal.ReadByte(readData.Scan0, startIndex + 1);
                        var B = Marshal.ReadByte(readData.Scan0, startIndex + 2);

                        buffer[index] = (0.299 * (double)R + 0.587 * (double)G + 0.114 * (double)B);
                    }
                }

                UnlockBits(bitmap, readData);

                return buffer;
            }

            return null;
        }

        private static Bitmap WritePhaseBitmap(double* image, int srcx, int srcy)
        {
            var bitmap = new Bitmap(srcx, srcy, PixelFormat.Format24bppRgb);
            var bmpData = LockBits(bitmap);
            var Depth = Image.GetPixelFormatSize(bitmap.PixelFormat);
            var Channels = Depth / 8;

            if (image != null)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var offset = y * srcx;

                    for (var x = 0; x < bitmap.Width; x++)
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

            UnlockBits(bitmap, bmpData);

            return bitmap;
        }

        public static Bitmap Compute(Bitmap bitmap)
        {
            if (File.Exists("GerchbergSaxton.dll") && bitmap != null)
            {
                var Target = PrepareBitmap(bitmap);

                int TargetX = SpatialLightModulator.Width;
                int TargetY = SpatialLightModulator.Height;
                bool ResizeBilinear = true;
                bool ApertureRectangle = false;
                bool ApertureEllipse = false;
                int ApertureWidth = SpatialLightModulator.Width;
                int ApertureHeight = SpatialLightModulator.Height;
                bool InputGaussian = false;
                double GaussianWaist = 100;
                int X = ResizeTarget ? bitmap.Width : SpatialLightModulator.Width;
                int Y = ResizeTarget ? bitmap.Height : SpatialLightModulator.Height;

                int Ngs = Iterations;

                void** Parameters = stackalloc void*[13];

                Parameters[0] = (&TargetX);
                Parameters[1] = (&TargetY);
                Parameters[2] = (&Ngs);
                Parameters[3] = (&ResizeBilinear);
                Parameters[4] = (&ApertureRectangle);
                Parameters[5] = (&ApertureEllipse);
                Parameters[6] = (&ApertureWidth);
                Parameters[7] = (&ApertureHeight);
                Parameters[8] = (&InputGaussian);
                Parameters[9] = (&GaussianWaist);
                Parameters[10] = Target;
                Parameters[11] = (&X);
                Parameters[12] = (&Y);

                Calculate(13, Parameters);

                var Hologram = Phase();

                var phaseBitmap = WritePhaseBitmap(Hologram, SpatialLightModulator.Width, SpatialLightModulator.Height);

                Release();

                Free(Target);

                return phaseBitmap;
            }

            return null;
        }

        public static void Free(params IDisposable[] trash)
        {
            foreach (var item in trash)
            {
                if (item != null)
                    item.Dispose();
            }
        }

        unsafe public static void Free(params double*[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                    Marshal.FreeHGlobal((IntPtr)item);
            }
        }
    }
}
