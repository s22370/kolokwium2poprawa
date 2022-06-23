using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa.DTOs;
using kol2poprawa.Entities;
using kol2poprawa.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2poprawa.Service
{
    public class RepoService: IRepoService
    {
        private readonly RepositoryContext _repository;
        public RepoService(RepositoryContext repository)
        {
            _repository = repository;
        }

        public Task CreateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<GetTeam> TeamInfo(int id)
        {
            return await _repository.Team.Where(e=>e.TeamID==id).
            Include(e=>e.Organization)
            .Include(e=>e.Membership)
            .ThenInclude(e=>e.Member)
            .Select(e=>new GetTeam{
                TeamName=e.TeamName,
                TeamDescription=e.TeamDescription,
                OrganizationName=e.Organization.OrganizationName,
                Member=e.Membership.Where(m=>m.TeamID==id)
                .Select(m=>new Members
                {
                    MemberName=m.Member.MemberName,
                    MemberNickName=m.Member.MemberNickName,
                    MemberSurname=m.Member.MemberSurname,
                    MembershipDate=m.MembershipDate,
                }).OrderBy(c=>c.MembershipDate).ToList()

            }).SingleOrDefaultAsync();
            }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMember(MemberPost member, int id)
        {
            if(await _repository.Team.FindAsync(member.MemberID) != null) return false;
            if(member.OrganizationID == id) return false;

            _repository.Membership.Add(new Membership{
                MemberID = member.MemberID,
                TeamID = id,
                MembershipDate = DateTime.Now

            });

            return await _repository.SaveChangesAsync() > 1 ? true : false;
        
        }
    }
    }
