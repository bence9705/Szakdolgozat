using OpenCvSharp;
using System;


namespace OpenCV_keretrendszer
{
    class Program
    {

        static void Main(string[] args)
        {
            DrawingClass drawingClass = new DrawingClass();
            drawingClass.StartDrawing(new Size(300, 300), new Scalar(0, 255, 0));
        }
    }
}
