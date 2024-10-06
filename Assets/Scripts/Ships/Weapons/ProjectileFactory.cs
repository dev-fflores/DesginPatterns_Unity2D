using UnityEngine;
using Object = UnityEngine.Object;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectileConfiguration _projectileConfiguration;

        public ProjectileFactory(ProjectileConfiguration projectileConfiguration)
        {
            _projectileConfiguration = projectileConfiguration;
        }

        public void Create(string projectileId, Vector3 _projectileSpawnPosition, Quaternion _projectileSpawnRotation)
        {
            var prefab = _projectileConfiguration.GetProjectileById(projectileId);
            Object.Instantiate(prefab, _projectileSpawnPosition, _projectileSpawnRotation);
        }
    }
}