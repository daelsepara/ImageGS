using System.Drawing;

namespace ImageGS
{
    public class BitmapItem
    {
        public string Name;
        public Bitmap Bitmap;

        public BitmapItem(string name, Bitmap bitmap)
        {
            Name = name;

            Bitmap = bitmap;
        }
    }
}
