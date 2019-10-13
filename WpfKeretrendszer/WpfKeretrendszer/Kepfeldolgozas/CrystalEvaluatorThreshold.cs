using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKeretrendszer
{
    public class CrystalEvaluatorThreshold : CrystalEvaluatorBase
    {
        #region Properties
        private  int thresholdValue;
        private int maxBinaryValue;

        public int ThresholdValue { get => thresholdValue; set => thresholdValue = value; }
        public int MaxBinaryValue { get => maxBinaryValue; set => maxBinaryValue = value; }
        #endregion

        public CrystalEvaluatorThreshold(int threshValue, int maxBinaryValue)
        {
            ThresholdValue = threshValue;
            MaxBinaryValue = maxBinaryValue;
        }

        #region Methods
        public override Mat ProcessNextFrame(Mat image)
        {
            Mat temporary = new Mat();
            Cv2.CvtColor(image, temporary, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(temporary, temporary, thresholdValue, maxBinaryValue, ThresholdTypes.Binary);
            return temporary;
        }
        #endregion
    }
}
