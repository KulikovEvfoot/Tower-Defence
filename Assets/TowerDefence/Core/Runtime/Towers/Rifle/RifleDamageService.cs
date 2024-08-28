namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleDamageService
    {
        private const int m_Damage = 1;

        public void DoDamage(IShotTarget target)
        {
            if (target is IUnit canTakeDamage)
            {
                DoDamage(canTakeDamage);
            }
        }

        public void DoDamage(IUnit canTakeDamage)
        {
            if (canTakeDamage.IsAlive)
            {
                canTakeDamage.TakeDamage(m_Damage);
            }
        }
    }
}