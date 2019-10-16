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

            //Tests for the video written by TestVideoMaker.
            Assert.AreEqual(100, video.FrameCount);        
            Assert.IsTrue(video.IsOpened());

            BasicPipeLine bpl = new BasicPipeLine();            
            TestFilterWithFrameCounter tfwf = new TestFilterWithFrameCounter();
            bpl.AddFilter(tfwf);
            bpl.Displayer = tfwf;

            Mat frame = new Mat();
            int whiteRectFrame = 0;

            while (video.Read(frame))
            {
                if (frame.Empty()) break;

                bpl.Process(frame);

                if (IsThereWhiteRect(bpl.Display())) whiteRectFrame++;
            }
            
            //Process must go through every frame (100).
            Assert.AreEqual(100, tfwf.GetFrameCount());

            //Every frame has a white Rectangle. TestFilter applied.
            Assert.AreEqual(100, whiteRectFrame);
        }

        public bool IsThereWhiteRect(Mat image)
        {
            var indexer = image.GetGenericIndexer<Vec3b>();

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (indexer[y, x].Item0 == 0) return false;
                }
            }

            return true;
        }
    }
}
