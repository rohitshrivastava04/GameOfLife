using System;
using System.Collections.Generic;
using System.Linq;
using Mckinsey.GameOfLifeEngine.Base;

namespace Mckinsey.GameOfLifeEngine
{
    public class Grid : IGrid<ICell>
    {
        #region Fields

        private readonly ICell[,] _grid;

        #endregion

        #region Constructor

        public Grid(int numberOfRows, int numberOfColumns)
        {
            ValidateParams(numberOfRows, numberOfColumns);

            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            _grid = new ICell[numberOfRows, numberOfColumns]; //TODO:Eager Initialization, needs to be improved
        }

        #endregion

        #region Public

        /// <summary>
        /// gets cells contained in the grid
        /// </summary>
        public IEnumerable<ICell> Cells
        {
            //TODO:Need to think of a better way to do this 
            get { return _grid.Cast<ICell>().AsEnumerable(); }
        }

        /// <summary>
        /// gets number of rows in the grid
        /// </summary>
        public int NumberOfRows { get; private set; }

        /// <summary>
        /// gets the number of columns in the 
        /// grid
        /// </summary>
        public int NumberOfColumns { get; private set; }

        /// <summary>
        /// gets a cell from the grid by using
        /// its position - row and column index
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public ICell GetCellByIndex(int rowIndex, int columnIndex)
        {
            ValidateCellIndexes(rowIndex, columnIndex);

            return _grid[rowIndex, columnIndex];
        }

        /// <summary>
        /// Adds a cell to the grid
        /// </summary>
        /// <param name="cell"></param>
        public void AddCell(ICell cell)
        {
            ValidateCell(cell);

            _grid[cell.RowIndex, cell.ColIndex] = cell;
        }

        #endregion

        #region Private

        private static void ValidateParams(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows < 2)
            {
                throw new ArgumentOutOfRangeException("numberOfRows", "Cannot be less than 2");
            }

            if (numberOfColumns < 2)
            {
                throw new ArgumentOutOfRangeException("numberOfColumns", "Cannot be less than 2");
            }
        }

        private void ValidateCell(ICell cell)
        {
            if (cell == null)
            {
                throw new ArgumentNullException("cell", "cannot be null");
            }

            ValidateCellIndexes(cell.RowIndex, cell.ColIndex);
        }

        private void ValidateCellIndexes(int rowIndex, int columnIndex)
        {
            if (rowIndex > NumberOfRows - 1)
            {
                throw new ArgumentOutOfRangeException("rowIndex", "Cannot have RowIndex greater than NumberOfRows");
            }

            if (columnIndex > NumberOfColumns - 1)
            {
                throw new ArgumentOutOfRangeException("columnIndex", "Cannot have ColIndex greater than NumberOfColumns");
            }
        }
        #endregion
    }
}