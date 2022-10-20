namespace Sistema.Bancario.Dominio.Classes
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
        public int IdContaCorrente { get; private set; }

        public Cliente(int id, string nome, int idade, string email, int idContaCorrente, bool ativo)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Email = email;
            IdContaCorrente = idContaCorrente;
            Ativo = ativo;
        }

        public bool EstaAtivo()
            => Ativo;

        public void MudarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        /// <summary>
        /// Método que retorna a representação textual de um cliente. </summary>
        /// <returns> representação textual de um cliente </returns>
        public override string ToString()
        {
            return "=========================\n" + "Id: " + Id + "\n" + "Nome: " + Nome + "\n" + "Email: " + Email + "\n" + "Idade: " + Idade + "\n" + "Status: " + (Ativo ? "Ativo" : "Inativo") + "\n" + "=========================";
        }
    }
}
