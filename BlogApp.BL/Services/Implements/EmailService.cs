using BlogApp.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class EmailService : IEmailService
    {
        public Task SendAsynv()
        {
            SmtpClient smtp = new();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("xandamei-bp215@code.edu.az", "cupv oonz gsxf ykbg");
            MailAddress from = new MailAddress("xandamei-bp215@code.edu.az", "Azərbaycan Respublikası Elm və Təhsil Nazirliyi");
            MailAddress to = new("verdiyevae48@gmail.com");
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Haqqınızda şikayət!";
            msg.Body = "<p>Elnarə Verdiyeva, haqqınızda edilən şikayətlərə görə müəllimlik vəzifəsindən sui-isdifadə edərək, müəllimlər günü adı ilə şagirdlərdən pul yığmaq, " +
                "həmçinin dərs saatlarının düzgün keçilməməsi bəyanları altında haqqınızda araşdırılma başladılmışdır. 16 Dekabr, saat 12:00 -da Nazirliyə yaxınlaşmağınız tələb olunur.</p>";
            msg.IsBodyHtml = true;
            smtp.Send(msg);
            return Ok("Sent");
        }
    }
}
