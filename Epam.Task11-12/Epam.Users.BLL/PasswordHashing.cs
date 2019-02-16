using System;
using System.Security.Cryptography;

namespace Epam.Users.BLL
{
    internal static class PasswordHashing
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer1;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer1 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer1, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer2;

            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer2 = bytes.GetBytes(0x20);
            }

            return ByteArraysEqual(buffer3, buffer2);
        }

        private static bool ByteArraysEqual(byte[] byteArray1, byte[] byteArray2)
        {
            if (byteArray1 == byteArray2)
            {
                return true;
            }

            if (byteArray1.Length != byteArray2.Length)
            {
                return false;
            }

            for (int i = 0; i < byteArray1.Length; i++)
            {
                if (byteArray1[i] != byteArray2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
