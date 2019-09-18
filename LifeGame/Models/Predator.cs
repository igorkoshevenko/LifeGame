using static LifeGame.Constants.Constants;

namespace LifeGame.Models
{
    public class Predator : Prey
    {
        public Predator()
        {
            Image = DefaultPredatorImage;
            TimeToFeed = Constants.Constants.TimeToFeed;
        }
        public Predator(int x, int y) : base(x, y)
        {
            Image = DefaultPredatorImage;
            TimeToFeed = Constants.Constants.TimeToFeed;
        }
    }
}
