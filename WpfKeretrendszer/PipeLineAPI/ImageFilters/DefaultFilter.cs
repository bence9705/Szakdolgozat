using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// It does nothing with the proccessed frame.
    /// </summary>
    public class DefaultFilter : ImageFilterBase
    {
        #region Methods
        public override Mat GetCurrentFrame()
        {
            return CurrentFrame;
        }

        public override int GetParticleNumber(Mat source)
        {
            //TODO: implement Particle Calculator Base class
            return -1;
        }

        public override ImageFilterBase Process(ImageFilterBase source)
        {
            CurrentFrame = source.GetCurrentFrame();

            return this;
        }
        #endregion
    }

}
