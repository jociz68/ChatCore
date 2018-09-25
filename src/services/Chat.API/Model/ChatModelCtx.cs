using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Model
{
    public class ChatModelCtx : DbContext
    {
        public ChatModelCtx(DbContextOptions<ChatModelCtx> options)
            : base(options)
        {
            //base.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

    }
}
