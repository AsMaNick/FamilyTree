using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Family_Tree
{
    class Scroll
    {
        private int lastX, lastY;
        Timer timer;

        public Scroll()
        {
            lastX = -1;
            lastY = -1;
            timer = new Timer();
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            lastX = e.X;
            lastY = e.Y;
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (lastX != -1)
            {
                Panel parent = (Panel)sender;
                int oldX = -parent.AutoScrollPosition.X;
                int oldY = -parent.AutoScrollPosition.Y;
                int newX = oldX - (e.X - lastX);
                int newY = oldY - (e.Y - lastY);
                if (timer.getTime() > 20)
                {
                    timer.update();
                    parent.AutoScrollPosition = new Point(newX, newY);
                    lastX = e.X;
                    lastY = e.Y;
                    /*if (Math.Abs(newX - oldX) < Math.Abs(newY - oldY))
                    {
                        parent.AutoScrollPosition = new Point(oldX, newY);
                        lastY = e.Y;
                    }
                    else
                    {
                        parent.AutoScrollPosition = new Point(newX, oldY);
                        lastX = e.X;
                    }*/
                }
            }
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            lastX = -1;
            lastY = -1;
        }
    }
}

