using Microsoft.EntityFrameworkCore;
using avaliacao_b1.Models;

namespace avaliacao_b1.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}