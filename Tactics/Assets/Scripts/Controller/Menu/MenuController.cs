using UnityEngine;

namespace Tactics.Controller.Menu {

    public class MenuController : MonoBehaviour
    {
        [field:SerializeField] private MenuOptionController[] Options { get; set; }
        
        private int CurrentSelectedIndex { get; set; }
        public void Init() {
            CurrentSelectedIndex = 0;
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
            Options[CurrentSelectedIndex].Highlight();
        }

        private void ResetSelection() {
            CurrentSelectedIndex = 0;
        }

        public void GoToFirstAvailableOption() {
            if(!Options[CurrentSelectedIndex].Enabled) {
                NavigateDown();
            }
        }

        public void DisableOption(MenuOption option) {
            foreach(var o in Options) {
                if(o.Option == option) {
                    o.Disable();
                    return;
                }
            }
        }

        public void EnableOption(MenuOption option) {
            foreach(var o in Options) {
                if(o.Option == option) {
                    o.Enable();
                    return;
                }
            }
        }

        public void Hide() {
            Options[CurrentSelectedIndex].UnHighlight();
            gameObject.SetActive(false);
            ResetSelection();
        }

        public void NavigateDown() {
            Options[CurrentSelectedIndex].UnHighlight();
            CurrentSelectedIndex++;
            if(CurrentSelectedIndex >= Options.Length)
                CurrentSelectedIndex = 0;
            if(Options[CurrentSelectedIndex].Enabled)
                Options[CurrentSelectedIndex].Highlight();
            else
                NavigateDown();
        }
        
        public void NavigateUp() {
            Options[CurrentSelectedIndex].UnHighlight();
            CurrentSelectedIndex--;
            if(CurrentSelectedIndex < 0)
                CurrentSelectedIndex = Options.Length-1;
            if(Options[CurrentSelectedIndex].Enabled)
                Options[CurrentSelectedIndex].Highlight();
            else
                NavigateUp();
        }

        public MenuOption GetCurrentMenuOption(){
            return Options[CurrentSelectedIndex].Option;
        }
    }
}