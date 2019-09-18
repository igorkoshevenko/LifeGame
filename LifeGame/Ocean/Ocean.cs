using System;
using System.Collections.Generic;
using System.Linq;
using LifeGame.Models;
using static LifeGame.Constants.Constants;


namespace LifeGame.Ocean
{

    public class Ocean  : ICellContainer, IOceanViewer
    {
        private readonly Random _random;

        private int _quantityOfPrey;
        private int _quantityOfPredators;
        private int _quantityOfObstacles;

        public int QuantityOfPrey
        {
            get => _quantityOfPrey;
            set => _quantityOfPrey = value;
        }

        public int QuantityOfPredators
        {
            get => _quantityOfPredators;
            set => _quantityOfPredators = value;
        }

        public int QuantityOfObstacles
        {
            get => _quantityOfObstacles;
            set => _quantityOfObstacles = value;
        }

        private Cell[,] _cells;
        public Cell this[int index1, int index2] => _cells[index1, index2];
        public Dictionary<Cell[,], List<int>> GetOceanStates(int iteration) 
        {
            var statesAndQuantities = new Dictionary<Cell[,] , List<int>>();
            _cells = InitializeField();
            var quantityOfEntities = new List<int> {_quantityOfPrey, _quantityOfPredators, _quantityOfObstacles, 0};
            statesAndQuantities.Add((Cell[,])_cells.Clone(), quantityOfEntities);

            for (var i = 0; i < iteration; i++)
            {
                for (var j = 0; j < MaxRows; j++)
                {
                    for (var k = 0; k < MaxColumns; k++)
                    {
                        Process(_cells[j, k]);
                    }
                }

                for (var j = 0; j < MaxRows; j++)
                {
                    for (var k = 0; k < MaxColumns; k++)
                    {
                        _cells[j, k].IsChanged = false;
                    }
                }

                quantityOfEntities = new List<int> {_quantityOfPrey, _quantityOfPredators, _quantityOfObstacles, i};
                statesAndQuantities.Add((Cell[,])_cells.Clone(), quantityOfEntities);

                if (_quantityOfPrey == 0 || _quantityOfPredators == 0)
                    break;
            }
            return statesAndQuantities;
        }
        public Ocean()
        {
            QuantityOfPrey = Constants.Constants.Prey;
            QuantityOfPredators = Predators;
            QuantityOfObstacles = Obstacles;
            _cells = new Cell[MaxRows, MaxColumns];
            _random = new Random();
        }
        public Cell[,] InitializeField()
        {
            AddEmptyCells();
            AddEntityCells<Obstacle>(Obstacles);
            AddEntityCells<Prey>(Constants.Constants.Prey);
            AddEntityCells<Predator>(Predators);
            return _cells;
        }
        public void AddEmptyCells()
        {
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }
        public void AddEntityCells<T>(int number) where T : Cell, new()
        {
            for (int i = 0; i < number; i++)
            {
                Cell c = new Cell();
                do
                {
                    int x = _random.Next(0, 25);
                    int y = _random.Next(0, 70);
                    if (_cells[x, y].GetType().Name == "Cell")
                    {
                        _cells[x, y] = new T { X = x, Y = y };
                        c = _cells[x, y];
                    }
                } while (c.GetType().Name == "Cell");
            }
        }

        #region Process

        public void Process<T>(T cell) where T : Cell, new()
        {
            if (!cell.IsChanged)
            {
                if (cell.GetImage == "@")
                {
                    if (cell.TimeToFeed == 0)
                    {
                        _cells[cell.X, cell.Y] = new Cell(cell.X, cell.Y);
                        --_quantityOfPredators;
                    }
                    else
                    {
                        if (GetPreyNeighborCells(cell).Count != 0)
                        {
                            var preyNeighborCell = GetPreyNeighborCell(cell);
                            _cells[preyNeighborCell.X, preyNeighborCell.Y] = new Cell(preyNeighborCell.X, preyNeighborCell.Y);
                            _cells[cell.X, cell.Y].TimeToFeed = TimeToFeed;
                            --_cells[cell.X, cell.Y].TimeToReproduce;
                            --_quantityOfPrey;
                        }
                        else
                        {
                            --cell.TimeToFeed;
                            --cell.TimeToReproduce;
                            MoveFrom(cell, GetEmptyNeighborCell(cell));
                        }
                        Reproduce(cell, ref _quantityOfPredators);
                    }
                }

                if (cell.GetImage == "*")
                {
                    --cell.TimeToReproduce;
                    MoveFrom(cell, GetEmptyNeighborCell(cell));
                    Reproduce(cell, ref _quantityOfPrey);
                }
            }
        }
        public void Reproduce<T>(T cell, ref int quantity) where T : Cell, new()
        {
            if (cell.TimeToReproduce != 0) return;
            var emptyCell = GetEmptyNeighborCell(cell);
            if (emptyCell == null) return;

            if (cell.GetImage == "@")
            {
                _cells[emptyCell.X, emptyCell.Y] = new Predator(emptyCell.X, emptyCell.Y) { IsChanged = true };
            }

            if (cell.GetImage == "*")
            {
                _cells[emptyCell.X, emptyCell.Y] = new Prey(emptyCell.X, emptyCell.Y) { IsChanged = true };
            }

            _cells[cell.X, cell.Y].TimeToReproduce = TimeToReproduce;
            ++quantity;
        }
        public void MoveFrom<T>(T from, Cell to) where T : Cell, new()
        {
            if (to == null) return;
            var xCoordinateToMove = to.X;
            var yCoordinateToMove = to.Y;
            var xCoordinateFromMove = from.X;
            var yCoordinateFromMove = from.Y;
            _cells[xCoordinateToMove, yCoordinateToMove] = from;
            _cells[xCoordinateToMove, yCoordinateToMove].X = xCoordinateToMove;
            _cells[xCoordinateToMove, yCoordinateToMove].Y = yCoordinateToMove;
            _cells[xCoordinateToMove, yCoordinateToMove].TimeToFeed = from.TimeToFeed;
            _cells[xCoordinateToMove, yCoordinateToMove].TimeToReproduce = from.TimeToReproduce;
            _cells[xCoordinateToMove, yCoordinateToMove].IsChanged = true;
            _cells[xCoordinateFromMove, yCoordinateFromMove] = new Cell(xCoordinateFromMove, yCoordinateFromMove);
        }

        #endregion

        #region Cell methods
        public List<Cell> GetNeighbors(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();
            if (GetWestCell(cell) != null) { neighbors.Add(GetWestCell(cell)); }
            if (GetEastCell(cell) != null) { neighbors.Add(GetEastCell(cell)); }
            if (GetNorthCell(cell) != null) { neighbors.Add(GetNorthCell(cell)); }
            if (GetSouthCell(cell) != null) { neighbors.Add(GetSouthCell(cell)); }
            if (GetNorthEastCell(cell) != null) { neighbors.Add(GetNorthEastCell(cell)); }
            if (GetNorthWestCell(cell) != null) { neighbors.Add(GetNorthWestCell(cell)); }
            if (GetSouthEastCell(cell) != null) { neighbors.Add(GetSouthEastCell(cell)); }
            if (GetSouthWestCell(cell) != null) { neighbors.Add(GetSouthWestCell(cell)); }
            return neighbors;
        }
        public List<Cell> GetEmptyNeighborCells(Cell cell)
        {
            return GetNeighbors(cell).Where(x => x.GetType().Name == "Cell").ToList();
        }
        public List<Cell> GetPreyNeighborCells(Cell cell)
        {
            return GetNeighbors(cell).Where(x => x.GetType().Name == "Prey").ToList();
        }
        public Cell GetEmptyNeighborCell(Cell cell)
        {
            var emptyNeighborCells = GetEmptyNeighborCells(cell);
            return emptyNeighborCells.Count != 0 ? emptyNeighborCells[_random.Next(0, emptyNeighborCells.Count - 1)] : null;
        }
        public Cell GetPreyNeighborCell(Cell cell)
        {
            var preyNeighborCells = GetPreyNeighborCells(cell);
            return preyNeighborCells.Count != 0 ? preyNeighborCells[_random.Next(0, preyNeighborCells.Count - 1)] : null;
        }

        public Cell GetCellAt(int a, int b)
        {
            if (a < 0 || a > MaxRows - 1 || b < 0 || b > MaxColumns - 1)
                return null;
            return _cells[a, b];
        }
       

        #endregion

        #region Search methods
        public Cell GetNorthCell(Cell cell)
        {
            return cell.X > 0 ? _cells[cell.X - 1, cell.Y] : null;
        }

        public Cell GetWestCell(Cell cell)
        {
            return cell.Y > 0 ? _cells[cell.X, cell.Y - 1] : null;
        }

        public Cell GetEastCell(Cell cell)
        {
            return cell.Y < MaxColumns - 2 ? _cells[cell.X, cell.Y + 1] : null;
        }

        public Cell GetSouthCell(Cell cell)
        {
            return cell.X < MaxRows - 2 ? _cells[cell.X + 1, cell.Y] : null;
        }

        public Cell GetSouthWestCell(Cell cell)
        {
            return cell.X < MaxRows - 2 & cell.Y > 0 ? _cells[cell.X + 1, cell.Y - 1] : null;
        }

        public Cell GetSouthEastCell(Cell cell)
        {
            return cell.X < MaxRows - 2 & cell.Y < MaxColumns - 2 ? _cells[cell.X + 1, cell.Y + 1] : null;
        }

        public Cell GetNorthWestCell(Cell cell)
        {
            return cell.X > 0 & cell.Y > 0 ? _cells[cell.X - 1, cell.Y - 1] : null;
        }

        public Cell GetNorthEastCell(Cell cell)
        {
            return cell.X > 0 & cell.Y < MaxColumns - 2 ? _cells[cell.X - 1, cell.Y + 1] : null;
        }

        #endregion
    }
}
