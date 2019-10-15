using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using WpfKeretrendszer.ImageFilters;
using System.IO;

namespace WpfKeretrendszer.PipeLine
{
    interface IPipeLine
    {
        #region Methods
        /// <summary>
        /// Runs every ImageFilter's Process function.
        /// </summary>
        void Process();

        /// <summary>
        /// Returns the displayer ImageFilter's currentframe
        /// </summary>
        Mat Display();

        /// <summary>
        /// Calculates the mass flow from the source IIF.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        double GetMassFlow(IImageFilter source);

        /// <summary>
        /// Adds the ImageFilter to the pipeline.
        /// </summary>
        /// <param name="filter"></param>
        void AddFilter(IImageFilter filter);

        /// <summary>
        /// Load saved PipeLine from a file.
        /// TODO: what kind of File? 
        /// </summary>
        /// <param name="source"></param>
        void LoadPipeLine(string source);

        /// <summary>
        /// Saves PipeLine to the location.
        /// </summary>
        void SavePipeLine(string location);

        /// <summary>
        /// Loads a video file from location.
        /// </summary>
        /// <param name="location"></param>
        void LoadVideo(string location);
        #endregion

    }
}
