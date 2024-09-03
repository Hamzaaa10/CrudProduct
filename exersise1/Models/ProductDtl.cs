using System.ComponentModel.DataAnnotations;

namespace exersise1.Models
{
    public class ProductDtl{

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        public string prand { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string Category { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]

        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public int Price { get; set; }
        public IFormFile? Imgurl { get; set; }
    }
}
