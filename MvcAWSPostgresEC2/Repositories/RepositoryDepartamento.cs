using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentosContext context;

        public RepositoryDepartamento(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
            => await this.context.Departamentos.ToListAsync();

        public async Task<Departamento> FindDepartamentoAsync(int iddepartamento)
            => await this.context.Departamentos.Where(x => x.IdDepartamento == iddepartamento).FirstAsync();

        public async Task CreateDepartamentoAsync(int id, string nombre , string loc)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = loc;

            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        
        }

    }
}
