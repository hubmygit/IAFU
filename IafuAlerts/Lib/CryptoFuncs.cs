﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace IafuAlerts
{
    public class CryptoFuncs
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes(MyBytes.getKey());
            byte[] IV = System.Text.Encoding.Unicode.GetBytes(MyBytes.getIV());

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromHex_Aes(string cipherText)
        {
            //string to byte[]
            byte[] encrypted = StringToByteArray(cipherText);

            //decrypt it 
            return DecryptStringFromBytes_Aes(encrypted);
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes(MyBytes.getKey());
            byte[] IV = System.Text.Encoding.Unicode.GetBytes(MyBytes.getIV());

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static byte[] EncryptBytesToBytes_Aes(byte[] fileContents)
        {
            string str = BitConverter.ToString(fileContents).Replace("-", string.Empty);
            return EncryptStringToBytes_Aes(str);
        }

        public static byte[] DecryptBytesFromBytes_Aes(byte[] cipherText)
        {
            string str = BitConverter.ToString(cipherText).Replace("-", string.Empty);
            byte[] encrypted = StringToByteArray(str);
            str = DecryptStringFromBytes_Aes(encrypted);

            return StringToByteArray(str);
        }

       

    }
}
