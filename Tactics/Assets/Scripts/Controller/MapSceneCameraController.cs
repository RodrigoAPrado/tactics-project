using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tactics.Controller {
    public class MapSceneCameraController : MonoBehaviour
    {
        
        [SerializeField]
        private int cameraPositionDelta;

        private GridController Grid { get; set; }
        private int HorizontalLimit { get; set; } = -1;
        private int VerticalLimit { get; set; } = -1;
        private int CameraPositionDelta => cameraPositionDelta;

        private Tween Tween { get; set; }

        public void MoveCamTo(Vector2 pos) {
            if (Tween != null && Tween.IsActive())
                Tween.Kill();
            Tween = transform.DOMove(pos, 0.2f).SetEase(Ease.Linear);
        }
    }
}
