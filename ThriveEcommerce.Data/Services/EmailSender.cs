using System.Threading.Tasks;

namespace ThriveEcommerce.Data.Services
{
    public class EmailSender
    { 
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
