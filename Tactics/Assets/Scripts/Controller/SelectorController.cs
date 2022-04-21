using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Controller {
    public class SelectorController : MonoBehaviour
    {
        private InputProcessingController Processor { get; set; }
        void Awake()
        {
            Processor = FindObjectOfType<InputProcessingController>();
        }
    }
}
