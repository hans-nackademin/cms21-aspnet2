namespace _02_ServiceLiftetimes_Singleton_Scoped_Transient.Services
{

    public interface ITransientService : IService
    {

    }

    public class TransientService : ITransientService
    {
        private Guid _guid;

        public TransientService()
        {
            _guid = Guid.NewGuid();
        }


        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
