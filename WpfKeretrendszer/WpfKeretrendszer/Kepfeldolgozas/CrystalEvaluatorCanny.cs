using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKeretrendszer
{
    public class CrystalEvaluatorCanny: CrystalEvaluatorBase
    {
        #region Properties
        private int highTreshold;
        private int lowThreshold;

        public int HighThreshold
        {
            get { return highTreshold; }
            set { highTreshold = value; }
        }


        public int LowThreshold
        {
            get { return lowThreshold; }
            set { lowThreshold = value; }
        }

        #endregion
        // Ez egy canny
        public CrystalEvaluatorCanny(int hiThreshold, int loThreshold)
        {
            HighThreshold = hiThreshold;
            LowThreshold = loThreshold;
        }

        #region Methods

        public override Mat ProcessNextFrame(Mat image)
        {
            Mat temporary = new Mat();
            Cv2.Canny(image, temporary, HighThreshold, LowThreshold);
            return temporary;
        }
        #endregion

    }
}
