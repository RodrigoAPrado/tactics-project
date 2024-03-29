using System;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Service;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;

namespace Tactics.Controller.Unit {
    public class TestMapUnitManageController : MonoBehaviour {

        [field: SerializeField] private UnitController UnitPrefab { get; set; }
        [field: SerializeField] private Color[] UnitColors { get; set; }
        private UnitService Service { get; set; }
        private List<IUnitDomain> Units { get; set; }
        private List<UnitController> UnitControllers { get; set; }

        public void Init(IBoardDomain board) {
            Service = UnitService.Instance;
            Units = Service.GetTestBoard(board);
            SetupUnits();
        }

        private void SetupUnits() {
            UnitControllers = new List<UnitController>();
            foreach(var unit in Units) {
                var tile = unit.TileBelowUnit;
                var unitController = Instantiate(UnitPrefab);
                unitController.transform.position = new Vector2(tile.Position.X, tile.Position.Y);
                unitController.transform.SetParent(this.transform);
                unitController.Init(unit);
                UnitControllers.Add(unitController);
                unitController.SetSpriteColor(UnitColors[(int)unit.ArmyType]);
            }
        }

        public void MoveUnit(IUnitDomain unit, ITileDomain tile, Action callback, bool instant = false) {
            var unitController = UnitControllers.Find(o => o.Id == unit.Id);
            unitController.MoveTo(tile, callback, instant);
        }
    }
}