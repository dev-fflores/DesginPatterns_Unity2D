using System;
using System.Linq;
using Input;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        public IShip _ship;
        private float _remainingSecondsToBeAbleToShoot;
        [SerializeField] private float _fireRateInSeconds = 0.5f;
        [SerializeField] private Projectile[] _bulletPrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;

        [SerializeField] private string _activeProjectileId;

        private void Start()
        {
            _activeProjectileId = "Projectile1";
        }

        public void Configure(IShip ship)
        {
            _ship = ship;
        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }
            Shoot();
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            var prefab = _bulletPrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}