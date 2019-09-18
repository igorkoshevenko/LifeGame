using System.Collections.Generic;
using LifeGame.Models;

namespace LifeGame.Ocean
{
    public interface ICellContainer
    {
        Cell GetNorthEastCell(Cell cell);
        Cell GetNorthWestCell(Cell cell);
        Cell GetSouthEastCell(Cell cell);
        Cell GetSouthWestCell(Cell cell);
        Cell GetSouthCell(Cell cell);
        Cell GetEastCell(Cell cell);
        Cell GetWestCell(Cell cell);
        Cell GetNorthCell(Cell cell);

        List<Cell> GetNeighbors(Cell cell);
        List<Cell> GetEmptyNeighborCells(Cell cell);
        List<Cell> GetPreyNeighborCells(Cell cell);
        Cell GetEmptyNeighborCell(Cell cell);
        Cell GetPreyNeighborCell(Cell cell);
        Cell GetCellAt(int a, int b);
        Cell[,] InitializeField();
        void AddEmptyCells();
        void AddEntityCells<T>(int number) where T : Cell, new();

        void Reproduce<T>(T cell, ref int quantity) where T : Cell, new();
        void MoveFrom<T>(T from, Cell to) where T : Cell, new();
        void Process<T>(T cell) where T : Cell, new();
    }
}
