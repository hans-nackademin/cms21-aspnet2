namespace _02_ServiceLiftetimes_Singleton_Scoped_Transient.Services
{
    public interface IScopedService : IService
    {

    }

    public class ScopedService : IScopedService
    {
        private Guid _guid;

        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }


        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
