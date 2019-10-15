using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using WpfKeretrendszer;
using WpfKeretrendszer.PipeLine;
using WpfKeretrendszer.ImageFilters;
using Test.TestHelperClasses;
using Test.TestClasses;

namespace Test.Unit_Tests
{
    [TestClass]
    public class BasicPipeLineTest
    {
        [TestMethod]
        public void ProcessTest()
        {
            TestVideoMaker tvm = new TestVideoMaker();
            tvm.CreatSimpleBlackVideo();
            VideoCapture video = new VideoCapture();
            video.Open("SimpleBlackVideo.avi");

            Assert.AreEqual(100, video.FrameCount);        
            Assert.IsTrue(video.IsOpened());

            BasicPipeLine bpl = new BasicPipeLine();            
            TestFilterWithFrameCounter tfwf = new TestFilterWithFrameCounter();
            bpl.AddFilter(tfwf);
            bpl.Displayer = tfwf;

            Mat frame = new Mat();

            while (video.Read(frame))
            {
                if (frame.Empty()) break;

                bpl.Process(frame);
            }
            
            Assert.AreEqual(100, tfwf.GetFrameCount());
            
            //TODO: Test for white rectangle.
        }
    }
}
