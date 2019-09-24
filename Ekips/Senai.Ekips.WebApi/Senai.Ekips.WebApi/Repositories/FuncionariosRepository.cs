using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        public void Cadastrar(Funcionarios funcionario)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        public List<Funcionarios> ListarTodos()
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.Include(funcionariosCargos => funcionariosCargos.IdCargoNavigation).Include(funcionariosDepartamentos => funcionariosDepartamentos.IdDepartamentoNavigation).ToList();
            }
        }

        public List<Funcionarios> BuscarDadosFuncionario(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
                return funcionarioBuscado != null? ctx.Funcionarios.First(x => x.IdFuncionario == id).Include(x => x.IdCargoNavigation)

            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
               return ctx.Funcionarios.Find(id);
            }
        }

        public void Atualizar(Funcionarios funcionarioModificado)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionarioEncontrado = BuscarPorId(funcionarioModificado.IdFuncionario);
                if (funcionarioEncontrado == null)
                    throw new System.ArgumentException("Este funcionário provavelmente não existe.");

                funcionarioEncontrado.Cpf = funcionarioModificado.Cpf;
                funcionarioEncontrado.DataNascimento = funcionarioModificado.DataNascimento;
                funcionarioEncontrado.IdCargo = funcionarioModificado.IdCargo;
                funcionarioEncontrado.IdDepartamento = funcionarioModificado.IdDepartamento;
                funcionarioEncontrado.IdUsuarioVinculado = funcionarioModificado.IdUsuarioVinculado;
                funcionarioEncontrado.Nome = funcionarioModificado.Nome;
                funcionarioEncontrado.Salario = funcionarioModificado.Salario;

                ctx.Funcionarios.Update(funcionarioEncontrado);
                ctx.SaveChanges();
            }
        }
        
        public void Deletar(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                if (BuscarPorId(id) == null)
                {
                    throw new System.ArgumentException("Este funcionário não existe ou mão foi encontrado");
                }
                else
                {
                    ctx.Funcionarios.Remove(BuscarPorId(id));
                    ctx.SaveChanges();
                }
            }
        }
    }
}
