using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.ParticleCalculator
{
    public interface IParticleCalculator
    {
        /// <summary>
        /// Calculates the amount of particles on the picture.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        int Calculate(Mat image);
    }
}
