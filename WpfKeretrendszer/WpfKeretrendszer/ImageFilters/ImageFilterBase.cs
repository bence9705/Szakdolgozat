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
    /// Abstract Base class for the ImageFilters.
    /// </summary>
    public abstract class ImageFilterBase : IImageFilter
    {
        #region Attributes
        private Mat currentFrame;
        #endregion

        #region Properties
        public Mat CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        #endregion

        #region Methods
        public abstract Mat GetCurrentFrame();
        public abstract int GetParticleNumber();
        public abstract IImageFilter Process(IImageFilter source);
        public abstract double GetMassFlow();
        #endregion

    }
}
