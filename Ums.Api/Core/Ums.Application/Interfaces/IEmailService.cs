using Ums.Application.DTOs.Email;
using System.Threading.Tasks;

namespace Ums.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}