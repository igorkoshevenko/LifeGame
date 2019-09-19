using Xunit;
using LifeGame.Models;
using System.Linq;
using LifeGame.Constants;
using static LifeGame.Constants.Constants;

namespace UnitTests
{

    public class CellContainerNeighborsTest : BaseTestClass
    {
        [Theory]
        [InlineData(0, 0, 3)]
        [InlineData(1, 1, 8)]
        [InlineData(24, 69, 3)]
        public void GetCellNeighbors_Coordinate_ShouldReturnCellNeighbors(int x, int y, int quantityOfNeighbors)
        {
            var cell = new Cell(x, y);
            Assert.Equal(CellContainer.GetNeighbors(cell).Count, quantityOfNeighbors);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(24, 69)]
        public void GetEmptyCellNeighbors_Coordinate_ShouldReturnEmptyCellNeighbors(int x, int y)
        {
            var cell = new Cell(x, y);
            Assert.Equal(CellContainer.GetNeighbors(cell).Where(c => c.GetType().Name == "Cell").ToList().Count,
                CellContainer.GetEmptyNeighborCells(cell).Count);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(24, 69)]
        public void GetPreyCellNeighbors_Coordinate_ShouldReturnPreyCellNeighbors(int x, int y)
        {
            var cell = new Cell(x, y);
            Assert.Equal(CellContainer.GetNeighbors(cell).Where(c => c.GetType().Name == "Prey").ToList().Count,
                CellContainer.GetPreyNeighborCells(cell).Count);
        }

        [Fact]
        public void InitializeOcean()
        {
            var oceanField = CellContainer.InitializeField();
            Assert.NotNull(oceanField);
        }

        [Theory]
        [InlineData("Prey", Constants.Prey)]
        [InlineData("Predator", Predators)]
        [InlineData("Obstacle", Obstacles)]
        public void GetQuantityOfEntities_Quantity_CheckQuantityOfEntities(string typeOfEntity, int quantity)
        {
            var result = 0;
            var oceanField = CellContainer.InitializeField();

            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    if (oceanField[i,j].GetType().Name == typeOfEntity)
                    {
                        result++;
                    }
                }
            }
            Assert.Equal(quantity, result);
        }
    }
}
