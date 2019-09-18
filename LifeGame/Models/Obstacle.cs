using static LifeGame.Constants.Constants;

namespace LifeGame.Models
{
    public class Obstacle : Cell
    {
        public Obstacle()
        {
            Image = DefaultObstacleImage;
        }
        public Obstacle(int x, int y) : base(x, y)
        {
            Image = DefaultObstacleImage;
        }
    }
}
