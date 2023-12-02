using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace test_backend_11_2023.Models
{
    public partial class Zakaz
    {
        public Zakaz()
        {
            Tovarvzakaze = new HashSet<Tovarvzakaze>();
        }

        public int Id { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Deliverydate { get; set; }
        public string Client { get; set; }

        public virtual ICollection<Tovarvzakaze> Tovarvzakaze { get; set; }
    }
}
