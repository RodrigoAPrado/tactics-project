using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Tactics.Controller.Stage;

namespace Tactics.Controller {
    public class MapSceneCameraController : MonoBehaviour
    {
        
        [field:SerializeField] private int HorizontalLimitDelta { get; set; } = 6;
        [field:SerializeField] private int VerticalLimitDelta { get; set; } = 3;

        [SerializeField]
        private int cameraPositionDelta;

        private GridController Grid { get; set; }

        private int DownLimit { get; set; }
        private int LeftLimit { get; set; }
        private int RightLimit { get; set; }
        private int UpLimit { get; set; }
        private int CameraPositionDelta => cameraPositionDelta;

        private Tween Tween { get; set; }

        public void Init(BaseStageController stage) {
            var stageSize = stage.GetSize();
            LeftLimit = HorizontalLimitDelta;
            DownLimit = VerticalLimitDelta;
            RightLimit = (int)stageSize.x - HorizontalLimitDelta -1;
            UpLimit = (int)stageSize.y - VerticalLimitDelta -1;
            transform.DOMove(GetActualTargetPosition(new Vector2(0,0)), 0);
        }

        public void MoveCamTo(Vector2 pos) {
            var actualPos = GetActualTargetPosition(pos);
            if (Tween != null && Tween.IsActive())
                Tween.Kill();
            Tween = transform.DOMove(actualPos, 0.2f).SetEase(Ease.Linear);
        }

        private Vector2 GetActualTargetPosition(Vector2 pos) {
            var actualX = pos.x;
            var actualY = pos.y;

            if(pos.x > RightLimit)
                actualX = RightLimit;
            if(pos.x < LeftLimit)
                actualX = LeftLimit;
            if(pos.y > UpLimit)
                actualY = UpLimit;
            if(pos.y < DownLimit)
                actualY = DownLimit;

            return new Vector2(actualX, actualY);
        }
    }
}
