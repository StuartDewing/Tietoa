namespace Services.NHL.NhlRequest

{
    public interface INhlRequest
    {
        Task<string> NHLGetResponse(string urlSegment);
    }
}
