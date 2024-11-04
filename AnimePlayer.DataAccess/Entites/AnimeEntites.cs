namespace AnimePlayer.DataAccess.Entites
{
    public class AnimeEntites
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int YearIssue { get; set; }
    }
}
