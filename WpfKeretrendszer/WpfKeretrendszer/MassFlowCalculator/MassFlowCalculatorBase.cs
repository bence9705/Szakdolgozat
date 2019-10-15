using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WpfKeretrendszer.MassFlowCalculator
{
    public abstract class MassFlowCalculatorBase : IMassFlowCalculator
    {
        #region Attributes
        private double massFlow;
        #endregion

        #region Properties
        public double MassFlow
        {
            get { return massFlow; }
            set { massFlow = value; }
        }
        #endregion

        #region Methods
        public abstract double Calculate(Mat image); 
        #endregion
    }
}
