using System;

namespace Time
{
    public class LocalTime : ITime
    {
        public float Scale
        {
            get => _scale;
            set
            {
                var oldValue = Scale;
                _scale = value;
                ScaleChanged?.Invoke(Scale, oldValue);
            }
        }

        public float DeltaTime => _globalTime.DeltaTime * Scale;
        public float FixedDeltaTime => _globalTime.FixedDeltaTime * Scale;
        
        public event TimeDelta ScaleChanged;

        private float _scale;
        private readonly ITime _globalTime;

        public LocalTime(ITime globalTime)
        {
            _globalTime = globalTime;
            _scale = _globalTime.Scale;
        }
    }
}