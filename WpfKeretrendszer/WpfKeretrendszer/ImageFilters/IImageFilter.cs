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
        #region Properties
        /// <summary>
        /// Property used to acces the current frame on which the ImageFilter was applied.
        /// </summary>
        Mat CurrentFrame
        {
            get;
            set;
        } 
        #endregion

        #region Methods

        /// <summary>
        /// Runs the Filter Algorithm and returns itself.
        /// </summary>
        /// <param name="source"> Runs the algorithm on this object.</param>
        /// <returns></returns>
        IImageFilter Process(IImageFilter source);

        #endregion

    }
}
