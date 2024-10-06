using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "Factory/Create ProjectileConfig", fileName = "ProjectileConfig")]
    public class ProjectileConfiguration : ScriptableObject
    {
        [SerializeField] private Projectile[] _bulletPrefabs;
        private Dictionary<string, Projectile> _idToProjectilePrefab;
        
        private void Awake()
        {
            _idToProjectilePrefab = new Dictionary<string, Projectile>();

            foreach (var bulletPrefab in _bulletPrefabs)
            {
                _idToProjectilePrefab.Add(bulletPrefab.Id, bulletPrefab);
            }
        }

        public Projectile GetProjectileById(string id)
        {
            return _idToProjectilePrefab[id];
        }
    }
}