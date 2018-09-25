using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class UserModelCtx : DbContext
    {
        public UserModelCtx(DbContextOptions<UserModelCtx> options)
           : base(options)
        {
            //base.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
