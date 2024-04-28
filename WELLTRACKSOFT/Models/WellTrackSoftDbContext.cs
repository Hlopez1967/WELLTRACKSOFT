using Microsoft.EntityFrameworkCore;

namespace WELLTRACKSOFT.Models
{
    public class WellTrackSoftDbContext:DbContext
    {
        
        public WellTrackSoftDbContext(DbContextOptions<WellTrackSoftDbContext> options) : base(options)
        {
            ///NO USAR //NO USAR  /*/NO TIENE NINGUNA FUNCION
        }
       

        public virtual DbSet<TranscationsLog> TranscationsLogs { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            base.OnModelCreating(builder);
        }

    }
}
