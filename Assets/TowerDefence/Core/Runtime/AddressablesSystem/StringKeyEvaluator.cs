using UnityEngine.AddressableAssets;

namespace TowerDefence.Core.Runtime.AddressablesSystem
{
    public class StringKeyEvaluator : IKeyEvaluator
    {
        public StringKeyEvaluator(string key)
        {
            m_Key = key;
        }

        public bool RuntimeKeyIsValid()
        {
            return !string.IsNullOrEmpty(m_Key);
        }

        public object RuntimeKey
        {
            get
            {
                return m_Key;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StringKeyEvaluator);
        }

        public bool Equals(StringKeyEvaluator other)
        {
            return other != null && m_Key == other.m_Key;
        }

        public override int GetHashCode()
        {
            return m_Key.GetHashCode();
        }
        
        private readonly string m_Key;
    }
}