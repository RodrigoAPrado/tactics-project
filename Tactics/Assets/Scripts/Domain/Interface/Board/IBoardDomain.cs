using System;
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
        ITileDomain GetTileOnPosition(int x, int y);
        ITileDomain GetTileById(Guid id);
    }

    public interface ITileRowDomain {
        IList<ITileDomain> TileRow { get; }
    }

    public interface ITileDomain {
        Guid Id { get; }
        bool Empty { get; }
        ITilePosition Position { get; }
        TilePreparation TilePreparation { get; }
        IUnitDomain UnitOnTile { get; }
        ITileDataDomain Data { get; }
        void AddUnitOnTile(IUnitDomain unit);
        void RemoveUnitFromTile();
        ITileMoveInteractionResult GetTileUnitInteraction(IUnitDomain unit, int remainingMove);
    }

    public interface ITilePosition {
        int X { get; }
        int Y { get; }
    }

    public enum TilePreparation {
        None = 0,
        Fixed = 1,
        Available = 2
    }

    public interface ITileMoveInteractionResult {
        TileMoveInteraction Interaction { get; }
        int MoveCost { get; }
    }

    public enum TileMoveInteraction {
        CanStay = 0,
        OnlyWalkable = 1,
        Blocked = 2
    }
}