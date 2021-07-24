using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repositories.DataContext
{
    public class Item
    {
        [Key]
        public string ItemName { get; set; }
        public int ItemId { get; set; }
    }
}
