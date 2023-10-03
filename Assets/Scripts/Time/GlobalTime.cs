using System;

namespace Time
{
    public class GlobalTime : ITime
    {
        public float Scale 
        {
            get => UnityEngine.Time.timeScale;
            set
            {
                var oldValue = Scale;
                UnityEngine.Time.timeScale = value;
                ScaleChanged?.Invoke(Scale, oldValue);
            }
        }

        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;

        public event TimeDelta ScaleChanged;
    }
}