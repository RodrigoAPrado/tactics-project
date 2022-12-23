using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Tactics.Manager;
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
        [field:SerializeField] private Color[] UnitColors { get; set; }
        [field:SerializeField] private Image Background { get; set; }
        private TestMapBoardController Board { get; set; }
        private GameStateManager StateManager { get; set; }
        private UnitModalState CurrentState { get; set; }

        public void Init(TestMapBoardController board, GameStateManager stateManager) {
            Board = board;
            StateManager = stateManager;
            Board.SubscribeToSelector(ChangeDisplay);
            StateManager.SubscribeToStateChange(ChangeState);
            ChangeDisplay();
        }

        private void ChangeDisplay() {
            var selectedTile = Board.SelectedTile;
            if(selectedTile.UnitOnTile == null) 
            {
                Hide();
            }
            else 
            {
                switch(CurrentState) {
                    case UnitModalState.Show:
                        Show(selectedTile.UnitOnTile);
                    break;
                    case UnitModalState.OnlyNotSelected:
                        if(Board.UnitOnSelectedTile() == Board.SelectedUnit)
                            Hide();
                        else
                            Show(selectedTile.UnitOnTile);
                    break;
                    case UnitModalState.DontShow:
                        Hide();
                    break;
                }
            }
        }

        private void ChangeState() {
            CurrentState = StateManager.ModalState;
            ChangeDisplay();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show(IUnitDomain unit) {
            LevelNumber.SetText(unit.Level.ToString());
            UnitName.SetText(unit.Name);
            HP.SetText(unit.CurrentHitPoints.ToString() + "/<color=\"green\">"+unit.MaxHitPoints.ToString()+"</color>");
            WeaponName.SetText("Iron Sword");
            Background.color = UnitColors[(int) unit.ArmyType];
            gameObject.SetActive(true);
        }

    }

    public enum UnitModalState {
        Show,
        OnlyNotSelected,
        DontShow
    }
}