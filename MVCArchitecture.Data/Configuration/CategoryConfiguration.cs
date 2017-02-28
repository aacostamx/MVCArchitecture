using MVCArchitecture.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace MVCArchitecture.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
