using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UrgencyMap : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.Property(I => I.Description).HasMaxLength(100);
        }
    }
}
