using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Controller.Test {
    public class GridBuilder : MonoBehaviour
    {
        [SerializeField]
        private int width;

        [SerializeField]
        private int height;

        [SerializeField]
        private GameObject tilePrefab;

        private void Awake() {
            this.transform.position = new Vector2(0,0);
            for(int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var tile = Instantiate(tilePrefab);
                    tile.transform.position = new Vector2(x, y);
                    tile.transform.SetParent(this.transform);
                }
            }        
        }
    }
}
