using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Time
{
    public class TimeScaledObjectRoot : MonoBehaviour, ITimeScaled
    {
        public ITime Time { get; set; }

        public void SetTime(ITime time)
        {
            Time = time;

            foreach (var timeScaled in GetTimeScaledChild())
                timeScaled.SetTime(Time);
        }

        private IEnumerable<ITimeScaled> GetTimeScaledChild()
        {
            var components = GetComponents<ITimeScaled>();

            return GetComponents<ITimeScaled>()
                .Where(timeScaled => ReferenceEquals(timeScaled, this) == false);
        }
    }
}