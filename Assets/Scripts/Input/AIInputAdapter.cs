using Input;
using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : IInput
    {
        private readonly ShipMediator _shipMediator;
        private int _currentDirectionX;
        private Camera _camera;

        public AIInputAdapter(ShipMediator shipMediator)
        {
            _shipMediator = shipMediator;
            _currentDirectionX = 1;
            _camera = Camera.main;
        }

        public Vector2 GetDirection()
        {
            // Quiero que la nave se mueva de izquierda a derecha y viceversa
            // cada que llegue a un extremo de la pantalla
            var viewportPoint = _camera.WorldToViewportPoint(_shipMediator.transform.position);
            
            
            if (viewportPoint.x < 0.05f)
            {
                _currentDirectionX = 1;
            }
            else if (viewportPoint.x > 0.95f)
            {
                _currentDirectionX = -1;
            }
            
            return new Vector2(_currentDirectionX, 0);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}