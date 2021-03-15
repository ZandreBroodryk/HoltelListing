﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoltelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        
        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}