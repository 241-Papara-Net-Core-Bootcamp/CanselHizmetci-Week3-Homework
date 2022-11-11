using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Data.Configurations
{
    internal class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Genre).IsRequired();
        }
    }
}
