using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// ImageFilter standard interface
    /// </summary>
    interface IImageFilter
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
        ImageFilterBase Process(ImageFilterBase source);

        /// <summary>
        /// Calculates the amount of particles on source image.
        /// </summary>
        /// <returns></returns>
        int GetParticleNumber(Mat source); 
        #endregion

    }
}
