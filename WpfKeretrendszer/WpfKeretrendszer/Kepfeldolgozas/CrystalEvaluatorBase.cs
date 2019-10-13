using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKeretrendszer
{
    public class CrystalEvaluatorBase
    {

        #region Methods

        public virtual Mat ProcessNextFrame(Mat image)
        {
            return new Mat();
        }

        public virtual void GetSizeHistogram()
        {

        }

        #endregion

    }


}
