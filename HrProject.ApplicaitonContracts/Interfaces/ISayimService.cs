using System;
using HrProject.Domain.Entities;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ISayimService
    {
        void AddSubSayim(SubSayim subSayim);
        SubSayim GetSubSayimById(int id);
        void UpdateSubSayim(SubSayim subSayim);
        IEnumerable<SubSayim> GetOngoingSubSayims();

        void AddStockChange(StockChange stockChange);
        Stock GetStockById(int stockId);
    }
}

