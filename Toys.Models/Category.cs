using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Toys.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required] // Ensure Title is required
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Title { get; set; } // Keep the property name as 'Title'
       
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public string DisplayOrder { get; set; }
    }
}
