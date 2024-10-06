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

        [SerializeField] private ProjectileConfiguration _projectileConfiguration;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private float _fireRateInSeconds = 0.5f;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;
        
        [SerializeField] private string _activeProjectileId;
        public IShip _ship;

        private void Awake()
        {
            _projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration));
        }

        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectileId = _defaultProjectileId.Value;
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
            _projectileFactory.Create(_activeProjectileId, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}