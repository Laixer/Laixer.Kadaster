using System.Collections.Generic;

namespace Laixer.Kadaster
{
    public interface IBagService { }

    public interface IBagService<T> : IBagService
    {
        IEnumerable<BagObject<T>> GetAll();
        BagObject<T> GetById(string id);
    }
}
