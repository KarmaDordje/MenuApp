using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.Dtos
{
    public class ProductDTO
    {

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        public decimal Calories { get; private set; }
        public decimal Cholesterol { get; private set; }
        public decimal FatSaturated { get; private set; }
        public decimal FatTotal { get; private set; }
        public decimal Potassium { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Sodium { get; private set; }
        public decimal Quantity { get; set; }
        public decimal Sugar { get; set; }
        public Measurement Measurement { get; set; }
    }
}
