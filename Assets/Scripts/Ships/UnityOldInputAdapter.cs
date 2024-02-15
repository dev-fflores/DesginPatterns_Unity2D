using UnityEngine;

namespace Ships
{
    public class UnityOldInputAdapter : IInput
    {
        public Vector2 GetDirection()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}