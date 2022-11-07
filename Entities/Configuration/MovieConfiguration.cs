using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities {
    public class MovieConfiguration : IEntityTypeConfiguration<Movie> {
        public void Configure(EntityTypeBuilder<Movie> builder) {
            builder.HasData(
                new Movie { 
                    Id = 1,
                    Title = "Adventures of Hercules",
                    Year = 1992,
                    Genre = "Comedy"
                },
                new Movie {
                    Id = 2,
                    Title = "Rain",
                    Year = 1981,
                    Genre = "Drama"
                });
        }
    }
}