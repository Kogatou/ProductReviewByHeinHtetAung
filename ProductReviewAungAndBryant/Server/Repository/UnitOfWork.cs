using ProductReviewAungAndBryant.Server.Data;
using ProductReviewAungAndBryant.Server.IRepository;
using ProductReviewAungAndBryant.Server.Models;
using ProductReviewAungAndBryant.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Drawing;
using ProductReviewAungAndBryant.Client.Pages.CategoryPcPart;

namespace ProductReviewAungAndBryant.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<PcPart> _PcParts;
        private IGenericRepository<Category> _Categories;
        private IGenericRepository<Shared.Domain.CategoryPcPart> _CategoryPcParts;
        private IGenericRepository<Shared.Domain.PcPartImage> _PcPartImages;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<PcPart> PcParts
            => _PcParts ??= new GenericRepository<PcPart>(_context);
        public IGenericRepository<Category> Categories
            => _Categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Shared.Domain.CategoryPcPart> CategoryPcParts
            => _CategoryPcParts ??= new GenericRepository<Shared.Domain.CategoryPcPart>(_context);
        public IGenericRepository<Shared.Domain.PcPartImage> PcPartImages
            => _PcPartImages ??= new GenericRepository<Shared.Domain.PcPartImage>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            {
                //To be implemented
                //string user = "System";

                //var entries = _context.ChangeTracker.Entries()
                //    .Where(q => q.State == EntityState.Modified ||
                //        q.State == EntityState.Added);

                //foreach (var entry in entries)
                //{
                //    ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                //    ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                //    if (entry.State == EntityState.Added)
                //    {
                //        ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                //        ((BaseDomainModel)entry.Entity).CreatedBy = user;
                //    }
                //}

                await _context.SaveChangesAsync();
            }
        }
    }
}
