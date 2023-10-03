using UnityEngine;
using UnityEngine.Pool;

namespace Shooting
{
    public class ProjectileShooter : IShooter
    {
        private readonly IObjectPool<PhysicProjectile> _pool;

        public ProjectileShooter(IObjectPool<PhysicProjectile> pool)
        {
            _pool = pool;
        }

        public IProjectile Shoot(Vector2 direction)
        {
            var projectile = _pool.Get();
            projectile.Launch(direction);

            return projectile;
        }
    }
}