using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _timeToLive = 2f;

        private Vector3 _currentPosition;
        private Transform _myTransform;

        [SerializeField] private float _amplitude = 2f;
        [SerializeField] private float _frequency = 8f;
        [SerializeField] private float _currentTime = 0f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _currentTime = 0f;
            _myTransform = transform;
            _currentPosition = transform.position;
            StartCoroutine(DestroyInSeconds(_timeToLive));
        }

        private void FixedUpdate()
        {
            _currentTime += Time.deltaTime;
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);

            // y = amplitude * sin(frequency * x)

            var horizontalOffset = _myTransform.right * (_amplitude * Mathf.Sin(_frequency * _currentTime));

            _rigidbody2D.MovePosition(_currentPosition + horizontalOffset);
        }

        private IEnumerator DestroyInSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}