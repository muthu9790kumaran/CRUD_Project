
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Project.Models
{
    public class Crud
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string? ProductName { get; set; }
       
        [Required]
        [Display(Name = "Product Quantity")]
        public string? ProductQty { get; set; }
        [Required]
        
        [Range(10, 10000)]
        public string? Price { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? City { get; set; }




    }



    public class Pdatabase : DbContext
    {
        public Pdatabase(DbContextOptions<Pdatabase> options) : base(options)
        {

        }
        [Display(Name = "Product Details")]
        public DbSet<Crud> Product_Detail { get; set; }
       
    }

}


