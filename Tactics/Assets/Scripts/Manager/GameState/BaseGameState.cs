using System;

namespace Tactics.Manager.GameState {
    public abstract class BaseGameState {
        public virtual void OnAccept() {

        } 

        public virtual void OnBack() {

        }   

        public virtual void OnEnemyToggle() {
            
        }

        public virtual void OnHelp() {

        }

        public virtual void OnPressDirection(Direction direction) {

        }

        public virtual void OnHoldDirection(Direction direction) {

        }

        public virtual void OnReleaseDirection(Direction direction) {

        }

        public virtual void OnGameMenu() {

        }

        public virtual void OnMapMenu() {

        }

        public virtual void OnNextAlly() {

        }

        public virtual void OnPreviousAlly() {

        }

        public virtual void OnBackInTime() {

        }

        public virtual void OnZoomToggle() {
            
        }
    }

    public enum Direction {
        Up,
        Right,
        Down,
        Left
    }
}