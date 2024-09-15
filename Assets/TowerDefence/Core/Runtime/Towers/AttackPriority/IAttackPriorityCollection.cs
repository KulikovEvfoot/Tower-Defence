namespace TowerDefence.Core.Runtime.Towers.AttackPriority
{
    public interface IAttackPriorityCollection<T>
    {
        bool HasNext();
        bool Has(int id);
        bool Has(T item);
        T GetNext();
        void Add(int id, T item);
        void Remove(int id);
        void Clear();
    }
}