using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.ImageFilters
{
    /// <summary>
    /// ImageFilter which implement this interface can be Displayed on the UI.
    /// </summary>
    public interface IDisplayableImageFilter
    {
        /// <summary>
        /// Makes easier to identify what you see.
        /// i.e.: Default filter: Video
        /// </summary>
        /// <returns></returns>
        string DisplayType();

        /// <summary>
        /// Returns the image you want to display. 
        /// i.e.: DefaultFilter: CurrentFrame; GraphFilter: Graph image.
        /// </summary>
        /// <returns></returns>
         Mat Display();
    }
}
