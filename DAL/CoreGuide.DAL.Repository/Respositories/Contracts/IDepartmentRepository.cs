﻿using CoreGuide.Common.GenericRepository.Respository;
using CoreGuide.DAL.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreGuide.DAL.Repository.Respositories.Contracts
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<bool> DoesDepartmentExistAsync(int id, CancellationToken cancellationToken);
    }
}
