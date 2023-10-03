using UnityEngine;

namespace Shooting
{
    public interface IShooter
    {
        IProjectile Shoot(Vector2 direction);
    }
}