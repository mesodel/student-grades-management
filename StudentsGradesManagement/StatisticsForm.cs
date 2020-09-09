using MyChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsGradesManagement
{
    public partial class StatisticsForm : Form
    {
        private MyChartValues[] _values;

        public StatisticsForm(MyChartValues[] values)
        {
            _values = values;
            InitializeComponent();
        }

    }
}
