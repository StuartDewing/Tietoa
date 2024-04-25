namespace Services.NHL.Interface

{
    public interface INhlRequest
    {
        Task<string> NhlApiResponse(string urlSegment);
    }
}