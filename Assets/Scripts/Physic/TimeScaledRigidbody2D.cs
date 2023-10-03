using Time;
using UnityEngine;

namespace Physic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TimeScaledRigidbody2D : MonoBehaviour, ITimeScaled
    {
        public ITime Time { get; set; }

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {
            Time.ScaleChanged -= OnTimeScaleChanged;
        }

        public void SetTime(ITime time)
        {
            Time = time;
            Time.ScaleChanged += OnTimeScaleChanged;
        }

        private void OnTimeScaleChanged(float currentScale, float oldScale)
        {
            var coefficient = currentScale / oldScale;

            _rigidbody.velocity *= coefficient;
            _rigidbody.angularVelocity *= coefficient;

            _rigidbody.gravityScale *= coefficient;
        }
    }
}