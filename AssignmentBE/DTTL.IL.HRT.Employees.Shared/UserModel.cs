using System;
namespace DTTL.IL.HRT.Employees.Shared
{
	public class UserModel
	{
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string WorkTitle { get; set; }
        public string ImageUrl { get; set; }


        public UserModel()
        {
        }
        public UserModel(string fullname, string worktitle,string mail, string imageurl)
        {
            FullName = fullname;
            WorkTitle = worktitle;
            Mail = mail;
            ImageUrl = imageurl;
        }
    }
}

