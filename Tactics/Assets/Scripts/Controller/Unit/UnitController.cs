using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Controller.Unit {
    public class UnitController : MonoBehaviour
    {
        public Guid Id => Unit.Id;
        private IUnitDomain Unit { get; set; }
        public UnitController Init(IUnitDomain unit) {
            Unit = unit;
            return this;
        }
    }
}
