using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTTL.IL.HRT.Employees.Shared
{
    public static class Utils
    {
        public static string getStrFormat(int summary)
        {
            return $"{((summary * 10)).ToString("")}";
        }

        private static string getDateFileNameFormat(int addDays)
        {
            return DateTime.Now.AddDays(addDays).ToString("MM-dd-yyyy");
        }

        public static string getJsonFileName(int addDays)
        {
            return "users-" + getDateFileNameFormat(addDays) + ".json";
        }

        public static string getJsonUsersFiles()
        {
            return "users.json";
        }
        public static string getTxtFileName(int addDays)
        {
            return "log-" + getDateFileNameFormat(addDays) + ".txt";
        }

        public static bool isUserDevelopmentTeam(string email)
        {
            string[] emails = new string[]{
                "daniel@deloitte.co.ill",
                "david@deloitte.co.ill" ,
                "alex@deloitte.co.ill"  ,
                "yael@deloitte.co.ill"          
                };
            return emails.Contains(email);
        }
    }
   

}