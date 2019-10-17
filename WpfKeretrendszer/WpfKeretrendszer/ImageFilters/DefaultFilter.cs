using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenCvSharp;
using WpfKeretrendszer.MassFlowCalculator;
using WpfKeretrendszer.ParticleCalculator;

namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// It does nothing with the proccessed frame.
    /// </summary>
    public class DefaultFilter : ImageFilterBase , IDisplayableImageFilter
    {
        #region Methods

        public override IImageFilter Process(IImageFilter source)
        {
            CurrentFrame = source.CurrentFrame;

            return this;
        }

        public string DisplayType()
        {
            return "Video without filter";
        }

        public Mat Display()
        {
            return CurrentFrame;
        }
        #endregion
    }

}
