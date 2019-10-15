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
    public interface IPipeLine
    {
        #region Methods
        /// <summary>
        /// Runs every ImageFilter's Process function on the frame.
        /// </summary>
        void Process(Mat frame);

        /// <summary>
        /// Returns the displayer ImageFilter's currentframe.
        /// </summary>
        Mat Display();

        /// <summary>
        /// Calculates the mass flow from the source IIF.
        /// </summary>
        /// <param name="source"> ImageFilter object from which it takes the neccessary data. (i.e.: particle number)</param>
        /// <returns></returns>
        double GetMassFlow(IImageFilter source);

        /// <summary>
        /// Calculates the mass flow from the source IIF.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        int GetParticleCount(IImageFilter source);

        /// <summary>
        /// Adds the ImageFilter to the pipeline.
        /// </summary>
        /// <param name="filter"></param>
        void AddFilter(ImageFilterBase filter);

        /// <summary>
        /// Load saved PipeLine from a file.
        /// TODO: what kind of File? 
        /// </summary>
        /// <param name="source"> Location on hard drive from which it loads..</param>
        void LoadPipeLine(string source);

        /// <summary>
        /// Saves PipeLine to the location.
        /// </summary>
        /// /// <param name="source"> Location on hard drive to save config file.</param>
        void SavePipeLine(string location);

        #endregion

    }
}
