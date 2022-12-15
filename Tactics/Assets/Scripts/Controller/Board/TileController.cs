using UnityEngine;
using Tactics.Domain.Interface.Board;

namespace Tactics.Controller.Board {
    
    public class TileController : MonoBehaviour {
        
        private ITileDomain TileDomain { get; set; }

        public TileController Init(ITileDomain tileDomain) {
            TileDomain = tileDomain;
            if(TileDomain.Data.Type == TileType.Disabled)
                gameObject.SetActive(false);
            return this;
        }
    }
}