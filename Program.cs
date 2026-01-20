class Program
{
	static void Main(string[] args)
	{
		// Criar a biblioteca
		Biblioteca biblioteca = new Biblioteca();

		// Cadastrar alguns livros iniciais
		biblioteca.CadastrarLivro(new Livro(1, "Dom Casmurro"));
		biblioteca.CadastrarLivro(new Livro(2, "1984"));
		biblioteca.CadastrarLivro(new Livro(3, "O Pequeno Príncipe"));
		biblioteca.CadastrarLivro(new Livro(4, "Harry Potter e a Pedra Filosofal"));
		biblioteca.CadastrarLivro(new Livro(5, "O Senhor dos Anéis"));

		// Variável para controlar o menu
		int opcao = 0;

		// Loop do menu principal
		while (opcao != 3)
		{
			ExibirMenu();
			opcao = int.Parse(Console.ReadLine());

			switch (opcao)
			{
				case 1:
					biblioteca.ListarLivros();
					break;
				case 2:
					RealizarEmprestimo(biblioteca);
					break;
				case 3:
					Console.WriteLine("\nEncerrando o sistema. Até logo!");
					break;
				default:
					Console.WriteLine("\nOpção inválida! Tente novamente.");
					break;
			}
		}
	}

	// Exibir o menu
	static void ExibirMenu()
	{
		
		Console.WriteLine("   SISTEMA DE BIBLIOTECA            ");		
		Console.WriteLine("1 - Listar todos os livros");
		Console.WriteLine("2 - Emprestar um livro");
		Console.WriteLine("3 - Sair");
		Console.Write("\nEscolha uma opção: ");
	}

	// Realizar empréstimo
	static void RealizarEmprestimo(Biblioteca biblioteca)
	{
		Console.WriteLine("\n=== EMPRÉSTIMO DE LIVRO ===");

		// Cadastrar o locatário
		Console.Write("Digite o nome do locatário: ");
		string nomeLocatario = Console.ReadLine();

		int proximoID = biblioteca.Pessoas.Count + 1;
		Pessoa pessoa = new Pessoa(proximoID, nomeLocatario);
		biblioteca.CadastrarUsuario(pessoa);

		// Listar livros disponíveis
		Console.WriteLine("\nLivros disponíveis:");
		biblioteca.ListarLivros();

		// Escolher o livro
		Console.Write("Digite o tombo do livro desejado: ");
		int tomboEscolhido = int.Parse(Console.ReadLine());

		Livro livroEscolhido = biblioteca.BuscarLivroPorTombo(tomboEscolhido);

		if (livroEscolhido == null)
		{
			Console.WriteLine("\nLivro não encontrado!");
			return;
		}

		if (livroEscolhido.Status == "Emprestado")
		{
			Console.WriteLine("\nEste livro já está emprestado!");
			return;
		}

		// Realizar o empréstimo
		biblioteca.EmprestarLivro(livroEscolhido, pessoa);
	}
}