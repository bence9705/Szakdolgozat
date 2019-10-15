using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
//using WpfKeretrendszer.Kepfeldolgozas;
using System.Threading;
using WpfKeretrendszer.PipeLine;
using WpfKeretrendszer.ImageFilters;

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

        //ADATOK
        enum ClickedButton
        {
            normal = 1,
            canny = 2,
            threshold = 3,
            watershed = 4
        }

               
        //Videohoz
        private VideoCapture videoCapture;
        private string loadedVideo;

        VideoWriter writer;
        private string savePath;
        private FourCC fcc = FourCC.MJPG;
        private int fps = 25;

        private bool isWriterCreated = false;
        private bool allowToWriteVideo = false;
        string videoAlreadyExists = "Video already exists, for save please choose a different file name!";


        //proba
        //CrystalEvaluatorCanny testCannyClass = new CrystalEvaluatorCanny(255, 127);
        //CrystalEvaluatorThreshold testThresholdClass = new CrystalEvaluatorThreshold(127, 255);
        //CrystalEvaluatorWatershed testWatershedClass = new CrystalEvaluatorWatershed(127, 255, new OpenCvSharp.Size(3, 3), MatType.CV_8UC1, 2);

        //ESEMENYKEZELOK
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
                    VideoPlayAndSave(ClickedButton.normal);
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
            VideoPlayAndSave(ClickedButton.canny);
        }

        private void ThresholdClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            VideoPlayAndSave(ClickedButton.threshold);
        }

        private void WatershedClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            VideoPlayAndSave(ClickedButton.watershed);
        }

        private void BackToNormalClick(object sender, RoutedEventArgs e)
        {
            videoCapture = new VideoCapture(loadedVideo);
            VideoPlayAndSave(ClickedButton.normal);

        }

        //FUGGVENYEK
        private void VideoPlayAndSave(ClickedButton button)
        {
            isWriterCreated = false;
            Mat buffer = new Mat();
            Mat result = new Mat();
            int sleepTime = (int)Math.Round(1000 / videoCapture.Fps);
            //ICrystalEvaluatorBase algorithm = new CrystalEvaluatorDefault();

            if (savePath == null)
            {
                allowToWriteVideo = false;
            }
            else if (!File.Exists(savePath))
            {
                allowToWriteVideo = true;
            }
            else
            {
                MessageBox.Show(videoAlreadyExists);
                allowToWriteVideo = false;
            }

            //switch (button)
            //{
            //    case ClickedButton.normal:
            //        result = buffer;
            //        break;
            //    case ClickedButton.canny:
            //        algorithm = new CrystalEvaluatorCanny(127, 255);
            //        break;
            //    case ClickedButton.threshold:
            //        algorithm = new CrystalEvaluatorThreshold(127, 255);
            //        break;
            //    case ClickedButton.watershed:
            //        algorithm = new CrystalEvaluatorWatershed(127, 255);
            //        break;
            //}

            while (true)
            {
                videoCapture.Read(buffer);
                if (buffer.Empty())
                {
                    break;

                }

                //result = algorithm.ProcessNextFrame(buffer);

                if (allowToWriteVideo == true)
                {
                    if(!isWriterCreated)
                    {
                        writer = new VideoWriter(savePath, fcc, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight), isColouredVideo(result));
                        isWriterCreated = true;
                    }
                    writer.Write(result);
                }

                ImageDisplay.Source = ConvertMatToBitmapSource(result);
                Cv2.WaitKey(sleepTime);
            }
        }

        private bool isColouredVideo(Mat result)
        {
            if (result.Channels() == 3 || result.Channels() == 2)
            {
                return true;

            }
            else return false;
        }

        public BitmapSource ConvertMatToBitmapSource(Mat matToConvert)
        {
            return OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(matToConvert);
        }

    }
}
