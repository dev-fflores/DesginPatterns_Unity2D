using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _vehicle.BrakePressed();
            }
            if (UnityEngine.Input.GetKeyUp(KeyCode.Space))
            {
                _vehicle.BrakeReleased();
            }
        }
        
        
    }
}