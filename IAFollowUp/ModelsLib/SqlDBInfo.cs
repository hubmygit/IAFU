using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            //connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            //read it from app.config
            string strConnStr = System.Configuration.ConfigurationManager.AppSettings["connStr"];
            string strPassPhrase = System.Configuration.ConfigurationManager.AppSettings["passPhrase"];

            //decrypt it 
            connectionString = CryptoFuncs.DecryptStringFromHex_Aes(strConnStr);
            passPhrase = CryptoFuncs.DecryptStringFromHex_Aes(strPassPhrase);
        }

        public static string connectionString { get; set; }
        public static string passPhrase { get; set; }
    }
}
