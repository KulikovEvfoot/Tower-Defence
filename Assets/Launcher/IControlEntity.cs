namespace TowerDefence.Launcher
{
    public interface IControlEntity
    {
        LoadingResult LoadResources();
        void Launch();
    }
}