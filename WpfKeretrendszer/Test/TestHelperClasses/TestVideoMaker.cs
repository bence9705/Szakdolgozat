using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Test.TestHelperClasses
{
    public class TestVideoMaker
    {
        private VideoWriter writer = new VideoWriter();

        public void CreatSimpleBlackVideo()
        {
            Console.WriteLine(writer.IsOpened());
            Mat frame = new Mat(new Size(100, 100), MatType.CV_8UC3);

            using (writer = new VideoWriter("SimpleBlackVideo.avi", FourCC.H264, 25, new Size(100, 100)))
            {
                Console.WriteLine(writer.IsOpened());

                for (int i = 0; i < 100; i++)
                {                    
                    writer.Write(frame);
                } 
            }
            
        }
    }
}
