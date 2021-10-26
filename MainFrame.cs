using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_APP
{
    public static class MainFrame
    {
        private static Frame frame;
        public static Frame GetFrame()
        {
            if(frame != null)
            {
                return frame;
            }
            else
            {
                frame = new Frame();
                return frame;
            }
        }
        public static void SetFrame(Frame _frame)
        {
            if (frame == null)
            {
                frame = _frame;
            }
        }
    }
}
