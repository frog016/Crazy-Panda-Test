using Shooting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Structure.Factory
{
    public class ProjectileFactory
    {
        private readonly Dictionary<Type, IProjectile> _projectilePrefabs;

        public ProjectileFactory(IEnumerable<IProjectile> projectiles)
        {
            _projectilePrefabs = projectiles.ToDictionary(key => key.GetType(), value => value);
        }

        public T Create<T>() where T : Component, IProjectile
        {
            var prefab = GetPrefab<T>();
            return Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }

        private T GetPrefab<T>() where T : Component, IProjectile
        {
            return (T)_projectilePrefabs[typeof(T)];
        }
    }
}
