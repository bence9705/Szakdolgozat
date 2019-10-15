using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using WpfKeretrendszer.ImageFilters;
using WpfKeretrendszer.MassFlowCalculator;
using WpfKeretrendszer.ParticleCalculator;

namespace WpfKeretrendszer.PipeLine
{
    public class BasicPipeLine : IPipeLine
    {
        #region Attributes
        private List<ImageFilterBase> pipeline = new List<ImageFilterBase>();

        private VideoCapture video = new VideoCapture();

        private IImageFilter displayer;
        #endregion

        #region Properties
        public VideoCapture Video
        {
            get { return video; }
            set { video = value; }
        }
        
        public IImageFilter Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor. Pipeline contains 1 DefaultFilter which is the displayer.
        /// </summary>
        public BasicPipeLine()
        {
            pipeline.Add(new DefaultFilter());
            displayer = pipeline[0];
        }

        /// <summary>
        /// Constructors with parameters.
        /// </summary>
        /// <param name="videoc"> Video to process.</param>
        /// <param name="imfc"> MassFlowCalculator class.</param>
        /// <param name="ipc"> ParticleCalculator class.</param>
        public BasicPipeLine(VideoCapture videoc) : this()
        {
        }
        #endregion

        #region Methods
        public void AddFilter(ImageFilterBase filter)
        {
            pipeline.Add(filter);
        }

        public Mat Display()
        {
            return displayer.GetCurrentFrame();
        }

        public double GetMassFlow(IImageFilter source)
        {
            return source.GetMassFlow();
        }

        public int GetParticleCount(IImageFilter source)
        {
            return source.GetParticleNumber();
        }

        public void LoadPipeLine(string source)
        {
            throw new NotImplementedException("Not Implemented yet!");
        }

        public void Process()
        {
            while (video.Read(pipeline[0].CurrentFrame))
            {
                //go through the pipeline
                for (int i = 0; i < pipeline.Count - 1; i++)
                {
                    pipeline[i + 1].Process(pipeline[i]);
                } 
            }
        }

        public void SavePipeLine(string location)
        {
            throw new NotImplementedException("Not Implemented yet!");
        }

        public void LoadVideo(string location)
        {
            video = new VideoCapture(location);
        }
    } 
    #endregion
}
