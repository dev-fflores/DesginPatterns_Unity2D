using Input;
using UnityEngine;
using Ships.CheckLimits;
using UnityEngine.Serialization;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useJoystick = false;
        [SerializeField] private bool _useAI = false;
        [FormerlySerializedAs("_ship")] [SerializeField] private ShipMediator shipMediator;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;

        private void Awake()
        {
            shipMediator.Configure(GetInput(), GetLimits());
        }
        
        private IInput GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(shipMediator);
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
                return new LimitInsideCameraAdapter(shipMediator, Camera.main);
            }
            return new LimitOutsideCameraAdapter(shipMediator.transform, 10f);
            // return new LimitInsideCameraAdapter(_ship, Camera.main);
        }
    }
}