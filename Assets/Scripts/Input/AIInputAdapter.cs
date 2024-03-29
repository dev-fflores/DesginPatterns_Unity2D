﻿using Input;
using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : IInput
    {
        private readonly Ship _ship;
        private int _currentDirectionX;
        public AIInputAdapter(Ship ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
        }
        public Vector2 GetDirection()
        {
            // Quiero que la nave se mueva de izquierda a derecha y viceversa
            // cada que llegue a un extremo de la pantalla
            var viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
            
            
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