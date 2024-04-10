using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LST.Infrastructure.Authentication
{
    public class SecurityUser : ClaimsPrincipal
    {
        private string? _roles;
        private string? _name;
        private int _id;
        private string? _email;
        private string? _fullname;
        private bool _IsAuthenticated { get; set; }

        public string Roles
        {
            get { return _roles!; }
        }
        public int Id { get { return _id; } }
        public string Email { get { return _email!; } }
        public string FullName { get { return _fullname!; } }

        public override bool IsInRole(string role)
        {
            string[] allroles = _roles!.Split('|');
            return allroles.Contains(role.TrimEnd('|'));
            //return Array.BinarySearch(allroles, role) >= 0 ? true : false;
        }

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set { _IsAuthenticated = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public bool IsNormal()
        {
            return IsInRole("NormalUser");
        }

        public SecurityUser(int _ID,string _Name,string _FullName,string _Email,string _Roles)
        {
            _id = _ID;
            _name = _Name;
            _fullname = _FullName;
            _email = _Email;
            _roles = _Roles;
        }
    }
}
