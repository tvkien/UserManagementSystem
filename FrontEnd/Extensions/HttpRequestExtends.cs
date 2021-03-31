using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Extensions
{
    public static class HttpRequestExtends
    {
        public async static Task<HttpContent> GetContentAsync(this HttpContext httpContext)
        {
            if(httpContext.Request.ContentLength == null)
            {
                return new StringContent("");
            }

            using var reader = new StreamReader(httpContext.Request.Body);
            var body = await reader.ReadToEndAsync();
            return new StringContent(body, Encoding.UTF8, httpContext.Request.ContentType);
        }
    }
}