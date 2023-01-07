using Tietoa.Domain.Models.Draft;

namespace Services.NHL.Interface

{
    public interface INhlRequest
    {
        Task<string> NhlGetResponse(string urlSegment);
    }
}
