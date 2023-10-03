using Time;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicProjectile : TimeScaledObjectRoot, IProjectile
    {
        [field: SerializeField] public float LifeTime { get; private set; }

        [SerializeField, Range(0, 100)] private float _flySpeed;
        [SerializeField, Range(0, 100)] private float _angularVelocity;

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
            _rigidbody.angularVelocity = _angularVelocity;
        }

        public void OnGet()
        {
            _rigidbody.simulated = true;
            gameObject.SetActive(true);
        }

        public void OnRelease()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0f;

            _rigidbody.simulated = false;
            gameObject.SetActive(false);
        }
    }
}