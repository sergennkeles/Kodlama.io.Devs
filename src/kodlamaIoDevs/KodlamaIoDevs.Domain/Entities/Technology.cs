using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Domain.Entities
{
    public class Technology : Entity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual Language Language { get; set; }

        public Technology()
        {

        }

        public Technology(int id, int languageId, string name)
        {
            Id = id;
            LanguageId = languageId;
            Name = name;


        }
    }
}
