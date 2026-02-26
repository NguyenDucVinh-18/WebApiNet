using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiNet.Data
{
    [Table("Category")]   
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
