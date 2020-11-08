using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archimydes.BusinessLogic
{
    public class BusinessLoginHelper
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}