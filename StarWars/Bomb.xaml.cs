using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarWars
{
    /// <summary>
    /// Логика взаимодействия для Bomb.xaml
    /// </summary>
    public partial class Bomb : UserControl
    {
        public bool IsBam = false;


        public Bomb()
        {
            InitializeComponent();
        }

        public bool IsHit(Rectangle Gun)
        {
            if ((Canvas.GetLeft(this) <= Canvas.GetLeft(Gun) + Gun.Width && Canvas.GetLeft(this) + Width >= Canvas.GetLeft(Gun)) &&
                (Canvas.GetTop(this) <= Canvas.GetTop(Gun) - Gun.Height && Canvas.GetTop(this) + Height >= Canvas.GetTop(Gun)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
