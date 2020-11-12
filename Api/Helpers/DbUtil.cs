using System;
using System.Data;

namespace API.Helpers
{
    public static class DataReaderHelper
    {
        public static byte[] SafeGetVarBinary(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return (byte[])reader[colName];
            return null;
        }

        public static int SafeGetInteger(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt32(reader.GetOrdinal(colName));
            return 0;
        }

        public static int? SafeGetNullableInteger(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt32(reader.GetOrdinal(colName));
            return null;
        }

        public static decimal? SafeGetNullableDecimal(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDecimal(reader.GetOrdinal(colName));
            return null;
        }

        public static decimal SafeGetDecimal(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDecimal(reader.GetOrdinal(colName));
            return decimal.Zero;
        }

        public static bool SafeGetBoolean(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetBoolean(reader.GetOrdinal(colName));
            return false;
        }

        public static DateTime? SafeGetNullableDateTime(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDateTime(reader.GetOrdinal(colName));
            return null;
        }

        public static DateTime SafeGetDateTime(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDateTime(reader.GetOrdinal(colName));
            return DateTime.MinValue;
        }

        public static string SafeGetString(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader[colName].ToString();
            return string.Empty;
        }

        public static string SafeGetStringFormatErpDate(this IDataReader reader, string colName)
        {
            string dateToFormat = string.Empty;

            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                dateToFormat = reader[colName].ToString();

            string strRet = string.Empty;

            if (!string.IsNullOrWhiteSpace(dateToFormat))
                if (dateToFormat.Length == 8)
                    strRet = dateToFormat.Substring(0, 4) + "-" + dateToFormat.Substring(4, 2) + "-" + dateToFormat.Substring(6, 2);

            return strRet;
        }

        public static char? SafeGetNullableChar(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetChar(reader.GetOrdinal(colName));
            return null;
        }

        public static int SafeGetIntFromDecimal(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return decimal.ToInt32(reader.GetDecimal(reader.GetOrdinal(colName)));
            return 0;
        }

        public static int? SafeGetNullableIntFromDecimal(this IDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return decimal.ToInt32(reader.GetDecimal(reader.GetOrdinal(colName)));
            return null;
        }
    }
}
