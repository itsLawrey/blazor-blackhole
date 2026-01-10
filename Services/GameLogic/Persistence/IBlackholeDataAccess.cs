using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHole.Services.GameLogic.Persistence
{
    public interface IBlackholeDataAccess 
    {
        Task<BlackholeTable> LoadAsync(String path);
        Task SaveAsync(String path, BlackholeTable table);
    }
}
