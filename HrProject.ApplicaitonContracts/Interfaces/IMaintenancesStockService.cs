﻿using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMaintenancesStockService : IBaseRepository<MaintenancesStock>
    {
        public IEnumerable<MaintenancesStock> GetIncludeMaintenancesStock();
    }
}
