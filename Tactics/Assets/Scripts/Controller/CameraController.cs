using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tactics.Controller {
    public class CameraController : MonoBehaviour
    {
        
        [SerializeField]
        private int cameraPositionDelta;

        private GridController Grid { get; set; }
        private int HorizontalLimit { get; set; } = -1;
        private int VerticalLimit { get; set; } = -1;
        private int CameraPositionDelta => cameraPositionDelta;

        private void Awake()
        {
            Grid = FindObjectOfType<GridController>();
            Grid.FinishedBuildStageTiles += SetupCamera;
        }

        private void SetupCamera() {
            if(Grid.GridSize.x >= (CameraPositionDelta * 2) + 1) {
                HorizontalLimit = Grid.GridSize.x - CameraPositionDelta;
            }   
            if(Grid.GridSize.y >= (CameraPositionDelta * 2) + 1) {
                VerticalLimit = Grid.GridSize.y - CameraPositionDelta;
            }   
            transform.position = new Vector2(0, 0);
        }
    }
}
