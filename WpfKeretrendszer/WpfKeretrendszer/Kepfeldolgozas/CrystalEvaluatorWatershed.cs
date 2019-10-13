using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKeretrendszer.Kepfeldolgozas
{
    public class CrystalEvaluatorWatershed : CrystalEvaluatorBase
    {
        #region Properties
        private int thresholdValue;
        private int maxBinaryValue;
        private Size morphologyElementSize;
        private MatType morphologyElementType;
        private int morphologyIterations;

        public int ThresholdValue { get => thresholdValue; set => thresholdValue = value; }
        public int MaxBinaryValue { get => maxBinaryValue; set => maxBinaryValue = value; }
        public Size MorphologyElementSize { get => morphologyElementSize; set => morphologyElementSize = value; }
        public MatType MorphologyElementType { get => morphologyElementType; set => morphologyElementType = value; }
        public int MorphologyIterations { get => morphologyIterations; set => morphologyIterations = value; }
        #endregion

        public CrystalEvaluatorWatershed(int threshValue, int maxBinValue, Size morphElementSize, MatType morphElementType, int morphIterations)
        {
            ThresholdValue = threshValue;
            MaxBinaryValue = maxBinValue;
            MorphologyElementSize = morphElementSize;
            MorphologyElementType = morphElementType;
            MorphologyIterations = morphIterations;
        }

        #region Methods
        public override Mat ProcessNextFrame(Mat image)
        {
            //GREYSCALED IMAGE
            Mat greyscale = new Mat();
            Cv2.CvtColor(image, greyscale, ColorConversionCodes.BGR2GRAY);

            //BINARY AND INVERTED IMAGE
            Mat threshold = new Mat();
            Cv2.Threshold(greyscale, threshold, ThresholdValue, MaxBinaryValue, ThresholdTypes.BinaryInv);

            //MORPHOLOGY IMAGE (REMOVE WHITE NOISE)
            Mat morphology = new Mat();
            Mat element = new Mat(MorphologyElementSize, MorphologyElementType);
            Cv2.MorphologyEx(threshold, morphology, MorphTypes.Open, element, iterations: MorphologyIterations);

            //SURE BACKGROUND
            Mat sureBackground = new Mat();
            Mat ellipseElement = Cv2.GetStructuringElement(MorphShapes.Rect, MorphologyElementSize);
            morphologyIterations = 3;
            Cv2.Dilate(morphology, sureBackground, ellipseElement, iterations: morphologyIterations);

            //SURE FOREGROUND DISTANCE TRANSFORM AND NORMALIZE 
            Mat distanceTransform = new Mat();
            Cv2.DistanceTransform(morphology, distanceTransform, DistanceTypes.L1, DistanceMaskSize.Mask3);
            distanceTransform.ConvertTo(distanceTransform, MatType.CV_8U);

            //SURE FOREGROUND THRESHOLD
            Mat sureForeground = new Mat();
            ThresholdValue = 19;
            Cv2.Threshold(distanceTransform, sureForeground, ThresholdValue, maxBinaryValue, ThresholdTypes.Binary);

            //FIND UNKNOWN AREA
            Mat unknownArea = new Mat();
            Cv2.Subtract(sureBackground, sureForeground, unknownArea);

            //CREATE MARKERS FOR WATERSHED
            Mat markers = new Mat();
            Mat result = new Mat();
            Cv2.ConnectedComponents(sureForeground, markers);
            markers = markers + 1;
            markers = WatershedHelper.UnknownPixelSetToZero(unknownArea, markers);
            Cv2.Watershed(image, markers);


            //MAKE BORDERS IN IMAGE
            result = WatershedHelper.MarkBorders(markers, image);
            return result;

        }
        #endregion
    }
}
