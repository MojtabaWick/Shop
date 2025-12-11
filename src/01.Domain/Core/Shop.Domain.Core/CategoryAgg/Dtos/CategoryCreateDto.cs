using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Core.CategoryAgg.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "وارد کردن اسم اجباری است.")]
        [StringLength(100, ErrorMessage = "اسم نمیتواند بیشتر از 100 کاراکتر باشد.")]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}