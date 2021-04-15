using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Models
{
    public class ExchangeSettingsContext : DbContext
    {
        public DbSet<ExchangeSettings> Settings { get; set; }

        public ExchangeSettingsContext(DbContextOptions<ExchangeSettingsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
