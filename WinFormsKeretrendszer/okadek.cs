using System;
using System.Drawing;
using System.IO;
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

        //Videohoz
        private VideoCapture videoCapture;
        private string loadedVideo;
        private string savePath;

        private FourCC fcc = FourCC.MJPG;
        private int fps = 25;
        VideoWriter writer;
        private bool allowToWriteVideo = false;
        string videoAlreadyExists = "Video already exists, for save please choose a different file name!";

        private bool isColouredVideo(ClickedButton button)
        {
            switch(button)
            {
                case ClickedButton.normal:
                    return true;
                case ClickedButton.canny:
                    return false;
                case ClickedButton.threshold:
                    return false;
                default:
                    return false;
            }

        }
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
                    ////input = new Mat(open.FileName);
                    ////Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
                    ////pictureBox1.Image = inputMap;

                    loadedVideo = open.FileName;
                    //videoCapture = new VideoCapture(open.FileName);
                    //if (!File.Exists(savePath))
                    //{
                    //    allowToWriteVideo = true;
                    //    writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), true);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(videoAlreadyExists);
                    //    allowToWriteVideo = false;
                    //}

                    //int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);

                    //while (true)
                    //{
                    //    videoCapture.Read(input);
                    //    if (input.Empty())
                    //        break;
                    //    if(allowToWriteVideo == true)
                    //    {
                    //        writer.Write(input);

                    //    }
                    //    Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
                    //    pictureBox1.Image = inputMap;
                    //    Cv2.WaitKey(sleepTime);
                    //}
                    videoCapture = new VideoCapture(loadedVideo);
                    videoPlayAndSave(ClickedButton.normal);
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
                    saveDisplayedImage(save.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        private void BackToNormal_Click(object sender, EventArgs e)
        {
            ////if (!input.Empty())
            ////{
            ////    buttonToSave = ClickedButton.normal;
            ////    Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
            ////    pictureBox1.Image = inputMap;
            ////}

            //buttonToSave = ClickedButton.normal;
            //videoCapture = new VideoCapture(loadedVideo);
            //int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);

            //if (!File.Exists(savePath))
            //{
            //    allowToWriteVideo = true;
            //    writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), true);
            //}
            //else
            //{
            //    MessageBox.Show(videoAlreadyExists);
            //    allowToWriteVideo = false;
            //}

            //while (true)
            //{
            //    videoCapture.Read(input);
            //    if (input.Empty())
            //        break;
            //    if (allowToWriteVideo == true)
            //    {
            //        writer.Write(input);

            //    }
            //    Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
            //    pictureBox1.Image = inputMap;
            //    Cv2.WaitKey(sleepTime);
            //}
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.normal);
        }

        private void Canny_Click(object sender, EventArgs e)
        {
            ////if(!input.Empty())
            ////{
            ////    buttonToSave = ClickedButton.canny;
            ////    Cv2.Canny(input, canny, highTreshold, lowThreshold);
            ////    Bitmap cannyMap = new Bitmap(ConvertMatToBitmap(canny));
            ////    pictureBox1.Image = cannyMap;
            ////}

            //buttonToSave = ClickedButton.canny;
            //videoCapture = new VideoCapture(loadedVideo);
            //Mat image = new Mat();
            //int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);

            //if (!File.Exists(savePath))
            //{
            //    allowToWriteVideo = true;
            //    writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), false);
            //}
            //else
            //{
            //    MessageBox.Show(videoAlreadyExists);
            //    allowToWriteVideo = false;
            //}

            //while (true)
            //{
            //    videoCapture.Read(image);
            //    if (image.Empty())
            //        break;

            //    Cv2.Canny(image, canny, highTreshold, lowThreshold);
            //    if (allowToWriteVideo == true)
            //    {
            //        writer.Write(canny);

            //    }

            //    Bitmap cannyMap = new Bitmap(ConvertMatToBitmap(canny));
            //    pictureBox1.Image = cannyMap;
            //    Cv2.WaitKey(sleepTime);
            //}
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.canny);
        }


        private void Thresholding_Click(object sender, EventArgs e)
        {
            ////if (!input.Empty())
            ////{
            ////    buttonToSave = ClickedButton.threshold;
            ////    Mat greyscaled = new Mat();
            ////    Cv2.CvtColor(input, greyscaled, ColorConversionCodes.BGR2GRAY);
            ////    Cv2.Threshold(greyscaled, threshold, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
            ////    Bitmap thresholdMap = new Bitmap(ConvertMatToBitmap(threshold));
            ////    pictureBox1.Image = thresholdMap;
            ////}

            //buttonToSave = ClickedButton.threshold;
            //videoCapture = new VideoCapture(loadedVideo);
            //Mat image = new Mat();
            //Mat greyscaled = new Mat();
            //int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);
            //if (!File.Exists(savePath))
            //{
            //    allowToWriteVideo = true;
            //    writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), false);
            //}
            //else
            //{
            //    MessageBox.Show(videoAlreadyExists);
            //    allowToWriteVideo = false;
            //}


            //while (true)
            //{
            //    videoCapture.Read(image);
            //    if (image.Empty())
            //        break;
            //    Cv2.CvtColor(image, greyscaled, ColorConversionCodes.BGR2GRAY);
            //    Cv2.Threshold(greyscaled, threshold, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
            //    if (allowToWriteVideo == true)
            //    {
            //        writer.Write(threshold);

            //    }

            //    Bitmap thresholdMap = new Bitmap(ConvertMatToBitmap(threshold));
            //    pictureBox1.Image = thresholdMap;
            //    Cv2.WaitKey(sleepTime);
            //}
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.threshold);
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

        private void chooseSavePathAndNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    savePath = save.FileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void videoPlayAndSave(ClickedButton button)
        {
            Mat buffer = new Mat();
            int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);
            if (savePath == null)
            {
                allowToWriteVideo = false;
            }
            else if(!File.Exists(savePath))
            {
                allowToWriteVideo = true;
                writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), isColouredVideo(button));
            }
            else
            {
                MessageBox.Show(videoAlreadyExists);
                allowToWriteVideo = false;
            }

                switch (button)
                {
                    case ClickedButton.normal:
                        while(true)
                        {
                            videoCapture.Read(input);
                            if (input.Empty())
                            {
                                break;

                            }
                            if (allowToWriteVideo == true)
                            {
                                writer.Write(input);
                            }

                            Bitmap inputMap = new Bitmap(ConvertMatToBitmap(input));
                            pictureBox1.Image = inputMap;
                            Cv2.WaitKey(sleepTime);
                        }
                        break;

                case ClickedButton.canny:
                    while (true)
                    {
                        videoCapture.Read(buffer);
                        if (buffer.Empty())
                            break;

                        Cv2.Canny(buffer, canny, highTreshold, lowThreshold);
                        if (allowToWriteVideo == true)
                        {
                            writer.Write(canny);
                        }

                        Bitmap cannyMap = new Bitmap(ConvertMatToBitmap(canny));
                        pictureBox1.Image = cannyMap;
                        Cv2.WaitKey(sleepTime);
                    }
                    break;

                case ClickedButton.threshold:
                    Mat greyscaled = new Mat();
                    while (true)
                    {
                        videoCapture.Read(buffer);
                        if (buffer.Empty())
                            break;
                        Cv2.CvtColor(buffer, greyscaled, ColorConversionCodes.BGR2GRAY);
                        Cv2.Threshold(greyscaled, threshold, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
                        if (allowToWriteVideo == true)
                        {
                            writer.Write(threshold);

                        }

                        Bitmap thresholdMap = new Bitmap(ConvertMatToBitmap(threshold));
                        pictureBox1.Image = thresholdMap;
                        Cv2.WaitKey(sleepTime);
                    }
                    break;

            }
        }
    }
}

