using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField, Range(0, 100)] private float _flySpeed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void From(Vector2 position)
        {
            _rigidbody.position = position;
        }

        public void Launch(Vector2 direction)
        {
            _rigidbody.velocity = direction * _flySpeed;
        }

        public void OnGet()
        {
            throw new System.NotImplementedException();
        }

        public void OnRelease()
        {
            throw new System.NotImplementedException();
        }
    }
}