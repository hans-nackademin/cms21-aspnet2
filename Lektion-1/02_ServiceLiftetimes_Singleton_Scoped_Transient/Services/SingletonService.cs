namespace _02_ServiceLiftetimes_Singleton_Scoped_Transient.Services
{
    public interface ISingletonService : IService
    {

    }

    public class SingletonService : ISingletonService
    {
        private Guid _guid;

        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }


        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
