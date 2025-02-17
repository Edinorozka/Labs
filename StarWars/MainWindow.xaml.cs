using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StarWars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte lives;
        byte ticks = 0;
        private int points;
        private bool start = false;
        private double spawnShipTick = 6;

        private DispatcherTimer timer;
        private DispatcherTimer fastTimer;
        private DispatcherTimer shotTimer;
        private DispatcherTimer spawnShipTimer;
        private TimeSpan elapsedTime;

        private List<ShotDto> shots;
        private List<ShipDto> ships;
        public static List<Bomb> bombs;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            fastTimer = new DispatcherTimer();
            fastTimer.Interval = TimeSpan.FromMilliseconds(18);
            fastTimer.Tick += Fast_Tick;

            shotTimer = new DispatcherTimer();
            shotTimer.Interval = TimeSpan.FromSeconds(1.73);
            shotTimer.Tick += Shot;

            spawnShipTimer = new DispatcherTimer();
            spawnShipTimer.Interval = TimeSpan.FromSeconds(spawnShipTick);
            spawnShipTimer.Tick += spawn_tick;

            elapsedTime = TimeSpan.Zero;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks == 2) {
                ticks = 0;
                if(BoomParameters.chanceBam < 8)
                {
                    BoomParameters.chanceBam++;
                }
                if(BoomParameters.bomdDropTime > 1)
                {
                    BoomParameters.bomdDropTime -= 0.1;
                }
                if(spawnShipTick > 0.5)
                {
                    spawnShipTick -= 0.1;
                }
            }
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            Timer.Text = elapsedTime.ToString(@"mm\:ss");
        }

        private void Fast_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < shots.Count; ++i)
            {
                var shot = shots[i];
                for (int j = 0; j < ships.Count; ++j)
                {
                    var ship = ships[j];
                    if (ship.getShip().IsHit(shot.getShot()))
                    {
                        points += 1;
                        Size.Text = "сбито " + points;

                        Storyboard storyboard = ship.getShip().FindResource("DestroyStoryboard") as Storyboard;

                        storyboard.Completed += (s, args) => DestroyStoryboard_Completed(s, args, ship);
                        ship.getShip().destried = true;
                        storyboard.Begin();

                        GameZone.Children.Remove(shots[0].getShot());
                        shots.Remove(shots[0]);
                        ships.Remove(ships[j]);

                        i--;
                        j--;
                    }
                }
            }

            for (int i = 0; i < shots.Count; i++) {
                if (Canvas.GetBottom(shots[i].getShot()) < GameZone.Height)
                {
                    Canvas.SetBottom(shots[i].getShot(), Canvas.GetBottom(shots[i].getShot()) + 2.5);
                } else
                {
                    GameZone.Children.Remove(shots[i].getShot());
                    shots.Remove(shots[i]);
                    i--;
                }
            }

            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].getPlaceOnRight())
                {
                    if (Canvas.GetLeft(ships[i].getShip()) > 0)
                    {
                        Canvas.SetLeft(ships[i].getShip(), Canvas.GetLeft(ships[i].getShip()) - 1.7);
                    }
                    else
                    {
                        GameZone.Children.Remove(ships[i].getShip());
                        ships.Remove(ships[i]);
                        i--;
                    }
                }
                else {
                    if (Canvas.GetLeft(ships[i].getShip()) < GameZone.Width - ships[i].getShip().Width)
                    {
                        Canvas.SetLeft(ships[i].getShip(), Canvas.GetLeft(ships[i].getShip()) + 1.7);
                    }
                    else
                    {
                        GameZone.Children.Remove(ships[i].getShip());
                        ships.Remove(ships[i]);
                        i--;
                    }
                }
                
            }

            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].IsHit(Gun)){
                    bombs[i].IsBam = true;

                    timer.Stop();
                    shotTimer.Stop();
                    fastTimer.Stop();
                    spawnShipTimer.Stop();

                    lives -= 1;
                    Lives.Text = lives + " жизней";
                    if (lives == 0)
                    {
                        GameOver gameOver = new GameOver();
                        gameOver.ShowDialog();
                        InitializeTimer();
                        foreach (var shot in shots)
                        {
                            GameZone.Children.Remove(shot.getShot());
                        }
                        foreach (var ship in ships)
                        {
                            GameZone.Children.Remove(ship.getShip());
                        }
                        foreach (var bomb in bombs)
                        {
                            GameZone.Children.Remove(bomb);
                        }
                        ships = new List<ShipDto>();
                        shots = new List<ShotDto>();
                        bombs = new List<Bomb>();
                        start = false;

                    } else
                    {
                        Storyboard storyboard = bombs[i].FindResource("BamStoryboard") as Storyboard;

                        storyboard.Completed += (s, args) => BamStoryboard_Completed(s, args, bombs[0]);
                        storyboard.Begin();

                        Storyboard GunStoryboard = FindResource("ShotInGunStoryboard") as Storyboard;
                        GunStoryboard.Begin();
                    }
                }
                if (bombs.Count != 0)
                {
                    if (!bombs[i].IsBam)
                    {
                        if (Canvas.GetTop(bombs[i]) > 0)
                        {
                            Canvas.SetTop(bombs[i], Canvas.GetTop(bombs[i]) + 2);
                        }
                        else
                        {
                            GameZone.Children.Remove(bombs[i]);
                            bombs.Remove(bombs[i]);
                            i--;
                        }
                    }
                }
            }
        }

        private void BamStoryboard_Completed(object s, EventArgs args, Bomb bomb){
            GameZone.Children.Remove(bomb);
            bombs.Remove(bomb);
        }

        private void DestroyStoryboard_Completed(object s, EventArgs args, ShipDto ship)
        {
            GameZone.Children.Remove(ship.getShip());
        }

        private void Shot(object sender, EventArgs e)
        {
            Rectangle shot = new Rectangle
            {
                Stroke = Brushes.White,
                StrokeThickness = 2,
                Width = 2,
                Height = 5,
            };

            Canvas.SetLeft(shot, Canvas.GetLeft(Gun) + Gun.ActualWidth / 2);
            Canvas.SetBottom(shot, 12);
            GameZone.Children.Add(shot);

            Storyboard storyboard = new Storyboard();
            ShotDto dto = new ShotDto(shot, storyboard);
            shots.Add(dto);
        }

        private void spawn_tick(object sender, EventArgs e)
        {
            var ship = new SpаceShip();
            Random random = new Random();
            bool placeOnRight = random.NextDouble() >= 0.5;
            Storyboard storyboard = new Storyboard();
            Canvas.SetTop(ship, 3);

            if (placeOnRight)
            {
                Canvas.SetLeft(ship, GameZone.ActualWidth - ship.Width);
            }
            else
            {
                Canvas.SetLeft(ship, 0);

                RotateTransform rotateTransform = new RotateTransform(180);
                ship.RenderTransform = rotateTransform;
                ship.RenderTransformOrigin = new Point(0.5, 0.5);
            }
            GameZone.Children.Add(ship);
            ShipDto dto = new ShipDto(ship, storyboard, placeOnRight);
            ships.Add(dto);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double currentLeft = Canvas.GetLeft(Gun);

            switch (e.Key)
            {
                case Key.A:
                    if (Canvas.GetLeft(Gun) - 10 >= 0)
                    {
                        Canvas.SetLeft(Gun, currentLeft - 10);
                    }
                break;
                case Key.D:
                    if (currentLeft + Gun.Width + 10 <= GameZone.ActualWidth)
                    {
                        Canvas.SetLeft(Gun, currentLeft + 10);
                    }
                break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!start) {
                start = true;
                shots = new List<ShotDto>();
                ships = new List<ShipDto>();
                bombs = new List<Bomb>();
                lives = 5;
                points = 0;
                ticks = 0;
                BoomParameters.bomdDropTime = 3;
                BoomParameters.chanceBam = 2;
                Size.Text = "сбито " + points;
                Lives.Text = lives + " жизней";
                timer.Start();
                shotTimer.Start();
                fastTimer.Start();
                spawnShipTimer.Start();
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            timer.Start();
            fastTimer.Start();
            shotTimer.Start();
            spawnShipTimer.Start();
        }
    }
}
