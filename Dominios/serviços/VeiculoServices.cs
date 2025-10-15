using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minimal.Dominios.entidades;
using Minimal.Infraestrutura.Db;
using Minimal.Infraestrutura.interfaces;

namespace Minimal.Dominios.serviços
{
    public class VeiculoServices : iVeiculosServices
    {
        private readonly DBContext _dbcontext;

       

        public VeiculoServices(DBContext dBContext)
        {
            _dbcontext = dBContext;
            
        }
        public void Apagar(Veiculo? veiculo)
        {

            if(veiculo!=null){_dbcontext.Veiculos.Remove(veiculo);}
            _dbcontext.SaveChanges();
        
        }

        public void Atualizar(Veiculo veiculo)
        {
            _dbcontext.Veiculos.Update(veiculo);
            _dbcontext.SaveChanges();
       
        }

        public Veiculo? BuscarPorId(int id)
        {
            return _dbcontext.Veiculos.Where(v => v.Id == id).FirstOrDefault();

        }

        public Veiculo Incluir(Veiculo veiculo)
        {
            _dbcontext.Veiculos.Add(veiculo);
            _dbcontext.SaveChanges();
            return veiculo;
        }

        public List<Veiculo>? Todos(int pagination = 1, string? nome = null, string? marca = null)
        {
            int intensPorPag = 10;
            if (!string.IsNullOrEmpty(nome))
            {
                var x = _dbcontext.Veiculos.Where(v => v.Nome == nome);
                _dbcontext.Veiculos.Skip((pagination - 1) * intensPorPag).Take(intensPorPag);
                return x.ToList();

            }
            else if (!string.IsNullOrEmpty(marca))
            {
                var x = _dbcontext.Veiculos.Where(v => v.Marca == marca);
                _dbcontext.Veiculos.Skip((pagination - 1) * intensPorPag).Take(intensPorPag);
                return x.ToList();
            }
            else
            {
                return _dbcontext.Veiculos.ToList();
            }
            
        }
    }
}