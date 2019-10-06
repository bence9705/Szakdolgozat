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
            watershed = 4
        }

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
                case ClickedButton.watershed:
                    return true;
                default:
                    return false;
            }
        }

        public Bitmap ConvertMatToBitmap(Mat matToConvert)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matToConvert);
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    loadedVideo = open.FileName;
                    videoCapture = new VideoCapture(loadedVideo);
                    videoPlayAndSave(ClickedButton.normal);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Canny_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.canny);
        }


        private void Thresholding_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.threshold);
        }

        private void Watershed_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.watershed);
        }

        private void BackToNormal_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.normal);
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

                case ClickedButton.watershed:
                    while(true)
                    {
                        videoCapture.Read(buffer);
                        if (buffer.Empty())
                            break;

                        //GREYSCALED IMAGE
                        Mat greyscale = new Mat();
                        Cv2.CvtColor(buffer, greyscale, ColorConversionCodes.BGR2GRAY);

                        //BINARY AND INVERTED IMAGE
                        Mat threshold = new Mat();
                        double thresholdValue = 140;
                        double thresholdMaxValue = 255;
                        Cv2.Threshold(greyscale, threshold, thresholdValue, thresholdMaxValue, ThresholdTypes.BinaryInv);

                        //MORPHOLOGY IMAGE (REMOVE WHITE NOISE)
                        Mat morphology = new Mat();
                        Mat element = new Mat(new OpenCvSharp.Size(3, 3), MatType.CV_8UC1);
                        int iterations = 2;
                        Cv2.MorphologyEx(threshold, morphology, MorphTypes.Open, element, iterations: iterations);

                        //SURE BACKGROUND
                        Mat sureBackground = new Mat();
                        Mat ellipseElement = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3, 3));
                        iterations = 3;
                        Cv2.Dilate(morphology, sureBackground, ellipseElement, iterations: iterations);

                        //SURE FOREGROUND DISTANCE TRANSFORM AND NORMALIZE 
                        Mat distanceTransform = new Mat();
                        Cv2.DistanceTransform(morphology, distanceTransform, DistanceTypes.L1, DistanceMaskSize.Mask3);
                        distanceTransform.ConvertTo(distanceTransform, MatType.CV_8U);

                        //SURE FOREGROUND THRESHOLD
                        Mat sureForeground = new Mat();
                        thresholdValue = 19;
                        Cv2.Threshold(distanceTransform, sureForeground, thresholdValue, thresholdMaxValue, ThresholdTypes.Binary);

                        //FIND UNKNOWN AREA
                        Mat unknownArea = new Mat();
                        Cv2.Subtract(sureBackground, sureForeground, unknownArea);

                        //CREATE MARKERS FOR WATERSHED
                        Mat markers = new Mat();
                        Mat result = new Mat();
                        Cv2.ConnectedComponents(sureForeground, markers);
                        markers = markers + 30;
                        markers = watershedHelper.UnknownPixelSetToZero(unknownArea, markers);
                        Cv2.Watershed(buffer, markers);


                        //MAKE BORDERS IN IMAGE
                        result = watershedHelper.MarkBorders(markers, buffer);
                        markers.ConvertTo(markers, MatType.CV_8UC1);
                        if (allowToWriteVideo == true)
                        {
                            writer.Write(result);
                        }
                        Bitmap watershedMap = new Bitmap(ConvertMatToBitmap(result));
                        pictureBox1.Image = watershedMap;
                        Cv2.WaitKey(sleepTime);
                    }
                    break;
            }
        }
    }
}

