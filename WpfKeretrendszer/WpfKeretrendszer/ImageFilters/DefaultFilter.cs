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
    /// It does nothing with the proccessed frame.
    /// </summary>
    public class DefaultFilter : ImageFilterBase
    {
        #region Methods
        public override Mat GetCurrentFrame()
        {
            return CurrentFrame;
        }

        public override int GetParticleNumber()
        {
            throw new ArgumentException("This filter has no ParticleCalculator!");
        }

        public override IImageFilter Process(IImageFilter source)
        {
            CurrentFrame = source.GetCurrentFrame();

            return this;
        }
        public override double GetMassFlow()
        {
            throw new ArgumentException("This filter has no MassFlowCalculator!");
        }
        #endregion
    }

}
