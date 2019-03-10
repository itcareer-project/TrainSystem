using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainSystemApp
{
    class iTax
    {
        public double mcTax_Rate = 0.05;

        public Double iFindTax(double icAmount)
        {
            double findTax = icAmount - (icAmount * mcTax_Rate);
            return findTax;
        }
    }
}
