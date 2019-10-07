﻿using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfKeretrendszer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
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

        private static Mat input = new Mat();

        private static int highTreshold = 255;
        private static int lowThreshold = highTreshold / 3;
        private Mat canny = new Mat();

        private static int thresholdValue = 127;
        private static int maxBinaryValue = 255;
        private Mat threshold = new Mat();

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
            switch (button)
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

        public BitmapSource ConvertMatToBitmapSource(Mat matToConvert)
        {
            return OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(matToConvert);
        }

        private void ChooseSavePathClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == true)
                {
                    savePath = save.FileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() == true)
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

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CannyClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.canny);
        }

        private void ThresholdClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.threshold);
        }

        private void WatershedClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            videoPlayAndSave(ClickedButton.watershed);
        }

        private void BackToNormalClick(object sender, RoutedEventArgs e)
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
            else if (!File.Exists(savePath))
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
                    while (true)
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

                        ImageDisplay.Source = ConvertMatToBitmapSource(input);
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

                        ImageDisplay.Source = ConvertMatToBitmapSource(canny);
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

                        ImageDisplay.Source = ConvertMatToBitmapSource(threshold);
                        Cv2.WaitKey(sleepTime);
                    }
                    break;

                case ClickedButton.watershed:
                    while (true)
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
                        markers = WatershedHelper.UnknownPixelSetToZero(unknownArea, markers);
                        Cv2.Watershed(buffer, markers);


                        //MAKE BORDERS IN IMAGE
                        result = WatershedHelper.MarkBorders(markers, buffer);
                        markers.ConvertTo(markers, MatType.CV_8UC1);
                        if (allowToWriteVideo == true)
                        {
                            writer.Write(result);
                        }
                        ImageDisplay.Source = ConvertMatToBitmapSource(result);
                        Cv2.WaitKey(sleepTime);
                    }
                    break;
            }
        }
    }
}