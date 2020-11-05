using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculate
{
    public static class EntropyCalculator
    {
        public static double calculate(double[] inp_arr) // a[4] !!!
        {
            return (inp_arr[0] + inp_arr[1] + inp_arr[2] + inp_arr[3]) / 4;
        }
    }
}
