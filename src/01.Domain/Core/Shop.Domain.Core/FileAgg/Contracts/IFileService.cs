using Microsoft.AspNetCore.Http;

namespace Shop.Domain.Core.FileAgg.Contracts
{
    public interface IFileService
    {
        public Task<string> Upload(IFormFile file, string folder, CancellationToken cancellationToken);

        public Task DeleteByUrlAsync(string url, CancellationToken cancellationToken);
    }
}