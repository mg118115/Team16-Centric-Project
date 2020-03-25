using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Team_16_Centric_Project.Controllers
{
    public class PeerNoteController : Controller
    {
        // GET: PeerNote
        public ActionResult Index()
        {
            SmtpClient myClient = new SmtpClient();
            // the following line has to contain the email address and password of someone
            // authorized to use the email server (you will need a valid Ohio account/password
            // for this to work)
            myClient.Credentials = new NetworkCredential("AuthorizedUser", "UserPassword");
            MailMessage myMessage = new MailMessage();

            // the syntax here is email address, username (that will appear in the email)
            MailAddress from = new MailAddress("gb538515@ohio.edu", "SysAdmin");
            myMessage.From = from;
            myMessage.To.Add("gb538515@gmail.com"); // this should be replaced with model data
                                                    // as shown at the end of this document
            myMessage.Subject = "MVC Email test";
            // the body of the email is hard coded here but could be dynamically created using data
            // from the model- see the note at the end of this document
            myMessage.Body = "This is the body of the mail message. This can be essentially any length, and could come ";
        myMessage.Body += "from the database, a variable, the return of another method...";

            try
            {
                myClient.Send(myMessage);
                TempData["mailError"] = "";
            }
            catch (Exception ex)
            {
                // this captures an Exception and allows you to display the message in the View
                TempData["mailError"] = ex.Message;
            }

            return View();
        }
    }
}