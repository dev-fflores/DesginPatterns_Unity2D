using Input;
using UnityEngine;
using Ships.CheckLimits;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useJoystick = false;
        [SerializeField] private bool _useAI = false;
        [SerializeField] private Ship _ship;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;

        private void Awake()
        {
            _ship.Configure(GetInput(), GetLimits());
        }
        
        private IInput GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(_ship);
            }
            
            
            if (_useJoystick)
            {
                return new UnityJoystickInputAdapter(_joystick, _joyButton);
            }
            
            return new UnityOldInputAdapter();
        }
        
        private ICheckLimits GetLimits()
        {
            if (_useAI)
            {
                // return new LimitOutsideCameraAdapter(_ship.transform, 10f);
                return new LimitInsideCameraAdapter(_ship, Camera.main);
            }
            return new LimitOutsideCameraAdapter(_ship.transform, 10f);
            // return new LimitInsideCameraAdapter(_ship, Camera.main);
        }
    }
}