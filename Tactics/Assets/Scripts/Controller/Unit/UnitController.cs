using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;

namespace Tactics.Controller.Unit {
    public class UnitController : MonoBehaviour
    {
        public Guid Id => Unit.Id;
        private IUnitDomain Unit { get; set; }
        private Sequence Sequence { get; set; }
        public UnitController Init(IUnitDomain unit) {
            Unit = unit;
            return this;
        }

        public void MoveTo(ITileDomain tile, Action callback, bool instant = false) {
            Unit.AddTileBelowUnit(tile);

            if(Sequence != null && Sequence.IsActive())
                Sequence.Kill();

            if(instant)
                transform.position = new Vector2(tile.Position.X, tile.Position.Y);

            Sequence = DOTween.Sequence();
            Sequence.Append(transform.DOMove(new Vector2(tile.Position.X, tile.Position.Y), 0.2f).SetEase(Ease.Linear));
            Sequence.OnComplete(() => callback());
            Sequence.Play();
        }
    }
}
