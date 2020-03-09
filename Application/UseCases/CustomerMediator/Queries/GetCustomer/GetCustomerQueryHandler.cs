using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MailKit.Net.Smtp;
using MediatR;
using MimeKit;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.CustomerMediator.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDTO>
    {
        private readonly Task18Context _context;

        public GetCustomerQueryHandler(Task18Context context)
        {
            _context = context;
        }

        public async Task<GetCustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.customers.FindAsync(request.Id);

            if (data == null)
            {
                BackgroundJob.Enqueue(() => Console.WriteLine("Customer by Id is null."));
                return null;
            }
            else
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
                message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
                message.Subject = "How you doin'?";

                message.Body = new TextPart("plain")
                {
                    Text = @"Hai Langit,

                            Apa kabar?

                            -- Hujan"
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.mailtrap.io", 2525, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("c58cd8a2750dab", "8df199c377a4d5");

                    client.Send(message);
                    client.Disconnect(true);
                }


                BackgroundJob.Enqueue(() => Console.WriteLine("Customer by Id retreived."));
                return new GetCustomerDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
                    Data = new CustomerData
                    {
                        Id = data.Id,
                        Full_name = data.full_name,
                        Username = data.username,
                        Birthdate = data.birthdate,
                        Password = data.password,
                        Gender = Enum.GetName(typeof(Gender), data.sex),
                        Email = data.email,
                        Phone_number = data.phone_number
                    }
                };

            }
        }
    }
}
