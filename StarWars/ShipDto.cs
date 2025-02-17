using System.Windows.Media.Animation;

namespace StarWars
{
    public class ShipDto
    {
        private SpаceShip ship;
        private Storyboard storyboard;
        private bool placeOnRight;

        public ShipDto(SpаceShip ship, Storyboard storyboard, bool placeOnRight)
        {
            this.ship = ship;
            this.storyboard = storyboard;
            this.placeOnRight = placeOnRight;
        }

        public SpаceShip getShip()
        {
            return ship;
        }

        public Storyboard getStoryboard()
        {
            return storyboard;
        }

        public bool getPlaceOnRight()
        {
            return placeOnRight;
        }
    }
}
