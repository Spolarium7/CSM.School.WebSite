﻿using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
    : base(options)
        {
        }

        #region Models
        public DbSet<Group> Groups { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<SchoolFacility> SchoolFacilities { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }
        public DbSet<Achiever> Achievers { get; set; }
        public DbSet<AlumniProfile> AlumniProfiles { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Research> Researches { get; set; }

        public DbSet<NewsItem> News { get; set; }
        public DbSet<NewsGroup> NewsGroups { get; set; }

        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CertificationRegistration> CertificationRegistrations { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
