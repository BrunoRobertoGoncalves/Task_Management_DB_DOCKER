namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ?Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}
