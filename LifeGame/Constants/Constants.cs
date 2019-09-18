namespace LifeGame.Constants
{
    public static class Constants
    {
        #region Board

        public const int MaxRows = 25;
        public const int MaxColumns = 70;

        #endregion

        #region DefaultNumberOfEntities

        public const int Obstacles = 75;
        public const int Predators = 20;
        public const int Prey = 150;
        public const int Iterations = 1000;

        #endregion

        #region DefaultImageOfEntities

        public const string DefaultImage = "-";
        public const string DefaultObstacleImage = "|";
        public const string DefaultPreyImage = "*";
        public const string DefaultPredatorImage = "@";

        #endregion

        #region TimeConstans

        public const int TimeToReproduce = 6;
        public const int TimeToFeed = 6;

        #endregion
    }
}
