using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WinFormsKeretrendszer
{
    public partial class Keretrendszer : Form
    {
        public Keretrendszer()
        {
            InitializeComponent();
        }
        
        enum ClickedButton
        {
            normal = 1,
            canny = 2,
            threshold = 3,
            //watershed = 4
        }

        ClickedButton buttonToSave = ClickedButton.normal;

        public Mat input = new Mat();

        public static int highTreshold = 255;
        public static int lowThreshold = highTreshold / 3;
        public Mat canny = new Mat();

        public static int thresholdValue = 127;
        public static int maxBinaryValue = 255;
        public Mat threshold = new Mat();

        //VIDEOHOZ
        private VideoCapture videoCapture;
        string loadedVideo;
        public Bitmap ConvertMatToBitmap(Mat matToConvert)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matToConvert);
        }

        private void saveDisplayedImage(string filePath)
        {
            switch (buttonToSave)
            {
                case ClickedButton.normal:
                    Cv2.ImWrite(filePath, input);
                    break;
                case ClickedButton.canny:
                    Cv2.ImWrite(filePath, canny);
                    break;
                case ClickedButton.threshold:
                    Cv2.ImWrite(filePath, threshold);
                    break;
                    //case ClickedButton.watershed:
                    //    Cv2.ImWrite(filePath, watershed);
                    //    break;
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    //input = new Mat(open.FileName);
                    //Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
                    //pictureBox1.Image = inputMap;

                    loadedVideo = open.FileName;

                    videoCapture = new VideoCapture(loadedVideo);
                    Mat image = new Mat();
                    //FourCC fcc = new FourCC();
                    //fcc = FourCC.MJPG;

                    //VideoWriter writer = new VideoWriter(@"E:\openCV\videos\tesztEllipseYomarad.avi", fcc, 25, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), true);
                    int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);

                    while (true)
                    {
                        videoCapture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                            break;
                        //    writer.Write(image);
                        Bitmap inputMap = new Bitmap(ConvertMatToBitmap(image));
                        pictureBox1.Image = inputMap;
                        Cv2.WaitKey(sleepTime);
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    videoCapture = new VideoCapture(loadedVideo);
                    Mat image = new Mat();
                    FourCC fcc = new FourCC();
                    fcc = FourCC.MJPG;

                    int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);
                    switch (buttonToSave)
                    {
                        case ClickedButton.normal:
                            //Cv2.ImWrite(save.FileName, input);
                            //   saveDisplayedImage(save.FileName);

                            VideoWriter writer = new VideoWriter(save.FileName, fcc, 25, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), true);

                            while (true)
                            {
                                videoCapture.Read(image); // same as cvQueryFrame
                                if (image.Empty())
                                    break;
                                writer.Write(image);
                                Bitmap inputMap = new Bitmap(ConvertMatToBitmap(image));
                                pictureBox1.Image = inputMap;
                                Cv2.WaitKey(sleepTime);
                            }

                            break;
                        case ClickedButton.canny:
                            VideoWriter writer2 = new VideoWriter(save.FileName, fcc, 25, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), false);

                            while (true)
                            {
                                videoCapture.Read(image); // same as cvQueryFrame
                                if (image.Empty())
                                    break;
                                Cv2.Canny(image, canny, highTreshold, lowThreshold);
                                writer2.Write(canny);
                                Bitmap inputMap = new Bitmap(ConvertMatToBitmap(canny));
                                pictureBox1.Image = inputMap;
                                Cv2.WaitKey(sleepTime);
                            }
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        private void BackToNormal_Click(object sender, EventArgs e)
        {
            if (!input.Empty())
            {
                buttonToSave = ClickedButton.normal;
                // Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
                // pictureBox1.Image = inputMap;
            }
        }

        private void Canny_Click(object sender, EventArgs e)
        {

            buttonToSave = ClickedButton.canny;
            videoCapture = new VideoCapture(loadedVideo);
            Mat image = new Mat();

            int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);

            while (true)
            {
                videoCapture.Read(image); // same as cvQueryFrame
                if (image.Empty())
                    break;
                Cv2.Canny(image, canny, highTreshold, lowThreshold);//    writer.Write(image);
                Bitmap inputMap = new Bitmap(ConvertMatToBitmap(canny));
                pictureBox1.Image = inputMap;
                Cv2.WaitKey(sleepTime);
            }
        }


        private void Thresholding_Click(object sender, EventArgs e)
        {
            if (!input.Empty())
            {
                buttonToSave = ClickedButton.threshold;
                //   Mat greyscaled = new Mat();
                //   Cv2.CvtColor(input, greyscaled, ColorConversionCodes.BGR2GRAY);
                //   Cv2.Threshold(greyscaled, threshold, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
                //   Bitmap thresholdMap = new Bitmap(ConvertMatToBitmap(threshold));
                //   pictureBox1.Image = thresholdMap;
            }
        }

        private void Watershed_Click(object sender, EventArgs e)
        {
            if (!input.Empty())
            {
                //buttonToSave = ClickedButton.watershed;
                Mat binary = new Mat();
                Mat markers = new Mat();
                int[,] labels;
                Cv2.CvtColor(input, binary, ColorConversionCodes.BGR2GRAY);
                Cv2.Threshold(binary, binary, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
                Cv2.ConnectedComponents(markers, out labels, PixelConnectivity.Connectivity8);
                //Cv2.Watershed()
                //Bitmap binaryMap = new Bitmap(ConvertMatToBitmap(binary));
                //pictureBox1.Image = binaryMap;
            }
        }
    }
}
