using System;
using Ships.CheckLimits;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        public IShip _ship;
        private Transform _transform;
        private ICheckLimits _checkLimits;
        [SerializeField] private float _speed = 5f;

        private void Awake()
        {
            _transform = transform;
        }

        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }
        
        public void Move(Vector2 direction)
        {
            var movement = direction * (_speed * Time.deltaTime);
            _transform.Translate(movement);

            _checkLimits.ClampFinalPosition();
        }
    }
}