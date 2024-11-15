using Tactics.Domain.Interface.Unit;
using TMPro;
using UnityEngine;

namespace Tactics.Controller
{
    public class StatsWindowController : MonoBehaviour
    {
        [field: SerializeField] private TextMeshProUGUI UnitName { get; set; }
        [field: SerializeField] private TextMeshProUGUI ClassName { get; set; }
        [field: SerializeField] private TextMeshProUGUI Level { get; set; }
        [field: SerializeField] private TextMeshProUGUI ExpAmount { get; set; }
        [field: SerializeField] private TextMeshProUGUI Move { get; set; }
        [field: SerializeField] private TextMeshProUGUI CurrentHp { get; set; }
        [field: SerializeField] private TextMeshProUGUI MaxHp { get; set; }
        [field: SerializeField] private TextMeshProUGUI Str { get; set; }
        [field: SerializeField] private TextMeshProUGUI Mag { get; set; }
        [field: SerializeField] private TextMeshProUGUI Skl { get; set; }
        [field: SerializeField] private TextMeshProUGUI Spd { get; set; }
        [field: SerializeField] private TextMeshProUGUI Luk { get; set; }
        [field: SerializeField] private TextMeshProUGUI Def { get; set; }
        [field: SerializeField] private TextMeshProUGUI Res { get; set; }
        private IUnitDomain UnitDomain { get; set; }
        
        public void Init()
        {
            gameObject.SetActive(false);    
        }

        public void Show(IUnitDomain unitDomain)
        {
            UnitDomain = unitDomain;
            UnitName.SetText(UnitDomain.Name);
            ClassName.SetText(UnitDomain.ClassName);
            Level.SetText(UnitDomain.Level.ToString());
            Move.SetText(UnitDomain.Move.ToString());
            CurrentHp.SetText(UnitDomain.CurrentHitPoints.ToString());
            MaxHp.SetText(UnitDomain.MaxHitPoints.ToString());
            Str.SetText(UnitDomain.Strength.ToString());
            Mag.SetText(UnitDomain.Magic.ToString());
            Skl.SetText(UnitDomain.Skill.ToString());
            Spd.SetText(UnitDomain.Speed.ToString());
            Luk.SetText(UnitDomain.Luck.ToString());
            Def.SetText(UnitDomain.Defense.ToString());
            Res.SetText(UnitDomain.Resistance.ToString());
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}