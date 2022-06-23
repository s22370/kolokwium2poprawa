using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa.DTOs;
using kol2poprawa.Entities.Models;

namespace kol2poprawa.Service
{
    public interface IRepoService
    {
        public Task<GetTeam> TeamInfo(int id);
        public Task<bool> AddMember(MemberPost user, int id);
        Task CreateAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}