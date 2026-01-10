using BlackHole.Services.GameLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHole.Services.GameLogic.Model
{
    public class BlackholeCellEventArgs : EventArgs
    {

        private CellState _changedCellState;
        private int _changedRow;
        private int _changedColumn;
        private bool _changedCellSelected;




        public CellState CellState { get { return _changedCellState; } }
        public int Row { get { return _changedRow; } }
        public int Column { get { return _changedColumn; } }
        public bool Selected { get { return _changedCellSelected; } }//ezek csak azert vannak hogy az event adatait kiolvassuk




        public BlackholeCellEventArgs(int row, int col, CellState cellState, bool selected)
        {
            _changedCellState = cellState;
            _changedRow = row;
            _changedColumn = col;
            _changedCellSelected = selected;
        }
    }

    public class BlackholeGameEventArgs : EventArgs
    {
        private CellState _winner;

        public CellState Winner { get { return _winner; } }


        public BlackholeGameEventArgs(CellState cs)
        {
            _winner = cs;
        }
    }

    public class BlackholePlayerEventArgs : EventArgs
    {
        private CellState _player;
        public CellState Player { get { return _player; } }

        public BlackholePlayerEventArgs(CellState cs)
        {
            _player = cs;
        }
    }
}
