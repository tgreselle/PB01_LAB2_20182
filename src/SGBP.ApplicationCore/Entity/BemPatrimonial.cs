using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.ApplicationCore.Entity
{
    public class BemPatrimonial
    {
        public int BemPatrimonialId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int NumeroTombo { get; set; }
        public string Descricao { get; set; }


        public int ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }

        public List<BemPatrimonialAuditoria> BemPatrimonialAuditoria { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
