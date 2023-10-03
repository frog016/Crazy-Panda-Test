using UnityEngine;

namespace Shooting
{
    public class AutomaticShooter : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _anchor;

        private IShooter _shooter;
        private Cooldown _cooldown;

        public void Initialize(IShooter shooter, Cooldown cooldown)
        {
            _shooter = shooter;
            _cooldown = cooldown;
        }

        private void Update()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            if (_cooldown.IsReady == false)
                return;

            var direction = GetShootDirection();

            var projectile = _shooter.Shoot(direction);
            projectile.From(_anchor.position);

            _cooldown.Restart();
        }

        private Vector3 GetShootDirection()
        {
            return (_targetTransform.position - _anchor.position).normalized;
        }
    }
}