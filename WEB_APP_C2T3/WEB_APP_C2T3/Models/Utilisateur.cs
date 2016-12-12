using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WEB_APP_C2T3.Models
{
    public class Utilisateur
    {
        private Utilisateur u;

        public int Id { get; set; }
        [Display(Name = "Compte")]
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        [Display(Name = "Prénom")]
        public virtual string prenom { get; set; }
        [Display(Name = "Nom")]
        public virtual string nom { get; set; }
        public virtual string salt { get; set; }
        [Display(Name = "Privilèges administratifs")]
        public virtual bool administrateur { get; set; }

        public Utilisateur(string _username, string _password, string _prenom, string _nom, bool _administrateur)
        {
            administrateur = _administrateur;
            username = _username;
            nom = _nom;
            prenom = _prenom;
            salt = getSalt();
            password = CreateSHAHash(_password, salt);

        }

        public Utilisateur() { }

        public Utilisateur(Utilisateur u)
        {
            this.u = u;
        }

        public static string CreateSHAHash(string _password, string _salt)
        {
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(_password, _salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }





        public static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }



}
