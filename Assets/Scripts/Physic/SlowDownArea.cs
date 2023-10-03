using Time;
using UnityEngine;

namespace Physic
{
    public class SlowDownArea : MonoBehaviour
    {
        [SerializeField, Min(1)] private float _slowDownMultiplier;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<ITimeScaled>(out var timeScaled))
                timeScaled.Time.Scale /= _slowDownMultiplier;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<ITimeScaled>(out var timeScaled))
                timeScaled.Time.Scale *= _slowDownMultiplier;
        }
    }
}
