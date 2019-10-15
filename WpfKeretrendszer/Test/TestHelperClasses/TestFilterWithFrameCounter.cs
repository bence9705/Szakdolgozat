using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using WpfKeretrendszer.ImageFilters;

namespace Test.TestClasses
{
    public class TestFilterWithFrameCounter : DefaultFilter
    {
        private int frameCount;

        public TestFilterWithFrameCounter()
        {
            frameCount = 0;
        }

        /// <summary>
        /// Draws a 20*20 white rectanlge in the corner
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override IImageFilter Process(IImageFilter source)
        {
            CurrentFrame = source.GetCurrentFrame();
            CurrentFrame.Rectangle(new Point(0, 0), new Point(20, 20),new Scalar(255, 255, 255) ,-1);
            frameCount++;

            return this;
        }

        public int GetFrameCount()
        {
            return frameCount;
        }
    }
}
