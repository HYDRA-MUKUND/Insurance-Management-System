using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MiniProject_InsuranceManagementSystem.Encryption
{
    public static class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            var Hash = SHA256.Create(); 
            var ByteArray = Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
           
            var EncrytedPassword =  BitConverter.ToString(ByteArray).Replace("-","");
            return EncrytedPassword;
        }
    }
}