using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Digital_Services_BD.Utilities
{
    /// <summary>
    /// A utility class for passowrd hash generation and verification.
    /// </summary>
    public static class PasswordUtility
    {
        /// <summary>
        /// Generates a 48 byte long byte array, first 16 bytes contain a random salt, the remaining 32
        /// bytes contain the hash of the given password by PBKDF2 algorithm, 
        /// using <see cref="KeyDerivation.Pbkdf2(string, byte[], KeyDerivationPrf, int, int)"/>
        /// </summary>
        /// <remarks>
        /// A 16 byte long random salt is generated.
        ///<see cref="KeyDerivationPrf.HMACSHA256"/> pseudo random function is used with 10,000 iterations to produce the 32 byte hash.
        /// </remarks>
        /// <param name="password">The password to hash.</param>
        /// <returns>A 48 byte long byte array</returns>
        public static string HashPassword(string password)
        {
            //Create a 48 byte long byte array, populate first 16 byte with a random salt.
            byte[] hashedPass = new byte[48];
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            Buffer.BlockCopy(salt, 0, hashedPass, 0, 16);

            //Generate a 32 byte hash of the given password by PBKDF2 algorithm, with the given salt.
            byte[] subKey = KeyDerivation.Pbkdf2
                (
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 1000,
                    32
                );
            //Populate last 32 byte with hash.
            Buffer.BlockCopy(subKey, 0, hashedPass, 16, 32);
            return Convert.ToBase64String(hashedPass);
        }
        /// <summary>
        /// Verifies whether hashing a given password produces the given hashed password.
        /// </summary>
        /// <param name="hashedPassword">The 48 byte long hashed passowod as Base64 string.</param>
        /// <param name="password">The given passoword to verify.</param>
        /// <returns><c>true</c> if the password produces the hashedPassword, <c>false</c> otherwise.</returns>
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            //If invalid value is provided, return false.
            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                //Convert from Base64 string to a byte array.
                byte[] hashedPass = Convert.FromBase64String(hashedPassword);
                //Gets first 16 byte salt.
                byte[] salt = new byte[16];
                Buffer.BlockCopy(hashedPass, 0, salt, 0, 16);
                //Gets last 32 byte hash.
                byte[] expectedSubkey = new byte[32];
                Buffer.BlockCopy(hashedPass, 16, expectedSubkey, 0, 32);
                //Generate the hash of the given password by PBKDF2 algorithm, with the given salt.
                byte[] actualSubkey = KeyDerivation.Pbkdf2
                    (
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 1000,
                        32
                    );
                //Check the equality in a safe way.
                return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
            }
            //If hashedPassowrd format is not correct, returns false
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// A secured guid is generated from a random byte array and returned as a string.
        /// </summary>
        /// <returns>A Guid as base64 string</returns>
        public static string GenerateSecuredGuid()
        {
            var randomBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(new Guid(randomBytes).ToByteArray());
        }


        /// <summary>
        /// Generate the hash of the given data and size by PBKDF2 algorithm, with the given salt.
        /// </summary>
        public static byte[] PkbDf2(byte[] salt, string data, int size = 32)
        {
            if(string.IsNullOrEmpty(data) || salt == null || salt.Length == 0)
            {
                return null;
            }

            byte[] derivedKey = KeyDerivation.Pbkdf2
                    (
                        password: data,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 1019,
                        size
                    );
            return derivedKey;
        }
    }
}
