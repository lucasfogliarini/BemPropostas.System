namespace BemPropostas
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public DateTime DataCadastro { get; private set; }

        // Relacionamentos
        public List<Proposta> Propostas { get; private set; } = new();

        // Construtor para EF Core
        private Cliente() { }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, string telefone, Endereco endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            DataCadastro = DateTime.UtcNow;
        }

        public bool EhMaiorDeIdade()
        {
            var idade = DateTime.UtcNow.Year - DataNascimento.Year;
            if (DataNascimento.Date > DateTime.UtcNow.AddYears(-idade)) idade--;
            return idade >= 18;
        }
    }

}
