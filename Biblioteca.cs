using System;

public class Biblioteca
{
	public List<Livro> Livros { get; set; }
	public List<Pessoa> Pessoas { get; set; }

	// Construtor
	public Biblioteca()
	{
		Livros = new List<Livro>();
		Pessoas = new List<Pessoa>();
	}

	// Cadastrar um livro
	public void CadastrarLivro(Livro livro)
	{
		Livros.Add(livro);
	}

	// Cadastrar um usuário
	public void CadastrarUsuario(Pessoa pessoa)
	{
		Pessoas.Add(pessoa);
	}

	// Listar todos os livros
	public void ListarLivros()
	{
		Console.WriteLine("\n=== LIVROS DA BIBLIOTECA ===");
		foreach (var livro in Livros)
		{
			Console.WriteLine($"Tombo: {livro.Tombo} | Título: {livro.Titulo} | Status: {livro.Status}");
			if (livro.Status == "Emprestado")
			{
				Console.WriteLine($"  → Emprestado para: {livro.Locatario}");
			}
		}
		Console.WriteLine("============================\n");
	}

	// Emprestar um livro
	public void EmprestarLivro(Livro livro, Pessoa pessoa)
	{
		livro.Emprestar(pessoa.Nome);
		pessoa.PegarLivro(livro);
		Console.WriteLine($"\nLivro '{livro.Titulo}' emprestado para {pessoa.Nome} com sucesso!");
	}

	// Buscar livro por tombo
	public Livro BuscarLivroPorTombo(int tombo)
	{
		foreach (var livro in Livros)
		{
			if (livro.Tombo == tombo)
			{
				return livro;
			}
		}
		return null;
	}
}
