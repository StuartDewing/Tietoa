namespace Services.NHL

{
    public interface INhlDraftService
    {
        Task<string> GetDraftByYear(int year);
    }
}
