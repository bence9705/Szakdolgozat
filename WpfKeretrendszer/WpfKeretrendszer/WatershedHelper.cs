using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKeretrendszer
{
    static class WatershedHelper
    {
        static public Mat UnknownPixelSetToZero(Mat unknownImage, Mat markers)
        {
            Vec3b point = new Vec3b();
            var indexer = unknownImage.GetGenericIndexer<Vec3b>();

            for (int y = 0; y < unknownImage.Height; y++)
            {
                for (int x = 0; x < unknownImage.Width; x++)
                {
                    point = indexer[y, x];

                    if (point.Item0 == 255)
                    {
                        markers.Set<Vec3b>(y, x, new Vec3b(0, 0, 0));
                    }
                }
            }
            return markers;
        }

        static public Mat MarkBorders(Mat markers, Mat image)
        {
            Vec3b point = new Vec3b();
            var indexer = markers.GetGenericIndexer<Vec3b>();

            for (int y = 0; y < markers.Height; y++)
            {
                for (int x = 0; x < markers.Width; x++)
                {
                    point = indexer[y, x];

                    if (point.Item0 == 255)
                    {
                        image.Set<Vec3b>(y, x, new Vec3b(0, 0, 255));
                    }
                }
            }
            return image;
        }
    }
}
