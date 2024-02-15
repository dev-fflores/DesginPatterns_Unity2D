using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Patterns.Mediator
{
    public class VehicleMediator : MonoBehaviour, IVehicle
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;
        [SerializeField] private SteringWheel _steringWheel;
        [SerializeField] private Brake _brake;

        private void Awake()
        {
            _steringWheel.Configure(this);
            _brake.Configure(this);
            foreach (var wheel in _wheels)
            {
                wheel.Configure(this);
            }
            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.Configure(this);
            }
        }

        public void BrakePressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.Stop();
            }
            foreach (var brakeLights in _brakeLights)
            {
                brakeLights.TurnOn();
            }
        }

        public void BrakeReleased()
        {
            foreach (var wheel in _wheels)
            {
                wheel.Resume();
            }
            foreach (var brakeLights in _brakeLights)
            {
                brakeLights.TurnOff();
            }
        }

        public void SteringWheelTurnLeftPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void SteringWheelTurnRightPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }

        public void AutopilotActivated()
        {
            throw new NotImplementedException();
        }

        public void AutopilotDeactivated()
        {
            throw new NotImplementedException();
        }
        
        public void ObstacleDetected()
        {
            throw new NotImplementedException();
        }
    }
}