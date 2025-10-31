using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Data.Configuration.Base
{
    public class BaseAudiatbleConfig <Tkey,TEntity> : BaseEntityConfig<Tkey, TEntity>
        where TEntity :BaseAuditable<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CreatedOn)
                  .HasDefaultValue(DateTime.UtcNow);

            builder.Property(p => p.LastModifiedOn)
                   .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
