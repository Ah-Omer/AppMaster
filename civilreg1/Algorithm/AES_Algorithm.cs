using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Data;

using System.ComponentModel;
using System.Drawing;

using System.Security.Cryptography;
using System.Security;
using System.IO;


namespace civilreg1
{
    class AES_Algorithm
    {


        public string Encryption(string plainText)
        {
            string R;
           // IV = { 0x49, 0x76, 0x61, 0x6e, 0x20,0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
      
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            byte[] bytes = Encoding.Unicode.GetBytes(plainText);
           
            using (Aes aesAlg = Aes.Create())
            {
                HashAlgorithm hash = MD5.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.Unicode.GetBytes("ahmedomwrsidddid"));
                aesAlg.IV = IV;

         
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

         
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }

                    R = Convert.ToBase64String(memoryStream.ToArray());
                }
               
                return R;

            }
        }

        public string Decryption(string d)
        {
         
            byte[] cipherText = Convert.FromBase64String(d);
           
      
            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
     
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

           
            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                HashAlgorithm hash = MD5.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.Unicode.GetBytes("ahmedomwrsidddid"));
                aesAlg.IV = IV;

          
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

              
                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[cipherText.Length];
                        cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                        plaintext = Encoding.Unicode.GetString(decryptedBytes);
                    }
                }
               

            }

            return plaintext;

        }
        public byte[] getiv()
        {
            Aes aesAlg = Aes.Create();
            aesAlg.GenerateIV();
            return  aesAlg.IV;
     
        }

        public byte[] getkey()
        {
            Aes aesAlg = Aes.Create();
            aesAlg.GenerateKey();
            return aesAlg.Key;
        }





    }
}
