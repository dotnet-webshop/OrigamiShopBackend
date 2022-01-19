using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Api.Models
{

    public class Option
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductOptions> Products;

    }
}