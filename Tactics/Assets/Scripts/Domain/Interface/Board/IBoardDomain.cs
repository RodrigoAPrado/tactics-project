using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Interface.Board
{
    public interface IBoardDomain {
        int Width { get; }
        int Height { get; }
        IList<ITileRowDomain> BoardRow { get; }
        ITileDomain CurrentSelectedTile { get; }
        int CursorXPosition { get; }
        int CursorYPosition { get; }
        void Init();
        bool MoveCursorPosition(int x, int y);
    }

    public interface ITileRowDomain {
        IList<ITileDomain> TileRow { get; }
    }

    public interface ITileDomain {
        TilePreparation TilePreparation { get; }
        IUnitDomain UnitOnTile { get; }
        ITileDataDomain Data { get; }
    }

    public enum TilePreparation {
        None = 0,
        Fixed = 1,
        Available = 2
    }
}