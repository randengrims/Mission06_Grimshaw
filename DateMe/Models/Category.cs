using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
