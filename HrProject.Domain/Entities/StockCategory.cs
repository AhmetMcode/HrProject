﻿using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class StockCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
