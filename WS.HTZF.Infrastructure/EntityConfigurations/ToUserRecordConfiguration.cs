using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 
    /// </summary>
    public class ToUserRecordConfiguration:EntityTypeConfiguration<ToUserRecord>
    {
        public ToUserRecordConfiguration()
        {
            Property(c => c.RewardCash).IsRequired();
            Property(c => c.CoustomerId).IsRequired();
            Property(c => c.ToUserId).IsRequired();
            Property(c => c.Source).IsRequired().HasMaxLength(200);
        }
    }
}
