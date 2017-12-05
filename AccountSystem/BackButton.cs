using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AccountSystem
{
    public class BackButton: Button
    {
        public BackButton() : base()
        {
            Background = (Brush) FindResource("MainBrush");
            BorderThickness = new System.Windows.Thickness(0);
            Content = FindResource("BackButtonImage");
        }
    }
}
