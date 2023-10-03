using Structure.Pool;
using UnityEngine;

namespace Shooting
{
    public interface IProjectile : IPoolElement
    {
        void From(Vector2 position);
        void Launch(Vector2 direction);
    }
}