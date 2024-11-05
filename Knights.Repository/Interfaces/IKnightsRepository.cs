using Knights.Model;
using Knights.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Service.Interfaces
{
    public interface IKnightsRepository
    {
        Task<string> Add(Knight knight);

        Task<List<KnightViewModel>> List(bool onlyHeroes);

        Task<Knight> GetById(string id);

        Task Remove(string id);

        Task UpdateNickname(string id, string nickname);
    }
}
