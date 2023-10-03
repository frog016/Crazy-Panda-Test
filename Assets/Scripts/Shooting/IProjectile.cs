using Structure.Pool;
using UnityEngine;

namespace Shooting
{
    public interface IProjectile : IPoolElement
    {
        float LifeTime { get; }
        void From(Vector2 position);
        void Launch(Vector2 direction);
    }
}