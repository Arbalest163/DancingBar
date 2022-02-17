using System;
using System.Drawing;
using System.Windows.Forms;

namespace DancingBar
{
    public partial class CustomVerticalProgressBar : UserControl
    {
        private int _refValue;
        public int Value { get; set; }
        public Color Color { get; set; } = Color.Green;
        public int MaxValue { get; set; } = 100;
        public int RectangleSize { get; set; } = 30;
        public CustomVerticalProgressBar()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void CustomVerticalProgressVar_Paint(object sender, PaintEventArgs e)
        {
            int y = Height;

            for (int i = 0; i <= (_refValue * Height / MaxValue) / RectangleSize; i++)
            {
                CreateGraphics().FillRectangle(new SolidBrush(Color), new RectangleF(1, y, Width - 1, RectangleSize - 2));
                y -= RectangleSize;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_refValue != Value)
            {
                _refValue = Value;
                Refresh();
            }
        }
    }
}
