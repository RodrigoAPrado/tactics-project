using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tactics.Controller.Menu {

    public class MenuOptionController : MonoBehaviour
    {
        [field: SerializeField] public MenuOption Option { get; private set; }
        [field: SerializeField] private Image Image { get; set; }

        public void Awake() {
            UnHighlight();
        }

        public void Highlight() {
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 1.0f);
        }

        public void UnHighlight() {
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0.3f);
        }
    }

    public enum MenuOption {
        Unit = 0,
        Guide = 1,
        Options = 2,
        BattleSave = 3,
        End = 4,
        Attack = 5,
        Items = 6,
        Trade = 7,
        Wait = 8,
        Shove = 9
    }

}
