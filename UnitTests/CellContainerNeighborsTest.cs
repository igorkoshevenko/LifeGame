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
        public void GetCellNeighbors_CoordinatesOfTheCell_ShouldReturnCellNeighbors(int x, int y, int quantityOfNeighbors)
        {
            var cell = new Cell(x, y);
            var actualQuantityOfEntities = CellContainer.GetNeighbors(cell).Count;
            Assert.Equal(quantityOfNeighbors, actualQuantityOfEntities);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(24, 69)]
        public void GetEmptyCellNeighbors_CoordinatesOfTheCell_ShouldReturnEmptyCellNeighbors(int x, int y)
        {
            var cell = new Cell(x, y);
            var expectedResult = CellContainer.GetNeighbors(cell).Where(c => c.GetType().Name == "Cell").ToList().Count;
            var actualResult = CellContainer.GetEmptyNeighborCells(cell).Count;
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(24, 69)]
        public void GetPreyCellNeighbors_CoordinatesOfTheCell_ShouldReturnPreyCellNeighbors(int x, int y)
        {
            var cell = new Cell(x, y);
            var expectedResult = CellContainer.GetNeighbors(cell).Where(c => c.GetType().Name == "Prey").ToList().Count;
            var actualResult = CellContainer.GetPreyNeighborCells(cell).Count;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void InitializeOcean_ShouldInitializeOceanField()
        {
            var oceanField = CellContainer.InitializeField();
            Assert.NotNull(oceanField);
        }

        [Theory]
        [InlineData("Prey", Constants.Prey)]
        [InlineData("Predator", Predators)]
        [InlineData("Obstacle", Obstacles)]
        public void GetQuantityOfEntities_QuantityOfEntities_ShouldInitializeQuantityOfEntitiesInOcean(string typeOfEntity, int expectedQuantity)
        {
            var actualQuantity = 0;
            var oceanField = CellContainer.InitializeField();

            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    if (oceanField[i, j].GetType().Name == typeOfEntity)
                    {
                        actualQuantity++;
                    }
                }
            }
            Assert.Equal(expectedQuantity, actualQuantity);
        }
    }
}
