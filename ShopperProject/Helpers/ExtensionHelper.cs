﻿
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ShopperProject.Helpers
{
    public static class ExtensionHelper
    {
        #region [Hashing Extension]
        public static string ToSHA256Hash(this string password, string saltKey = null)
        {
            var sha256 = SHA256.Create();
            byte[] encryptedSHA256 = sha256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(password, saltKey)));
            sha256.Clear();

            return Convert.ToBase64String(encryptedSHA256);
        }

        public static string ToSHA512Hash(this string password, string saltKey = null)
        {
            SHA512Managed sha512 = new SHA512Managed();
            byte[] encryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(password, saltKey)));
            sha512.Clear();

            return Convert.ToBase64String(encryptedSHA512);
        }

        public static string ToMd5Hash(this string password, string saltKey = null)
        {
            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(password, saltKey)));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        #endregion

        public static string ToVnd(this double giaTri)
        {
            return $"{giaTri:#,##0} đ";
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
