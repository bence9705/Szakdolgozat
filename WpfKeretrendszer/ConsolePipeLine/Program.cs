using System;
using Test.TestHelperClasses;

namespace ConsolePipeLine
{
    class Program
    {
        static void Main(string[] args)
        {
            TestVideoMaker tvm = new TestVideoMaker();
            VideoCapture video = new VideoCapture();
            video.Open("SimpleBlackVideo.avi");
        }
    }
}
