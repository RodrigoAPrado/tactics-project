using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Unit;
using Tactics.Domain.Factory;

namespace Tactics.Service.Model {

    public class UnitSetModel {
        public List<UnitModel> units { get; set; }

        public List<IUnitDomain> ToDomain(IBoardDomain board) {
            var domainList = new List<IUnitDomain>();
            foreach(var unit in units) {
                domainList.Add(unit.ToDomain(board));
            }
            return domainList;
        }
    }

    public class UnitModel {
        public UnitPosition startingPosition { get; set; }
        public UnitClass unitClass { get; set; }
        public ArmyType armyType { get; set; }
        public UnitResource unitResource { get; set; }
        public int armyId { get; set; }
        public Affinity affinity { get; set; }
        public UnitStatsModel gainedStats { get; set; }
        public Dictionary<WeaponType, int> weaponExp { get;set; }

        public IUnitDomain ToDomain(IBoardDomain board) {
            var data = UnitDataDomainFactory.CreateUnitDataByType(armyId, armyType,
            unitResource, unitClass, affinity, gainedStats.ToDomain(), weaponExp);
            return new UnitDomain(data, board.GetTileOnPosition(startingPosition.x, startingPosition.y));
        }

    }

    public class UnitPosition {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class UnitStatsModel {
        public int hitPoints { get; set; }
        public int strength { get; set; }
        public int magic { get; set; }
        public int skill { get; set; }
        public int speed { get; set; }
        public int luck { get; set; }
        public int defense { get; set; }
        public int resistance { get; set; }
        public int weight { get; set; }
        public int move { get; set; }
        public int constitution { get; set; }

        public IUnitStats ToDomain() {
            return new UnitStats(hitPoints, strength, magic, 
            skill, speed, luck, defense, resistance, 
            weight, move, constitution);
        }
    }
}