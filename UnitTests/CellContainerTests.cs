using LifeGame.Models;
using Xunit;

namespace UnitTests
{
    public class CellContainerTests : BaseTestClass
    {

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 30)]
        [InlineData(24, 69)]
        public void GetCell_Coordinates_ShouldReturnCellByCoordinates_Positive(int x, int y)
        {
            var cell = CellContainer.GetCellAt(x, y);
            Assert.NotNull(cell);
            //Assert.Equal(x, cell.X);
            //Assert.Equal(y, cell.Y);

            Assert.True(x == cell.X, $"X coordinate {x} in cell incorrect {cell.X}");
            Assert.True(y == cell.Y, $"Y coordinate {y} in cell incorrect {cell.Y}");
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(25, 70)]
        public void GetCell_Coordinates_ShouldReturnNull_Negative(int x, int y)
        {
            var cell = CellContainer.GetCellAt(x, y);
            Assert.Null(cell);
        }

        [Fact]
        public void GetCell_Coordinates_ShouldReturnNorthCell()
        {
            Cell cell = new Cell(1,1);
            var northCell = CellContainer.GetNorthCell(cell);
            Assert.NotNull(northCell);
        }

        [Fact]
        public void Get_ShouldReturnSouthCell()
        {
            Cell cell = new Cell(1, 1);
            var northCell = CellContainer.GetNorthCell(cell);
            Assert.NotNull(northCell);
        }

    }
}
