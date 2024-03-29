﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateHeroDto
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Story { get; set; }
        public IFormFile? Image { get; set; }
        public int? CityId { get; set; }
        public int? BattalionId { get; set; }
        public string? CardNumber { get; set; }
    }
}
