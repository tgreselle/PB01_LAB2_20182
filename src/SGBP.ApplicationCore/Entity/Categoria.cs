using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.ApplicationCore.Entity
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }

        public List<BemPatrimonial> BemPatrimonials { get; set; }
    }
}
