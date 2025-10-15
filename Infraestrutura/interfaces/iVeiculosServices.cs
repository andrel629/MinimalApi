using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minimal.Dominios.entidades;

namespace Minimal.Infraestrutura.interfaces
{
    public interface iVeiculosServices
    {
        List<Veiculo>? Todos(int pagination = 1, string? nome = null, string? marca = null);
        Veiculo? BuscarPorId(int id);
        Veiculo Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar(Veiculo? veiculo);
        
    }
}