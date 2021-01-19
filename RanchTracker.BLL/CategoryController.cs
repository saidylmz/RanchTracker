using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.BLL
{
    public class CategoryController
    {
        CategoryDAL categoryDAL;
        CattleDAL cattleDAL;
        TokenDAL tokenDAL;
        public CategoryController()
        {
            categoryDAL = new CategoryDAL();
            cattleDAL = new CattleDAL();
            tokenDAL = new TokenDAL();
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = categoryDAL.GetAll();
            return categories;
        }
         
        public void Email()
        {
           

            
            Kontrol();
            KuruyaAlinma();
        }

        private void Kontrol()
        { 
            List<Cattle> cattles = cattleDAL.GetAll().Where(x =>x.Inseminations.Count() > 0 && x.Inseminations.Last().Result == true && (DateTime.Now.Subtract(x.Inseminations.Last().Date).Days == 45)).ToList();

            foreach (var item in cattles)
            {
                try
                {
                    string[] tokens = new string[tokenDAL.GetAll().Where(x=>x.RanchID == item.RanchID).Count()];
                    int counter = 0;
                    foreach (var item2 in tokenDAL.GetAll().Where(x=>x.RanchID == item.RanchID))
                    {
                        tokens[counter] = item2.DeviceToken;
                        counter++;
                    }
                    string title = item.EarringNumber + " Küpeli Hayvanı Bilgilendirme : ";
                    string body = item.Name + " isimli hayvanın tohumlanma günü 45 gün olmuştur.Kontrol ettiriniz !!!";
                    var push = PushNotificationLogic.SendPushNotification(tokens, title, body, new {action = "Mühendis Bey Süt", userId=5 });

                    SmtpClient sc = new SmtpClient("smtp.muhendisbeysut.com");
                    sc.Port = 587;
                    sc.EnableSsl = false;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential("info@muhendisbeysut.com", "SIFRE");
                    sc.TargetName = "STARTTLS/smtp.muhendisbeysut.com";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@muhendisbeysut.com", "ÇiftlikApp Bilgilendirme");
                    mail.To.Add(item.Ranch.Email);
                    mail.Subject = title;
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                    sc.Send(mail);

                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void KuruyaAlinma()
        {
            List<Cattle> cattles = cattleDAL.GetAll().Where(x => x.Inseminations.Count() > 0 && x.Inseminations.Last().Result == true && (DateTime.Now.Subtract(x.Inseminations.Last().Date).Days == 210)).ToList();

            foreach (var item in cattles)
            {
                try
                {
                    string[] tokens = new string[tokenDAL.GetAll().Where(x => x.RanchID == item.RanchID).Count()];
                    int counter = 0;
                    foreach (var item2 in tokenDAL.GetAll().Where(x => x.RanchID == item.RanchID))
                    {
                        tokens[counter] = item2.DeviceToken;
                        counter++;
                    }
                    string title = item.EarringNumber + " Küpeli Hayvanı Bilgilendirme : ";
                    string body = item.Name + " isimli hayvanın tohumlanma günü 210 gün olmuştur.Hayvanı kuruya alınız !!!";
                    var push = PushNotificationLogic.SendPushNotification(tokens, title, body, new { action = "Mühendis Bey Süt", userId = 5 });

                    SmtpClient sc = new SmtpClient("smtp.muhendisbeysut.com");
                    sc.Port = 587;
                    sc.EnableSsl = false;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential("info@muhendisbeysut.com", "SIFRE");
                    sc.TargetName = "STARTTLS/smtp.muhendisbeysut.com";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@muhendisbeysut.com", "ÇiftlikApp Bilgilendirme");
                    mail.To.Add(item.Ranch.Email);
                    mail.Subject = title;
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                    sc.Send(mail);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
