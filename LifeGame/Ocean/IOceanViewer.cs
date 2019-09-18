using System.Collections.Generic;
using LifeGame.Models;

namespace LifeGame.Ocean
{
    public interface IOceanViewer
    {
        Cell this[int index1, int index2] { get; }
        Dictionary<Cell[,], List<int>> GetOceanStates(int iteration);
        int QuantityOfPrey { get; set; }
        int QuantityOfPredators { get; set; }
        int QuantityOfObstacles { get; set; }
    }
}
