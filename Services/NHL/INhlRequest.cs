using Tietoa.Domain.Models.Draft;

namespace Services.NHL.NhlRequest

{
    public interface INhlRequest
    {
        Task<string> NhlGetResponse(string urlSegment);
    }
}
