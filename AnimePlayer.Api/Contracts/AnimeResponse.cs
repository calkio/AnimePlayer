namespace AnimePlayer.Api.Contracts
{
    public record AnimeResponse(
        Guid id,
        string Title,
        string Description,
        int YearIssue);
}
