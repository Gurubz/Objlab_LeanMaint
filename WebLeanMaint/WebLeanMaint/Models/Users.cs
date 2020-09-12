using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
	public class Users
	{
		public int ID_User { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string EMail { get; set; }
		public string Mobile { get; set; }
		public int Seed { get; set; }
		public int ID_UserType { get; set; }
		public int ID_ObjStatus { get; set; }
	}
}