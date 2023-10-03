using System.Collections.Generic;
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
            return transform.GetComponentsInChildren<ITimeScaled>();
        }
    }
}