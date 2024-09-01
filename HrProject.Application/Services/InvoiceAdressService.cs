﻿using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceAdressService : BaseRepository<InvoiceAdress>, IInvoiceAdressService
    {
        public InvoiceAdressService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
