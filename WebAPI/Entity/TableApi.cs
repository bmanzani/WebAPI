using System;
using System.Collections.Generic;

namespace WebAPI.Entity
{
    public partial class TableApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cargo { get; set; }
        public double? Salario { get; set; }
    }
}
