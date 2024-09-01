using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SalesBaseOfferService : BaseRepository<SalesBaseOffer>, ISalesBaseOfferService
    {
        public SalesBaseOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
