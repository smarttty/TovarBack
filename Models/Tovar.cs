using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace test_backend_11_2023.Models
{
    public partial class Tovar
    {
        public Tovar()
        {
            Tovarvzakaze = new HashSet<Tovarvzakaze>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Tovarvzakaze> Tovarvzakaze { get; set; }
    }
}
