using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CyberValetGrocery.Class
{
    public class PasswordRestrictions
    {
        int userTypeId;
        int counterGreater = 0, accountIsLock = 0, userExists = 0, franchExists = 0;
        DbProvider franchiseeloginDB = new DbProvider();

        public PasswordRestrictions()
        {
            //
            // TODO: Add constructor logic here
            //

        }

        public int CheckPassword(string password)
        {
            string str3;
            int asc_num, cnt = 0, validPas;
            int len = password.Length;
            if (len >= 7)
            {
                for (int iCount = 0; iCount < len; iCount++)
                {
                    str3 = password.Substring(iCount, 1);
                    if (str3 == " ")
                    {
                        return validPas = 1;

                    }
                    asc_num = (int)Convert.ToChar(str3);
                    if (asc_num >= 48 && asc_num <= 57)
                    {
                        cnt++;
                    }

                }
                if (cnt >= 2)
                {
                    validPas = 0;
                }
                else
                {
                    validPas = 1;
                }

            }
            else
            {
                validPas = 1;
            }
            return validPas;
        }
        public string encryptPassword(string pwd) //encrypt the password
        {

            string password, encryptedPwd, original;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdHash, buff;

            password = "secretpassword1!";
            original = pwd;

            hashmd5 = new MD5CryptoServiceProvider();
            pwdHash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            hashmd5 = null;

            des = new TripleDESCryptoServiceProvider();

            des.Key = pwdHash;

            des.Mode = CipherMode.ECB; //CBC, CFB

            buff = ASCIIEncoding.ASCII.GetBytes(original);

            encryptedPwd = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));



            return encryptedPwd;

        }

        public string decryptPassword(string en_pwd)//To decrypt the password
        {
            string password, encrypted, decrypted;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdHash, buff;

            password = "secretpassword1!";
            encrypted = en_pwd;

            hashmd5 = new MD5CryptoServiceProvider();
            pwdHash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            hashmd5 = null;

            des = new TripleDESCryptoServiceProvider();

            des.Key = pwdHash;

            des.Mode = CipherMode.ECB; //CBC, CFB

            buff = Convert.FromBase64String(encrypted);


            decrypted = ASCIIEncoding.ASCII.GetString(
                des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length)
            );



            return decrypted;

        }

        public int superAdminCheckPassword(string password)
        {
            string str3;
            int asc_num, cnt = 0, pas;
            int len = password.Length;
            if (len >= 7)
            {
                for (int iCount = 0; iCount < len; iCount++)
                {
                    str3 = password.Substring(iCount, 1);
                    if (str3 == " ")
                    {
                        return pas = 1;

                    }
                    asc_num = (int)Convert.ToChar(str3);
                    if (asc_num >= 48 && asc_num <= 57)
                    {
                        cnt++;
                    }

                }
                if (cnt >= 2)
                {
                    pas = 0;
                }
                else
                {
                    pas = 1;
                }

            }
            else
            {
                pas = 1;
            }
            return pas;
        }

    }
}
