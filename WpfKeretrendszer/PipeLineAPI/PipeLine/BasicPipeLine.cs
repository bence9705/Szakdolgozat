using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using WpfKeretrendszer.ImageFilters;

namespace WpfKeretrendszer.PipeLine
{
    class BasicPipeLine : IPipeLine
    {
        #region Attributes
        private List<IImageFilter> pipeline = new List<IImageFilter>();

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

        #region Methods
        public void AddFilter(IImageFilter filter)
        {
            pipeline.Add(filter);
        }

        public Mat Display()
        {
            return displayer.GetCurrentFrame();
        }

        public double GetMassFlow(IImageFilter source)
        {
            throw new NotImplementedException("Not Implemented yet!");
        }

        public void LoadPipeLine(string source)
        {
            throw new NotImplementedException("Not Implemented yet!");
        }

        public void Process()
        {
            throw new NotImplementedException("Not Implemented yet!");
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
