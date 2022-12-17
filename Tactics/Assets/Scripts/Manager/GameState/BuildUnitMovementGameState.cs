using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Controller.Scene;
using Tactics.Domain.Interface.Board;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class BuildUnitMovementGameState : BaseGameState {
        private IUnitDomain Unit { get; set; }
        private List<AvailableTile> Tiles { get; set; }
        private AvailableTile TargetTile { get; set; }
        public BuildUnitMovementGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> tiles, AvailableTile targetTile) : base(context, gameStateManager)
        {
            Unit = unit;
            Tiles = tiles;
            TargetTile = targetTile;
        }

        public override BaseGameState Init()
        {
            var tileDomainList = new List<ITileDomain>();

            var currentTile = TargetTile;

            do {
                tileDomainList.Add(Context.Board.Board.GetTileById(currentTile.TileId));
                currentTile = currentTile.PreviousTile;
            } while(currentTile != null);

            GameStateManager.Replace(new ExecuteUnitMovementGameState(Context, GameStateManager, Unit, Tiles, tileDomainList));

            return this;
        }
    }
}