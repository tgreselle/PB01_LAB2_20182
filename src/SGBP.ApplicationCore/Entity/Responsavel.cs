using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.ApplicationCore.Entity
{
    public class Responsavel
    {
        public int ResponsavelId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<BemPatrimonial> BemPatrimonials { get; set; }

        public Endereco Endereco { get; set; }
    }
}
