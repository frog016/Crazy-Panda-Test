using Shooting;
using Structure.Factory;
using Structure.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Initialize
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AutomaticShooter _leftCannon;
        [SerializeField] private AutomaticShooter _rightCannon;

        [SerializeField] private float _cooldownTime;

        [SerializeField] private PhysicProjectile _projectilePrefab;

        private IObjectPool<PhysicProjectile> _projectilePool;

        private void Awake()
        {
            var factory = new ProjectileFactory(new[] { _projectilePrefab });
            _projectilePool = new PhysicProjectilePool(factory);

            InitializeCannon(_leftCannon);
            InitializeCannon(_rightCannon);
        }

        private void InitializeCannon(AutomaticShooter cannon)
        {
            var shooter = CreateShooter();
            var cooldown = new Cooldown(_cooldownTime, cannon);

            cannon.Initialize(shooter, cooldown);
        }

        private IShooter CreateShooter()
        {
            return new ProjectileShooter(_projectilePool);
        }
    }
}
