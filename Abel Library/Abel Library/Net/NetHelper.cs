using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Abel.Net
{
    public static class NetHelper
    {
        /// <summary>
        /// 将IP地址转换为数字表示
        /// </summary>
        /// <param name="ip">要转换的IP</param>
        /// <returns>失败返回0</returns>
        public static long ConvertIPToLong( string ip )
        {
            long result = 0;

            try
            {
                var ips = ip.Trim().Split( '.' );
                if ( ips.Length == 4 )
                {
                    return long.Parse( ips[0] ) * 256 * 256 * 256 + long.Parse( ips[1] ) * 256 * 256 + long.Parse( ips[2] ) * 256 + long.Parse( ips[3] );
                }
            }
            catch { result = 0; }

            return result;
        }

        /// <summary>
        /// 将数字转换为IP地址
        /// </summary>
        /// <param name="ipValue">表示IP的数字</param>
        /// <returns>失败返回空</returns>
        public static string GetIPFromLong( long ipValue )
        {
            string result = string.Empty;

            try
            {
                long[] mask = { 0x000000FF, 0x0000FF00, 0x00FF0000, 0xFF000000 };
                long num = 0;
                StringBuilder ipInfo = new StringBuilder();

                for ( int i = 0; i < 4; i++ )
                {
                    num = ( ipValue & mask[i] ) >> ( i * 8 );

                    if ( i > 0 )
                        ipInfo.Insert( 0, "." );

                    ipInfo.Insert( 0, Convert.ToString( num, 10 ) );
                }

                result = ipInfo.ToString();
            }
            catch { result = string.Empty; }

            return result;
        }

        private static int GetReversedNumber( int number )
        {
            string result = string.Empty;
            var str = Convert.ToString( number, 2 );
            if ( str.Length != 8 )
            {
                int len = 8 - str.Length;
                for ( int i = 0; i < len; i++ )
                    str = "0" + str;
            }

            foreach ( var n in str )
            {
                result += n == '1' ? "0" : "1";
            }
            return Convert.ToInt32( result, 2 );
        }

        /// <summary> 
        /// 获取网段起始和结束IP 
        /// </summary> 
        /// <param name="IP">当前IP地址</param> 
        /// <param name="mask">子网掩码</param> 
        /// <param name="startIP">网段的起始IP</param>
        /// <param name="endIP">网段的结束IP</param>
        public static void GetNetworkAddresses( IPAddress IP, IPAddress mask, out IPAddress startIP, out IPAddress endIP )
        {
            try
            {
                if ( IP.AddressFamily == AddressFamily.InterNetwork && mask.AddressFamily == AddressFamily.InterNetwork && mask.ToString() != "0.0.0.0" )
                {
                    var ips = IP.ToString().Split( '.' );
                    var masks = mask.ToString().Split( '.' );
                    string start = string.Empty;
                    string end = string.Empty;

                    for ( int i = 0; i < 4; i++ )
                    {
                        int temp = int.Parse( ips[i] ) & int.Parse( masks[i] );

                        start += temp + ".";
                        end += ( temp | GetReversedNumber( int.Parse( masks[i] ) ) ) + ".";
                    }

                    if ( !IPAddress.TryParse( start.TrimEnd( '.' ), out startIP ) )
                        startIP = null;
                    if ( !IPAddress.TryParse( end.TrimEnd( '.' ), out endIP ) )
                        endIP = null;
                }
                else
                    startIP = endIP = null;
            }
            catch
            {
                startIP = endIP = null;
            }
        }

    }
}
