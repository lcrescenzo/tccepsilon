using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net.Mail;

namespace SGR.BP.Util
{
    public class General
    {
        public static bool IsNullOrDisposed(object objeto)
        {
            if(objeto == null)
                return true;

            FieldInfo disposed = null;
            
            foreach(FieldInfo field in objeto.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if(field.Name == "m_fDisposed")
                {
                    disposed = field;
                }
            }
                //"m_fDisposed", 
            if (disposed == null)
            {
                return false;
            }
           

            object isDisposed = disposed.GetValue(objeto);
            if (isDisposed != null)
                if ((bool)isDisposed)
                    return true;

            return false;
                 
        }

        public static void EnviarEmail(string assunto, string conteudo, string remetente, string destinatario)
        {
            SmtpClient smtp = new SmtpClient();

            MailMessage message = new MailMessage(remetente, destinatario);

            message.Subject = assunto;
            message.IsBodyHtml = true;
            message.Body = conteudo;

            smtp.Send(message);
        }
    }
}
