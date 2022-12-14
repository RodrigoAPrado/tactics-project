using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Controller {
    public class GridSelectorController : MonoBehaviour
    {

        public Vector2 SelectorPosition { get; private set; }

        public void Init() {

        }

        public void Move(int x, int y) {
            SelectorPosition = new Vector2(SelectorPosition.x + x, SelectorPosition.y + y);
            transform.Translate(new Vector2(x, y), Space.World);
        }

        public void MoveTo(int x, int y) {
            //TODO: Move to specific place in grid.
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}
