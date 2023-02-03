using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vendinhaApi.Models;

namespace vendinhaApi.Map
{
    public class SaleListMap : IEntityTypeConfiguration<SaleList>
    {
        public void Configure(EntityTypeBuilder<SaleList> builder)
        {
            builder.HasKey(x => x.SaleListId);
        }
    }
}
