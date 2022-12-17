using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Domain.Map;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Controller.Board {
    public class DebugBoardController : BaseBoardController
    {
        [SerializeField]
        private int width;

        [SerializeField]
        private int height;

        [SerializeField]
        private GameObject tilePrefab;

        public override void Init() {
            this.transform.position = new Vector2(0,0);
            for(int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var tile = Instantiate(tilePrefab);
                    tile.transform.position = new Vector2(x, y);
                    tile.transform.SetParent(this.transform);
                }
            }
        }

        public override IUnitDomain SelectUnit() {
            return null;
        }

        public override Vector2 GetSize() {
            return new Vector2(width, height);
        }
    }
}
