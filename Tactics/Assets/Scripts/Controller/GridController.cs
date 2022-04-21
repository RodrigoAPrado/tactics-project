using System;
using System.Collections.Generic;
using Tactics.Controller.MapObjects;
using UnityEngine;

namespace Tactics.Controller {
    public class GridController : MonoBehaviour
    {
        public Dictionary<int, Dictionary<int, TileObject>> TileSet { get; private set; }
        public Vector2Int GridSize { get; private set; }
        public event Action FinishedBuildStageTiles;

        // Start is called before the first frame update
        void Start()
        {
            TileSet = new Dictionary<int, Dictionary<int, TileObject>>();
            BuildStageTiles();
        }

        private void BuildStageTiles() {
            var tileset = GameObject.FindObjectsOfType<TileObject>();   
            var highestY = -1;
            var highestX = -1;
            foreach(TileObject tile in tileset) {
                if(tile.ObjectData.Position.X > highestX)
                    highestX = tile.ObjectData.Position.X;
                if(tile.ObjectData.Position.Y > highestY)
                    highestY = tile.ObjectData.Position.Y;
                if(!TileSet.ContainsKey(tile.ObjectData.Position.X)) 
                    TileSet.Add(tile.ObjectData.Position.X, new Dictionary<int, TileObject>());
                if(!TileSet[tile.ObjectData.Position.X].ContainsKey(tile.ObjectData.Position.Y)) 
                    TileSet[tile.ObjectData.Position.X].Add(tile.ObjectData.Position.Y, tile);       
            }
            GridSize = new Vector2Int(highestX, highestY);
            FinishedBuildStageTiles?.Invoke();
        }
    }
}