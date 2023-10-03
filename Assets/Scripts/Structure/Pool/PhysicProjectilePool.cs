using System.Collections;
using Shooting;
using Structure.Factory;
using Time;
using UnityEngine;
using UnityEngine.Pool;

namespace Structure.Pool
{
    public class PhysicProjectilePool : IObjectPool<PhysicProjectile>
    {
        public int CountInactive => _pool.CountInactive;

        private readonly ITime _globalTime;
        private readonly ProjectileFactory _factory;
        private readonly MonoBehaviour _coroutineRunner;

        private readonly ObjectPool<PhysicProjectile> _pool;

        public PhysicProjectilePool(ITime globalTime, ProjectileFactory factory, MonoBehaviour coroutineRunner)
        {
            _globalTime = globalTime;
            _factory = factory;
            _coroutineRunner = coroutineRunner;

            _pool = CreatePool();
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

        private ObjectPool<PhysicProjectile> CreatePool()
        {
            var objectPool = new ObjectPool<PhysicProjectile>(
                CreateProjectile,
                OnGetProjectile,
                p => p.OnRelease());

            return objectPool;
        }

        private PhysicProjectile CreateProjectile()
        {
            var projectile = _factory.Create<PhysicProjectile>();
            projectile.SetTime(new LocalTime(_globalTime));

            return projectile;
        }

        private void OnGetProjectile(PhysicProjectile projectile)
        {
            projectile.OnGet();
            _coroutineRunner.StartCoroutine(ReleaseProjectileCoroutine(projectile));
        }

        private IEnumerator ReleaseProjectileCoroutine(PhysicProjectile projectile)
        {
            yield return new WaitForSeconds(projectile.LifeTime);
            Release(projectile);
        }
    }
}