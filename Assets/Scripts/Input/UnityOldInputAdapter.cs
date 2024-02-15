using UnityEngine;

namespace Input
{
    public class UnityOldInputAdapter : IInput
    {
        public Vector2 GetDirection()
        {
            return new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        }
        
        public bool IsFireActionPressed()
        {
            return UnityEngine.Input.GetButton("Fire1");
        }
    }
}