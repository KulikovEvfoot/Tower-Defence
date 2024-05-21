namespace Common
{
    public class IdFactory
    {
        private int m_ItemId = -1;

        public int CreateNext()
        {
            m_ItemId++;
            return m_ItemId;
        }
        
        public void Reset()
        {
            m_ItemId = -1;
        }
    }
}