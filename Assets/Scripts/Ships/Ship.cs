using Input;
using Ships.CheckLimits;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private IInput _input;
        [SerializeField] private ICheckLimits _checkLimits;
        private Transform _transform;
        [SerializeField] private Projectile _bulletPrefab;
        private float _remainingTimeToShoot;
        [SerializeField] private float _fireRateInSeconds = 0.5f;
        [SerializeField] private Transform _projectileSpawnPosition;

        private void Awake()
        {
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
            TryShoot();
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

        private void TryShoot()
        {
            _remainingTimeToShoot -= Time.deltaTime;
            
            if (_remainingTimeToShoot > 0)
            {
                return;
            }

            if (_input.IsFireActionPressed())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _remainingTimeToShoot = _fireRateInSeconds;
            Instantiate(_bulletPrefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}