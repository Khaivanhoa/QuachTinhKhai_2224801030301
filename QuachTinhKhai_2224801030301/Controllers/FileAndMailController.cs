using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuachTinhKhai_2224801030301.Models;

namespace QuachTinhKhai_2224801030301.Controllers
{
    public class FileAndMailController : Controller
    {
        // GET: FileAndMail
        SachOnlineEntities db = new SachOnlineEntities();
        // GET: Admin/FileAndMail
        [HttpGet]
        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(Mail model)
        {

            // Cấu hình thông tin Gmail
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("tinhkhai2004@gmail.com", "gpkb gbho pylt iush"),
                EnableSsl = true
            };

            // Tạo email
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Notes;

            var f = Request.Files["attachment"];
            var path = Path.Combine(Server.MapPath("~/UploadFile"), f.FileName);
            if (!System.IO.File.Exists(path))
            {
                f.SaveAs(path);

            }
            Attachment data = new Attachment(Server.MapPath("~/UploadFile/" + f.FileName), MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);
            mail.Send(message);
            return View("SendMail");
        }


    }
}