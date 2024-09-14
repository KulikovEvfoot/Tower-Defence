namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IAttackPriorityCollection<T>
    {
        bool HasNext();
        bool Has(int id);
        T GetNext();
        void Add(int id, T item);
        void Remove(int id);
    }
}