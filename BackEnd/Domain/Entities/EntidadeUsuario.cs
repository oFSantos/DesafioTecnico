using System;
using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Entities
{    
    public class EntidadeUsuario
    {
        [Key]
        public Guid Id { get; set; } 
        public string NomeUsuario { get; set; }
        public string SenhaHash{ get; set; }
    }
}
