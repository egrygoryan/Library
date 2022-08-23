using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities {
    public class BookConfiguration : IEntityTypeConfiguration<BookModel> {
        public void Configure(EntityTypeBuilder<BookModel> builder) {
            builder.HasData(
                new BookModel { 
                    Id = 1,
                    Title = "Adventures of Hercules",
                    Year = 1992 
                },
                new BookModel {
                    Id = 2,
                    Title = "Rain",
                    Year = 1981
                });
        }
    }
}