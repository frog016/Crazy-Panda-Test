namespace Time
{
    public interface ITime
    {
        float Scale { get; set; }
        float DeltaTime { get; }
        float FixedDeltaTime { get; }

        event TimeDelta ScaleChanged;
    }

    public delegate void TimeDelta(float currentScale, float oldScale);
}
