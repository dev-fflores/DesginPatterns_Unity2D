using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class SteringWheel : MonoBehaviour
    {
        private IVehicle _vehicle;
        
        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _vehicle.SteringWheelTurnLeftPressed();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                _vehicle.SteringWheelTurnRightPressed();
            }
        }
    }
}