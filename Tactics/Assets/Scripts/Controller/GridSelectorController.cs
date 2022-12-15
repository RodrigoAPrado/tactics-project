using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tactics.Controller {
    public class GridSelectorController : MonoBehaviour
    {

        public Vector2 SelectorPosition { get; private set; }

        private event Action SelectorMoved;

        public void Init() {

        }

        public void Move(int x, int y) {
            SelectorPosition = new Vector2(SelectorPosition.x + x, SelectorPosition.y + y);
            transform.Translate(new Vector2(x, y), Space.World);
            SelectorMoved?.Invoke();
        }

        public void MoveTo(int x, int y) {
            SelectorPosition = new Vector2(x, y);
            transform.position = SelectorPosition;
            SelectorMoved?.Invoke();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void SubscribeToMovement(Action action) {
            SelectorMoved+= action;
        }
    }
}
