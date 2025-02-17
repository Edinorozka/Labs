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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace multiTexLabs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://www.bookvoed.ru/");
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.TryFindResource("StoryboardTextSwipe");
            storyboard.Begin();
        }

        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.TryFindResource("StoryboardTextAnimationFinish");
            storyboard.Begin();
        }

        private void Storyboard_Completed_2(object sender, EventArgs e)
        {
            Storyboard storyboard = (Storyboard)this.TryFindResource("StoryboardChangetext");
            storyboard.Begin();
        }
    }
}
