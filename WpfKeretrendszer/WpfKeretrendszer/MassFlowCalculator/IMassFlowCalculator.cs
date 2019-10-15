using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.MassFlowCalculator
{
    public interface IMassFlowCalculator
    {
        /// <summary>
        /// Calculates the current mass flow of crystals on an image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        double Calculate(Mat image);
    }
}
