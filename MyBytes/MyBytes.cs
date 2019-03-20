using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBytes
{
    public class MyBytes
    {
        public static string getKey()
        {
            string ret = "";

            var KeyByteArray = new List<byte>();
            KeyByteArray.Add(0x6D);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x4B);
            KeyByteArray.Add(0x65);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x6D);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x4B);
            KeyByteArray.Add(0x65);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x6D);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x4B);
            KeyByteArray.Add(0x65);
            KeyByteArray.Add(0x79);
            KeyByteArray.Add(0x21);
            byte[] newKey = KeyByteArray.ToArray();
            ret = System.Text.Encoding.Default.GetString(newKey);

            return ret;
        }

        public static string getIV()
        {
            string ret = "";

            var IVByteArray = new List<byte>();
            IVByteArray.Add(0x6D);
            IVByteArray.Add(0x79);
            IVByteArray.Add(0x49);
            IVByteArray.Add(0x56);
            IVByteArray.Add(0x6D);
            IVByteArray.Add(0x79);
            IVByteArray.Add(0x49);
            IVByteArray.Add(0x56);
            byte[] newIV = IVByteArray.ToArray();
            ret = System.Text.Encoding.Default.GetString(newIV);

            return ret;
        }
    }
}
