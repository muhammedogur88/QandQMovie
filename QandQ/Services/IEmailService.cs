using QandQ.DTOs;

namespace QandQ.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}