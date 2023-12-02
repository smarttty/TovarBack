using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace test_backend_11_2023.Models
{
    public partial class Tovarvzakaze
    {
        public int Id { get; set; }
        public int TovarId { get; set; }
        public int ZakazId { get; set; }

        public virtual Tovar Tovar { get; set; }
        public virtual Zakaz Zakaz { get; set; }
    }
}
