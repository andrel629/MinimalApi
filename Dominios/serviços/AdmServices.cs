using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minimal.Dominios.DTOs;
using Minimal.Dominios.entidades;
using Minimal.Infraestrutura.Db;
using Minimal.Infraestrutura.interfaces;

namespace Minimal.Dominios.serviços
{
    public class AdmServices : iAdministradorServicos
    {
        private readonly DBContext _dbContext;

        public AdmServices(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Administrador Criar(Administrador administrador)
        {
            _dbContext.Administrador.Add(administrador);
            _dbContext.SaveChanges();

            return administrador;
        }

        public List<Administrador> Listar(int pag)
        {
             int intensPorPag = 10;
          
                
                _dbContext.Administrador.Skip((pag- 1) * intensPorPag).Take(intensPorPag);
                return _dbContext.Administrador.ToList();
            
        }

        public Administrador Login(LoginDTO loginDTO)
        {
            var admUser = _dbContext.Administrador.Where(a => a.Email == loginDTO.Login && a.Senha == loginDTO.Senha).FirstOrDefault();
            return admUser;
        }
    }
}