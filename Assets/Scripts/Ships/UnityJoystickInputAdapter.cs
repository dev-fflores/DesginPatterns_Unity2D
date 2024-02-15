using System;
using UnityEngine;

namespace Ships
{
    public class UnityJoystickInputAdapter : IInput
    {
        private readonly Joystick _joystick;

        public UnityJoystickInputAdapter(Joystick joystick)
        {
            _joystick = joystick;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}