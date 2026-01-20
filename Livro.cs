public class Livro
{
	public int Tombo { get; set; }
	public string Titulo { get; set; }
	public string Status { get; set; }
	public string Locatario { get; set; }

	// Construtor
	public Livro(int tombo, string titulo)
	{
		Tombo = tombo;
		Titulo = titulo;
		Status = "Disponível";
		Locatario = "";
	}

	// Método para emprestar o livro
	public void Emprestar(string nomeLocatario)
	{
		Status = "Emprestado";
		Locatario = nomeLocatario;
	}

	// Método para devolver o livro
	public void Devolver()
	{
		Status = "Disponível";
		Locatario = "";
	}
}