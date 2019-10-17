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
using Newtonsoft;
using Newtonsoft.Json;

namespace WpfKeretrendszer.PipeLine
{
    public class BasicPipeLine : IPipeLine
    {
        #region Attributes
        private List<ImageFilterBase> pipeline = new List<ImageFilterBase>();

        private IDisplayableImageFilter displayer;
        #endregion

        #region Properties
        /// <summary>
        /// ImageFilter used to Display the current frame.
        /// It is a DefaultImageFilter by default.
        /// </summary>
        public IDisplayableImageFilter Displayer
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
            displayer = (IDisplayableImageFilter)pipeline[0];
        }
        #endregion

        #region Methods
        public void AddFilter(ImageFilterBase filter)
        {
            pipeline.Add(filter);
        }

        public Mat Display()
        {
            return displayer.Display();
        }

        #region Currently unnecessary
        //public double GetMassFlow(IImageFilter source)
        //{
        //    return source.GetMassFlow();
        //}

        //public int GetParticleCount(IImageFilter source)
        //{
        //    return source.GetParticleNumber();
        //} 
        #endregion

        public void LoadPipeLine(string filename)
        {
            throw new NotImplementedException("Not Implemented yet!");
        }

        public void Process(Mat frame)
        {
            if (frame.Empty()) return;

            pipeline[0].CurrentFrame = frame;
            //go through the pipeline
            for (int i = 0; i < pipeline.Count - 1; i++)
            {
                pipeline[i + 1].Process(pipeline[i]);
            } 

        }

        public void SavePipeLine(string filename)
        {
            string file = @"./Profiles/" + filename +  ".json";

            using (StreamWriter sw = File.CreateText(file))
            {
                string json = JsonConvert.SerializeObject(pipeline, Formatting.Indented);
               
                JsonSerializer js = new JsonSerializer();
                js.Serialize(sw, pipeline);

                Console.Write(json); 
            }

        }


        #endregion
    }
}
