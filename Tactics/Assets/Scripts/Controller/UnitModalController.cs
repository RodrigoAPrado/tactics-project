using UnityEngine;
using Tactics.Controller.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Controller {

    public class UnitModalController : MonoBehaviour {   

        private BaseBoardController Board { get; set; }

        public void Init(BaseBoardController board) {
            Board = board;
            Board.SubscribeToSelector(ChangeDisplay);
            ChangeDisplay();
        }

        private void ChangeDisplay() {
            var selectedTile = Board.SelectedTile;
            if(selectedTile.UnitOnTile != null)
                Show(selectedTile.UnitOnTile);
            else
                Hide();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show(IUnitDomain unit) {
            gameObject.SetActive(true);
        }

    }
}