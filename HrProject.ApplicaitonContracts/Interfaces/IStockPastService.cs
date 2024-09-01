﻿using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IStockPastService : IBaseRepository<StockPast>
    {
        public IEnumerable<StockPast> GetIncludeOutWaybill();
    }
}
