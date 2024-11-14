using Tactics.Domain.Interface.Unit;
using UnityEngine;

namespace Tactics.Controller
{
    public class StatsWindowController : MonoBehaviour
    {
        private IUnitDomain UnitDomain;
        public void Init()
        {
            gameObject.SetActive(false);    
        }

        public void Show(IUnitDomain unitDomain)
        {
            UnitDomain = unitDomain;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}