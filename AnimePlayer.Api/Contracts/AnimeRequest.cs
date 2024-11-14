namespace AnimePlayer.Api.Contracts
{
    public record AnimeRequest(
        Guid id,
        string Title,
        string Description,
        int YearIssue);
}
