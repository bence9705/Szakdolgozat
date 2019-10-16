using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using WpfKeretrendszer.MassFlowCalculator;
using WpfKeretrendszer.ParticleCalculator;

namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// ImageFilter standard interface
    /// </summary>
    public interface IImageFilter
    {
        #region Methods
        /// <summary>
        /// Returns CurrentFrame. Important in ThreadSafe environment
        /// </summary>
        /// <returns></returns>
        Mat GetCurrentFrame();

        /// <summary>
        /// Runs the Algorithm on Frame and returns the processed Frame.
        /// </summary>
        /// <param name="source"> Runs the algorithm on this object.</param>
        /// <returns></returns>
        IImageFilter Process(IImageFilter source);

        /// <summary>
        /// Calculates the amount of particles on the current frame image.
        /// </summary>
        int GetParticleNumber();

        /// <summary>
        /// Calculates the massflow from the currentFrame using the specified algorithm.
        /// </summary>
        double GetMassFlow();
        #endregion

    }
}
