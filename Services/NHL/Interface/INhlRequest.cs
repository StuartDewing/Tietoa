namespace Services.NHL.Interface

{
    public interface INhlRequest
    {
        Task<string> NhlGetResponse(string urlSegment);
    }
}