using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Autopilot : MonoBehaviour
    {
        private IVehicle _vehicle;
        
        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                _vehicle.AutopilotActivated();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                _vehicle.AutopilotDeactivated();
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                _vehicle.AutopilotDeactivated();
                _vehicle.ObstacleDetected();
            }
        }
    }
}