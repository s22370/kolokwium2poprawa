using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2poprawa.Entities
{
    public class RepositoryContext: DbContext
    {
        public DbSet<File> File { get; set; }
        public DbSet<Organization> Organization { get; set; }
        
        public DbSet<Membership> Membership { get; set; }
    
        public DbSet<Team> Team { get; set; }
        public DbSet<Member> Member { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(e =>
            {
                e.ToTable("File");
                e.HasKey(e => e.FileID);

                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileSize).IsRequired();
                e.HasOne(e => e.Team).WithMany(e => e.File).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new File
                    {
                        FileID = 1,
                        FileName = "0.0",
                        FileExtension = ".lesgo",
                        FileSize=3
                    }
                );
            });

             modelBuilder.Entity<Team>(e =>
            {
                e.ToTable("Team");
                e.HasKey(e => e.TeamID);

                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(500);
                e.HasOne(e => e.Organization).WithMany(e => e.Team).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Team
                    {
                        TeamID = 1,
                        TeamName = "Palandracrew",
                        TeamDescription = "no fajniutkie ciuszki polecam"
                        
                    }
                );
            });
             modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.MemberID);

                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(20);
                e.HasOne(e => e.Organization).WithMany(e => e.Member).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Member
                    {
                        MemberID = 1,
                        MemberName = "Kamil",
                        MemberSurname = "Czyż",
                        MemberNickName="Sexiak"
                    }
                );
            });
              modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.HasKey(e => e.MemberID);

                e.Property(e => e.MembershipDate).IsRequired();
            
                e.HasOne(e => e.Member).WithMany(e => e.Membership).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Team).WithMany(e => e.Membership).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Membership
                    {
                        MemberID = 1,
                        TeamID = 1,
                        MembershipDate = new System.DateTime(2022, 4,7)
                        
                    }
                );
            });
             modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.MemberID);

                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(20);
                e.HasOne(e => e.Organization).WithMany(e => e.Member).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Member
                    {
                        MemberID = 1,
                        MemberName = "Kamil",
                        MemberSurname = "Czyż",
                        MemberNickName="Kamien"
                    }
                );
            });
              modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("Organization");
                e.HasKey(e => e.OrganizationID);

                e.Property(e => e.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();
        
                e.HasData(
                    new Organization
                    {
                        OrganizationName = "pogers",
                        OrganizationDomain="global"
                    }
                );
            });
        }
    }
}