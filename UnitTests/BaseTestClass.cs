using LifeGame.Models;
using LifeGame.Ocean;

namespace UnitTests
{
    public class BaseTestClass 
    {
        protected ICellContainer CellContainer;
        protected IOceanViewer OceanViewer;
        protected Cell[,] Cells;

        public BaseTestClass()
        {
            CellContainer = new Ocean();
            OceanViewer = new Ocean();
            Cells = CellContainer.InitializeField();
        }

    }
}
