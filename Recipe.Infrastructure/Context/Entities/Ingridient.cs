using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Context.Entities
{
    public class Ingredient: BaseEntity
    {
        public string Name { get; set; }
        public decimal Proportion { get; set; }
        public decimal Calories { get; set; }
        public decimal Cholesterol { get; set; }
        public decimal FatSaturated { get; set; }
        public decimal FatTotal { get; set; }
        public int MeasuresType { get; set; }
        public decimal Potassium { get; set;}
        public decimal Protein { get; set; }
        public decimal Sodium { get; set; }
    }
}
