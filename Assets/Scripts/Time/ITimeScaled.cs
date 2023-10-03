namespace Time
{
    public interface ITimeScaled
    {
        ITime Time { get; }

        void SetTime(ITime time);
    }
}