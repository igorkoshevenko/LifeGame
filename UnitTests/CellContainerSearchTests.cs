using LifeGame.Models;
using Xunit;

namespace UnitTests
{
    public class CellContainerSearchTests : BaseTestClass
    {

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 30)]
        [InlineData(24, 69)]
        public void GetCellAt_CoordinatesOfTheCell_ShouldReturnCell(int x, int y)
        {
            var cell = CellContainer.GetCellAt(x, y);
            Assert.NotNull(cell);
            Assert.Equal(x, cell.X);
            Assert.Equal(y, cell.Y);
            //Assert.True(x == cell.X, $"X coordinate {x} in cell incorrect {cell.X}");
            //Assert.True(y == cell.Y, $"Y coordinate {y} in cell incorrect {cell.Y}");
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(25, 70)]
        public void GetCellAt_CoordinatesOfTheCell_ShouldReturnNullCell(int x, int y)
        {
            var cell = CellContainer.GetCellAt(x, y);
            Assert.Null(cell);
        }


        [Fact]
        public void GetNorthCell_CoordinatesOfTheCell_ShouldReturnNorthCell()
        {
            var cell = new Cell(1, 1);
            var northCell = CellContainer.GetNorthCell(cell);
            Assert.Equal(cell.X - 1, northCell.X);
            Assert.Equal(cell.Y, northCell.Y);
        }

        [Fact]
        public void GetNorthCell_CoordinatesOfTheCell_ShouldReturnNullNorthCell()
        {
            var cell = new Cell(0, 1);
            var northCell = CellContainer.GetNorthCell(cell);
            Assert.Null(northCell);
        }


        [Fact]
        public void GetNorthWestCell_CoordinatesOfTheCell_ShouldReturnNorthWestCell()
        {
            var cell = new Cell(1, 1);
            var northWestCell = CellContainer.GetNorthWestCell(cell);
            Assert.Equal(cell.X - 1, northWestCell.X);
            Assert.Equal(cell.Y - 1, northWestCell.Y);
        }

        [Fact]
        public void GetNorthWestCell_CoordinatesOfTheCell_ShouldReturnNullNorthWestCell()
        {
            var cell = new Cell(0, 0);
            var northWestCell = CellContainer.GetNorthWestCell(cell);
            Assert.Null(northWestCell);
        }


        [Fact]
        public void GetNorthEastCell_CoordinatesOfTheCell_ShouldReturnNorthEastCell()
        {
            var cell = new Cell(1, 1);
            var northEastCell = CellContainer.GetNorthEastCell(cell);
            Assert.Equal(cell.X - 1, northEastCell.X);
            Assert.Equal(cell.Y + 1, northEastCell.Y);
        }

        [Fact]
        public void GetNorthWestCell_CoordinatesOfTheCell_ShouldReturnNullNorthEastCell()
        {
            var cell = new Cell(0, 69);
            var northEastCell = CellContainer.GetNorthWestCell(cell);
            Assert.Null(northEastCell);
        }



        [Fact]
        public void GetSouthCell_CoordinatesOfTheCell_ShouldReturnSouthCell()
        {
            var cell = new Cell(1, 1);
            var south = CellContainer.GetSouthCell(cell);
            Assert.Equal(cell.X + 1, south.X);
            Assert.Equal(cell.Y, south.Y);
        }

        [Fact]
        public void GetSouthCell_CoordinatesOfTheCell_ShouldReturnNullSouthCell()
        {
            var cell = new Cell(24, 1);
            var southCell = CellContainer.GetSouthCell(cell);
            Assert.Null(southCell);
        }


        [Fact]
        public void GetSouthWestCell_CoordinatesOfTheCell_ShouldReturnSouthWestCell()
        {
            var cell = new Cell(1, 1);
            var southWestCell = CellContainer.GetSouthWestCell(cell);
            Assert.Equal(cell.X + 1, southWestCell.X);
            Assert.Equal(cell.Y - 1, southWestCell.Y);
        }

        [Fact]
        public void GetSouthWestCell_CoordinatesOfTheCell_ShouldReturnNullSouthWestCell()
        {
            var cell = new Cell(0, 0);
            var southWestCell = CellContainer.GetSouthWestCell(cell);
            Assert.Null(southWestCell);
        }


        [Fact]
        public void GetSouthEastCell_CoordinatesOfTheCell_ShouldReturnSouthEastCell()
        {
            var cell = new Cell(1, 1);
            var southEastCell = CellContainer.GetSouthEastCell(cell);
            Assert.Equal(cell.X + 1, southEastCell.X);
            Assert.Equal(cell.Y + 1, southEastCell.Y);
        }

        [Fact]
        public void GetSouthEastCell_CoordinatesOfTheCell_ShouldReturnNullSouthEastCell()
        {
            var cell = new Cell(24, 69);
            var southEastCell = CellContainer.GetSouthEastCell(cell);
            Assert.Null(southEastCell);
        }



        [Fact]
        public void GetEastCell_CoordinatesOfTheCell_ShouldReturnEastCell()
        {
            var cell = new Cell(1, 1);
            var eastCell = CellContainer.GetEastCell(cell);
            Assert.Equal(cell.X, eastCell.X);
            Assert.Equal(cell.Y + 1, eastCell.Y);
        }

        [Fact]
        public void GetEastCell_CoordinatesOfTheCell_ShouldReturnNullEastCell()
        {
            var cell = new Cell(1, 69);
            var eastCell = CellContainer.GetEastCell(cell);
            Assert.Null(eastCell);
        }



        [Fact]
        public void GetWestCell_CoordinatesOfTheCell_ShouldReturnWestCell()
        {
            var cell = new Cell(1, 1);
            var westCell = CellContainer.GetWestCell(cell);
            Assert.Equal(cell.X, westCell.X);
            Assert.Equal(cell.Y - 1, westCell.Y);
        }

        [Fact]
        public void GetWestCell_CoordinatesOfTheCell_ShouldReturnNullWestCell()
        {
            var cell = new Cell(1, 0);
            var westCell = CellContainer.GetWestCell(cell);
            Assert.Null(westCell);
        }



    }
}
