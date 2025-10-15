using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Minimal.Dominios.DTOs
{
    public class veiculoDTO
    {
    
         public string Nome { get; set; } = default!;
        public string Marca { get; set; } = default!;
    }
}