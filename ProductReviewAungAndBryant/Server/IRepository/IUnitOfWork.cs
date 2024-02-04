using ProductReviewAungAndBryant.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<PcPart> PcParts { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<CategoryPcPart> CategoryPcParts { get; }
        IGenericRepository<PcPartImage> PcPartImages { get; }

    }
}