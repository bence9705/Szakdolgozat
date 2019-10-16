using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.ImageFilters
{
    public interface IDisplayableImageFilter
    {
        string DisplayType();

         Mat Display();
    }
}
