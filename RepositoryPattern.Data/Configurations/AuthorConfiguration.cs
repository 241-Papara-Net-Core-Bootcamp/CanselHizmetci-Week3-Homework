using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Data.Configurations
{
    internal class AuthorConfiguration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.Bio).IsRequired();
        }
    }
}
