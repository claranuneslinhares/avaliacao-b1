namespace avaliacao_b1.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string Curso { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}