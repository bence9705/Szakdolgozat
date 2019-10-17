using System;
using System.IO;
using WpfKeretrendszer;
using WpfKeretrendszer.PipeLine;
using WpfKeretrendszer.ImageFilters;
using OpenCvSharp;
using Test.TestHelperClasses;
using Test.TestClasses;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicPipeLine bpl = new BasicPipeLine();

            bpl.SavePipeLine("test");
        }
    }
}
