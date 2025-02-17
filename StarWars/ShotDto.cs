using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StarWars
{
    public class ShotDto
    {
        private Rectangle shot;
        private Storyboard storyboard;

        public ShotDto(Rectangle shot, Storyboard storyboard)
        {
            this.shot = shot;
            this.storyboard = storyboard;
        }

        public Rectangle getShot()
        {
            return shot;
        }

        public Storyboard getStoryboard() {
            return storyboard;
        }
    }
}
