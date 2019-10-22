using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laixer.Kadaster
{
    public interface IBagService
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(string id);
    }
}
