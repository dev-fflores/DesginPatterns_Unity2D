using System;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private IInput _input;
        [SerializeField] private ICheckLimits _checkLimits;
        private Transform _transform;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
        }
        
        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }
        
        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            var movement = direction * (_speed * Time.deltaTime);
            _transform.Translate(movement);

            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}