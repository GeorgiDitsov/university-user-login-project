using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UserLogin
{
    class LogsContext : DbContext
    {
        public LogsContext() : base(Properties.Settings.Default.DbConnect)
        { }

        public DbSet<Logs> Logs 
        { get; set; }
    }
}
