using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSim2021
{
    public class IndexedValueView
    {
        IndexedValue indVal;
        bool available;
        Point point;
        Size size;
        Color color;
        Rectangle rect;

        public IndexedValueView(IndexedValue iV, Point p, Size s, Color c)
        {
            indVal = iV;
            point = p;
            size = s;
            color = c;
            available = (bool) iV.Active;
        }

        public void draw(Graphics g)
        {
            int alpha;
            if ((bool)indVal.Active || available ) { alpha = 200; }
            else { alpha = 50; }
            color = Color.FromArgb(alpha, color.R, color.G, color.B);
            SolidBrush brush = new SolidBrush(color);
            Rectangle r = new Rectangle(point, size);
            rect = r;
            
            g.FillRectangle(brush, r);
            using (Font font2 = new Font("Arial", 8, FontStyle.Bold))
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                String str = indVal.Name + "\n\n" + indVal.MinValue + "  |    " + indVal.Value + "    |  " + indVal.MaxValue;
                
                g.DrawString(str, font2, new SolidBrush(Color.Gray), r, stringFormat);

            }
            
            Pen p = new Pen(color, 1);
            g.DrawRectangle(p, r);
            
        }

        public Rectangle getRectangle()
        {
            return rect;
        }

        public IndexedValue getIndexedValue()
        {
            return indVal;
        }

        public void CheckAvailable(int turn)
        {
            available = indVal.AvailableAt <= turn;
        }
    }
}
