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

        #region Currently unnecessary
        ///// <summary>
        ///// Calculates the mass flow from the source IIF.
        ///// </summary>
        ///// <param name="source"> ImageFilter object from which it takes the neccessary data. (i.e.: particle number)</param>
        ///// <returns></returns>
        //double GetMassFlow(IImageFilter source);

        ///// <summary>
        ///// Calculates the mass flow from the source IIF.
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //int GetParticleCount(IImageFilter source);
        #endregion


        /// <summary>
        /// Adds the ImageFilter to the pipeline.
        /// </summary>
        /// <param name="filter"></param> 
        void AddFilter(ImageFilterBase filter);

        /// <summary>
        /// Load saved PipeLine from a file.
        /// TODO: what kind of File? 
        /// </summary>
        /// <param name="filename"> Name of the pipeline</param>
        void LoadPipeLine(string filename);

        /// <summary>
        /// Saves PipeLine with name.
        /// </summary>
        /// <param name="source"> Name of the saved pipeline.</param>
        void SavePipeLine(string filename);

        #endregion

    }
}
