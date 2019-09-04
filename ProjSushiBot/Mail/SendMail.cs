using System;
using System.Net;
using System.Net.Mail;

namespace project
{
  class MailSender
  {
    public void SendMail(string addr, string message)
    {
      MailAddress from = new MailAddress("testbot04092019@gmail.com");
      MailAddress to = new MailAddress(addr);
      MailMessage m = new MailMessage(from, to);

      m.Subject = "Test";
      m.Body = message;
      m.IsBodyHtml = true;

      SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

      smtp.Credentials = new NetworkCredential("testbot04092019@gmail.com", "password0409");
      smtp.EnableSsl = true;
      smtp.Send(m);

      Console.Read();
    }
  }
}