using System;
using System.Collections.Generic;
using System.Text;

namespace LedocHomeApp.Models
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Make { get; set; }
        public bool Mobile { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Responsible { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
