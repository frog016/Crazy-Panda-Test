namespace Structure.Pool
{
    public interface IPoolElement
    {
        void OnGet();
        void OnRelease();
    }
}
