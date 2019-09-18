using static LifeGame.Constants.Constants;

namespace LifeGame.Models
{
    public class Prey : Cell
    {
        public Prey()
        {
            Image = DefaultPreyImage;
            TimeToReproduce = Constants.Constants.TimeToReproduce;
        }
        public Prey(int x, int y) : base(x, y)
        {
            Image = DefaultPreyImage;
            TimeToReproduce = Constants.Constants.TimeToReproduce;
        }
    }
}
