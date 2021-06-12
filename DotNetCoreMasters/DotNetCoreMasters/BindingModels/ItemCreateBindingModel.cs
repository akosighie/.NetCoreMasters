using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreMasters.BindingModels
{
    public class ItemCreateBindingModel
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string itemString { get; set; }
    }
}
