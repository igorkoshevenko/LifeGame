using LifeGame.Models;
using LifeGame.Ocean;
using Xunit;

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
