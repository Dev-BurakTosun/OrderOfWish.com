﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfWish.Services.ASPWebAPI.Models
{
    public class GenreDTO
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
