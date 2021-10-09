using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace ShopifyHotelSourcing.Services.HotelBedsService
{
    public class HotelAPIHelpers
    {
        public static string GetXSignature(string apiKey, string secret)
        {
            //Begin UTC creation
            var timeUtc = Math.Floor((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000);

            //Begin Signature Assembly
            var publicKey = apiKey;
            var privateKey = secret;

            var assemble = publicKey + privateKey + timeUtc;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Begin SHA-256 Encryption
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.Default.GetBytes(assemble));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder(bytes.Length * 2);
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
