using System.Text;

namespace App_deck_pokemon.Services
{
    public class PasswordService
    {
        private const string SecurityKey = "Clé de cryptage à remplacer pas un élèment plus sécure";
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + SecurityKey));
        }

        public string DecryptPassword(string cryptedString)
        {
            if (string.IsNullOrEmpty(cryptedString)) return "";
            string decryptedString = Encoding.UTF8.GetString(Convert.FromBase64String(cryptedString));
            return decryptedString.Substring(0, decryptedString.Length - SecurityKey.Length);
        }
    }
}
