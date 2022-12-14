using System;
using UnityEngine;
using Tactics.Controller.Scene;

namespace Tactics.Manager.GameState {
    public abstract class BaseGameState {
        
        protected GameMapSceneContext Context { get; set; }
        
        protected BaseGameState (GameMapSceneContext context) {
            Context = context;
        }

        public virtual void OnAccept() {
            Debug.Log("Accept being pressed, but not implemented!");
        } 

        public virtual void OnBack() {
            Debug.Log("Back being pressed, but not implemented!");
        }   

        public virtual void OnEnemyToggle() {
            Debug.Log("Enemy Toggle being pressed, but not implemented!");
        }

        public virtual void OnHelp() {
            Debug.Log("Help being pressed, but not implemented!");
        }

        public virtual void OnDirectionalDown() {
            Debug.Log("Down being pressed, but not implemented!");
        }

        public virtual void OnDirectionalLeft() {
            Debug.Log("Left being pressed, but not implemented!");
        }

        public virtual void OnDirectionalRight() {
            Debug.Log("Right being pressed, but not implemented!");
        }

        public virtual void OnDirectionalUp() {
            Debug.Log("Up being pressed, but not implemented!");
        }

        public virtual void OnGameMenu() {
            Debug.Log("Game Menu being pressed, but not implemented!");
        }

        public virtual void OnMapMenu() {
            Debug.Log("Map Menu being pressed, but not implemented!");
        }

        public virtual void OnNextAlly() {
            Debug.Log("Next Ally being pressed, but not implemented!");
        }

        public virtual void OnPreviousAlly() {
            Debug.Log("Previous Ally being pressed, but not implemented!");
        }

        public virtual void OnBackInTime() {
            Debug.Log("Back in Time being pressed, but not implemented!");
        }

        public virtual void OnZoomToggle() {
            Debug.Log("Zoom Toggle being pressed, but not implemented!");
        }
    }
}