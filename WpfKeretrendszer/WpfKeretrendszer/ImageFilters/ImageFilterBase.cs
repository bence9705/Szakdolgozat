using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSubTypes;
using Newtonsoft.Json;
using OpenCvSharp;
using WpfKeretrendszer.MassFlowCalculator;
using WpfKeretrendszer.ParticleCalculator;


namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// Abstract Base class for the ImageFilters.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "subclass")]
    [JsonSubtypes.KnownSubType(typeof(DefaultFilter), "default")]
    public abstract class ImageFilterBase : IImageFilter
    {
        #region Attributes
        private Mat currentFrame;
        #endregion

        #region Properties
        [JsonIgnore]
        public Mat CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        #endregion

        #region Methods
        public abstract IImageFilter Process(IImageFilter source);
        #endregion

    }
}
