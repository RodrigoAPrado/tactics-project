using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Tactics.Controller.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Controller {

    public class UnitModalController : MonoBehaviour {   

        [field:SerializeField] private Image UnitPortrait { get; set; }
        [field:SerializeField] private Image WeaponIcon { get; set; }
        [field:SerializeField] private TextMeshProUGUI LevelNumber { get; set; }
        [field:SerializeField] private TextMeshProUGUI UnitName { get; set; }
        [field:SerializeField] private TextMeshProUGUI HP { get; set; }
        [field:SerializeField] private TextMeshProUGUI WeaponName { get; set; }
        
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
            LevelNumber.SetText(unit.Level.ToString());
            UnitName.SetText(unit.Name);
            HP.SetText(unit.CurrentHitPoints.ToString() + "/<color=\"green\">"+unit.MaxHitPoints.ToString()+"</color>");
            WeaponName.SetText("Iron Sword");
            gameObject.SetActive(true);
        }

    }
}