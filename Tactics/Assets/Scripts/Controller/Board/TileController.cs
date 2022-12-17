using UnityEngine;
using System;
using Tactics.Domain.Interface.Board;

namespace Tactics.Controller.Board {
    
    public class TileController : MonoBehaviour {
        public Guid Id => TileDomain.Id;

        [field:SerializeField] private GameObject StayHighlight { get; set; }
        [field:SerializeField] private GameObject AttackHighlight { get; set; }
        [field:SerializeField] private GameObject MoveOnlyHighlight { get; set; }

        private ITileDomain TileDomain { get; set; }

        public TileController Init(ITileDomain tileDomain) {
            TileDomain = tileDomain;
            if(TileDomain.Data.Type == TileType.Disabled)
                gameObject.SetActive(false);
            Clear();
            return this;
        }

        public void Clear() {
            StayHighlight.SetActive(false);
            AttackHighlight.SetActive(false);
            MoveOnlyHighlight.SetActive(false);
        }

        public void SetState(TileMoveInteraction interaction) {
            switch(interaction) {
                case TileMoveInteraction.CanStay:
                    StayHighlight.SetActive(true);
                    break;
                case TileMoveInteraction.OnlyWalkable:
                    MoveOnlyHighlight.SetActive(true);
                    break;
            }
        }
    }
}