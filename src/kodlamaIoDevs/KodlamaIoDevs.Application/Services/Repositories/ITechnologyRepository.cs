using Core.Persistence.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.Repositories
{
    public interface ITechnologyRepository:IAsyncRepository<Technology>,IRepository<Technology>
    {
    }
}
