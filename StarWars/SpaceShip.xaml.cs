using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StarWars
{
    /// <summary>
    /// Логика взаимодействия для SpaceShip.xaml
    /// </summary>
    public partial class SpаceShip : UserControl
    {
        public double speed = 6;
        public bool destried = false;

        private DispatcherTimer bomdDropTimer;

        public SpаceShip()
        {
            InitializeComponent();
            bomdDropTimer = new DispatcherTimer();
            bomdDropTimer.Interval = TimeSpan.FromSeconds(BoomParameters.bomdDropTime);
            bomdDropTimer.Tick += drop_tick;
            bomdDropTimer.Start();
        }

        public bool IsHit(Rectangle shot)
        {
            if ((Canvas.GetLeft(this) <= Canvas.GetLeft(shot) + shot.Width && Canvas.GetLeft(this) + Width >= Canvas.GetLeft(shot)) &&
                (Canvas.GetTop(this) <= Canvas.GetBottom(shot) && Canvas.GetTop(this) + Height >= Canvas.GetBottom(shot) - shot.Height))
            {
                return true;
            } else {
                return false;
            }
        }

        public bool Cabum()
        {
            Random r = new Random();
            if (BoomParameters.chanceBam > r.Next(11)){
                return true;
            } else
            {
                return false;
            }
        }

        private void drop_tick(object sender, EventArgs e)
        {
            Canvas gameZone = (Canvas)Parent;
            if (!destried && gameZone != null)
            {
                if (Cabum())
                {
                    var bomb = new Bomb();
                    Canvas.SetTop(bomb, Canvas.GetTop(this) + Height);
                    Canvas.SetLeft(bomb, Canvas.GetLeft(this) + Width / 2);

                    Canvas.SetZIndex(bomb, 1);
                    gameZone.Children.Add(bomb);
                    MainWindow.bombs.Add(bomb);
                }
            }
        }
    }
}
