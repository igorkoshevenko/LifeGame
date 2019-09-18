using static LifeGame.Constants.Constants;

namespace LifeGame.Models
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int TimeToReproduce { get; set; }
        public int TimeToFeed { get; set; }

        protected string Image;

        public bool IsChanged = false;

        public string GetImage
        {
            get => Image;
            set => Image = value;
        }

        public Cell()
        {
            Image = DefaultImage;
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Image = DefaultImage;
        }

    }
}
