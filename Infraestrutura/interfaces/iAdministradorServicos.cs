using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minimal.Dominios.DTOs;
using Minimal.Dominios.entidades;

namespace Minimal.Infraestrutura.interfaces
{
    public interface iAdministradorServicos
    {
        Administrador Login(LoginDTO loginDTO);

        Administrador Criar(Administrador administrador);
        List<Administrador> Listar(int pag);
    }
}