using System;
using System.Diagnostics;
using System.Text;

namespace DTTL.IL.HRT.Employees.Shared
{

    public class User
    {
        public User(UserModel u)
        {
            if (u != null)
            {
                DisplayName = u.FullName;
                UserName = u.Mail;
                Dep = Utils.isUserDevelopmentTeam(u.Mail) ? "DEV" : "LCNC";
            }
            Skills = new Dictionary<string, int>()
			{
                {".NET",0},
                {"React",0},
                { "SQL",0 },
                { "Graph",0 },
                { "DocumnetDB",0 },
                { "DesignPatterns",0 },
                { "FrontEnd",0 } };
        }
        public User(string username, string displayname)
        {
            DisplayName = displayname;
            UserName = username;
            Dep = Utils.isUserDevelopmentTeam(username) ? "DEV" : "LCNC";
            Skills = new Dictionary<string, int>()
			{
                {".NET",0},
                {"React",0},
                { "SQL",0 },
                { "Graph",0 },
                { "DocumnetDB",0 },
                { "DesignPatterns",0 },
                { "FrontEnd",0 } };
        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Dep { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public string ToCSVFormatHeader()
        {
            StringBuilder SB = new StringBuilder();
            //titles
            SB.Append("User Name,Mail,Dep,Score,");

            SB.Append(",");

            foreach (var a in Skills)
            {
                SB.Append($"{a.Key},");
            }
            return SB.ToString();

        }
        public string ToCSVFormat()
        {
            StringBuilder SB = new StringBuilder();
            var sumOfSkills = 0;
            foreach (var a in Skills)
            {
                sumOfSkills += a.Value;
            }

            SB.Append($"{DisplayName},{UserName},{Dep},{Utils.getStrFormat(sumOfSkills)},");

            SB.Append(",");

            foreach (var a in Skills)
            {
                if (a.Value == 0)
                    SB.Append(",");
                else
                    SB.Append($"{Utils.getStrFormat(a.Value)},");
            }
            return SB.ToString();

        }
        public override string ToString()
        {
            var sumOfSkills = 0;
            foreach (var a in Skills)
            {
                sumOfSkills += a.Value;
            }
            return $"\n-------------" +
                $"\nname - {DisplayName}" +
                $"\nScore - {Utils.getStrFormat(sumOfSkills)}" +
                $"\n-------------";

        }
    }

}
