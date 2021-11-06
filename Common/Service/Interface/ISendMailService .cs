using Common.ViewModel;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
