using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChart
{
    public class MyChartValues
    {
        public string Label { get; set; }
        public float Value { get; set; }

        public MyChartValues(string label, float value)
        {
            Label = label;
            Value = value;
        }
    }
}
