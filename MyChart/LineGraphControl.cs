using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChart
{
    public partial class LineGraphControl : UserControl
    {
        public MyChartValues[] Data { get; set; }

        public LineGraphControl()
        {
            InitializeComponent();

            ResizeRedraw = true;

            Data = new[]
            {
                new MyChartValues("2015", 5),
                new MyChartValues("2016", 6),
                new MyChartValues("2017", 7.5f)
            };
        }

        public LineGraphControl(MyChartValues[] data)
        {
            InitializeComponent();

            ResizeRedraw = true;

            Data = data;
        }

        private void LineGraphControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clipRectangle = e.ClipRectangle;

            float scalingFactorX = (float)(clipRectangle.Width / Data.Length);
            float scalingFactorY = (float)(clipRectangle.Height / 10);

            Pen pen = new Pen(new SolidBrush(Color.Black));

            graphics.DrawLine(pen, 0, 0, 0, clipRectangle.Height);
            graphics.DrawLine(pen, 0, clipRectangle.Height - 0.5f, clipRectangle.Width - 0.5f, clipRectangle.Height - 0.5f);

            for(int i=0; i<Data.Length-1; i++)
            {
                graphics.DrawLine(pen, 
                    i * scalingFactorX, 
                    clipRectangle.Height - (Data[i].Value * scalingFactorY), 
                    (i + 1) * scalingFactorX, 
                    clipRectangle.Height - (Data[i + 1].Value * scalingFactorY));
            }
        }
    }
}
