using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Models.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public CountryDTO (int id)
        {
            Id = id;
        }
    }
}
