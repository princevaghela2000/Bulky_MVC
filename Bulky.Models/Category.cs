using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    //[Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage = "Category Name length Name should not be greater than 30.")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The Display Order must be between 1 and 100.")]
        public int DisplayOrder { get; set; }
    }
}
