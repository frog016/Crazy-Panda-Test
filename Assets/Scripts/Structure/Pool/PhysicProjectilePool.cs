using Shooting;
using Structure.Factory;
using UnityEngine.Pool;

namespace Structure.Pool
{
    public class PhysicProjectilePool : IObjectPool<PhysicProjectile>
    {
        public int CountInactive => _pool.CountInactive;

        private readonly ObjectPool<PhysicProjectile> _pool;

        public PhysicProjectilePool(ProjectileFactory factory)
        {
            _pool = CreatePool(factory);
        }

        public PhysicProjectile Get()
        {
            return _pool.Get();
        }

        public PooledObject<PhysicProjectile> Get(out PhysicProjectile v)
        {
            return _pool.Get(out v);
        }

        public void Release(PhysicProjectile element)
        {
            _pool.Release(element);
        }

        public void Clear()
        {
            _pool.Clear();
        }

        private static ObjectPool<PhysicProjectile> CreatePool(ProjectileFactory factory)
        {
            var objectPool = new ObjectPool<PhysicProjectile>(
                factory.Create<PhysicProjectile>, 
                p => p.OnGet(), 
                p => p.OnRelease());

            return objectPool;
        }
    }
}