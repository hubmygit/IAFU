using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace IAFollowUp
{
    public class EmailParams
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string EmailAddress { get; set; }
        public string SmtpClientHost { get; set; }

        public EmailParams()
        {
            //decryption
            UserName = CryptoFuncs.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_UserName"]);
            Password = CryptoFuncs.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Password"]);
            Domain = CryptoFuncs.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Domain"]);
            EmailAddress = CryptoFuncs.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Address"]);
            SmtpClientHost = CryptoFuncs.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_SmtpClientHost"]);
        }
    }
}
