using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using WpfKeretrendszer;
using WpfKeretrendszer.ImageFilters;

namespace Test.Unit_Tests
{
    [TestClass]
    public class DefaultFilterTest
    {   
        [TestMethod]
        public void CurrentFrameTest()
        {
            DefaultFilter df = new DefaultFilter();
            Mat black = new Mat(new Size(300, 300), MatType.CV_8UC1, new Scalar(0, 0, 0));

            df.CurrentFrame = black;

            Mat frame = df.CurrentFrame;

            Assert.AreEqual(300, frame.Width);
            Assert.AreEqual(300, frame.Height);
        }

        [TestMethod]
        public void ProcessTest()
        {
            DefaultFilter df = new DefaultFilter();
            Mat black = new Mat(new Size(300, 300), MatType.CV_8UC1, new Scalar(0, 0, 0));

            DefaultFilter df2 = new DefaultFilter();
                
            df2.Process(df);

            df2.CurrentFrame = black;

            Mat frame = df2.CurrentFrame;

            Assert.AreEqual(300, frame.Width);
            Assert.AreEqual(300, frame.Height);
        }
    }
}
