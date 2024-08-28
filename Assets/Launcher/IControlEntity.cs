namespace Launcher
{
    public interface IControlEntity
    {
        LoadingResult LoadResources();
        void Launch();
    }
}