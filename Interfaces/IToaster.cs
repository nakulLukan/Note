namespace Note.Interfaces
{
    public interface IToaster
    {
        void Success(string message);
        void Error(string message);
    }
}
