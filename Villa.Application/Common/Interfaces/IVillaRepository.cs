﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Common.Interfaces
{
    public interface IVillaRepository:IRepository<Vila>
    {
        void Update(Vila entity);
       
    }
}
