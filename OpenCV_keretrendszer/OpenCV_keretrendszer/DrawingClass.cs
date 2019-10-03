using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV_keretrendszer
{
    class DrawingClass
    {

        private Mat canvas;
        private Scalar brush;

        //Gomb
        Rect button = new Rect(0, 0, 300, 50);

        // Initializes the image we are going to draw on.

        public void StartDrawing(Size imageSize, Scalar backgroundColor)
        {
            canvas = new Mat(imageSize, MatType.CV_8UC3, backgroundColor);

            Cv2.Rectangle(canvas, button, new Scalar(200, 200, 200), -1);


            //Gomb felirat
            string buttonLabel = "Click me plz";
            Cv2.PutText(canvas, buttonLabel, new Point(100, 25), HersheyFonts.HersheyPlain, 1.0, new Scalar(0, 0, 0), 2);

            //Callback hivasa
            string windowName = "SuperCoolDesign";
            Cv2.NamedWindow(windowName);
            Cv2.NamedWindow("Paint");
            Cv2.SetMouseCallback("Paint", OnMouse);


            int i = 0;

            while (true)
            {
                i++;
                Cv2.ImShow("Paint", canvas);
                Cv2.WaitKey(100);
                if (i == 1000) break;
            }
        }

        private void OnMouse(MouseEvent @event, int x, int y, MouseEvent flags, IntPtr userdata)
        {

            if (@event == MouseEvent.LButtonDown)
            {
                if(button.Contains(new Point(x, y)))
                {
                    canvas.Rectangle(button, new Scalar(0, 0, 255), 2);
                }
            }
            if(@event == MouseEvent.LButtonUp)
            {
                canvas.Rectangle(button, new Scalar(200, 200, 200), 2);
            }
        }
    }
}
