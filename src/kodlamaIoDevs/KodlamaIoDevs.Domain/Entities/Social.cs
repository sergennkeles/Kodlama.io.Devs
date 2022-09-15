using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Domain.Entities
{
    public class Social:Entity
    {
        public int UserId { get; set; }
        public string Url { get; set; }

        public virtual User User { get; set; }

        public Social(int id,int userId,string url )
        {
            Url = url;
            UserId = userId;
            Id = id;    
        }

        public Social()
        {

        }
    }
}
