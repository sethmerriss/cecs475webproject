using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug2Bug.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public String ProductISBN { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(100), Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        //[Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        //public string Description { get; set; }

        public int EditionNumber { get; set; }

        [Display(Name = "Price")]
        public decimal? UnitPrice { get; set; }

        public string copyright { get; set; }



        //public int? CategoryID { get; set; }

        //public virtual Category Category { get; set; }
    }
}