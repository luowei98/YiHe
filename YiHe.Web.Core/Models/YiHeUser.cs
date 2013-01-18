using System;
using System.Security.Principal;
using System.Web.Security;


namespace YiHe.Web.Core.Models
{
    [Serializable]
    public class YiHeUser : IIdentity
    {
        public YiHeUser()
        {
        }

        public YiHeUser(string name, string displayName, int userId)
        {
            Name = name;
            DisplayName = displayName;
            UserId = userId;
        }

        public YiHeUser(string name, string displayName, int userId, string roleName)
        {
            Name = name;
            DisplayName = displayName;
            UserId = userId;
            RoleName = roleName;
        }

        public YiHeUser(string name, UserInfo userInfo)
            : this(name, userInfo.DisplayName, userInfo.UserId, userInfo.RoleName)
        {
            if (userInfo == null) throw new ArgumentNullException("userInfo");
            UserId = userInfo.UserId;
        }

        public YiHeUser(FormsAuthenticationTicket ticket)
            : this(ticket.Name, UserInfo.FromString(ticket.UserData))
        {
            if (ticket == null) throw new ArgumentNullException("ticket");
        }

        public string DisplayName { get; private set; }
        public string RoleName { get; private set; }
        public int UserId { get; private set; }

        #region IIdentity Members

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "YiHeForms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        #endregion
    }
}