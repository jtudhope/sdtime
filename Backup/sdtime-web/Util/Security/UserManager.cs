using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Core.Util;
using sdtime.Util.Security.Model;

namespace sdtime.Util.Security
{
    
    public class UserManager
    {
        ILogger log;
        public UserManager()
        {
            log = new NullLogger();
        }
        public bool UserExists(string provider, string key)
        {
               
            
            log.WriteLine("User Exists: " + provider + ": " + key);
            var userexists = false;
            using (var db = new UserDbContainer())
            {
                userexists = db.Users.Any(q => q.IdentityProviderKey == key && q.IdentityProviderName == provider);
                
            }
            log.WriteLine("Exists: {0}", userexists);
            log.Flush();
            return userexists;
        }

        public bool ResendConfirmation(User user)
        {
            if (user == null) return false;
            log.WriteLine("UserMgr.ResendConfirmation");
            try
            {
                using (var db = new UserDbContainer())
                {
                    
                    db.AddToUserEmailConfirmations(new UserEmailConfirmation { User = user });
                    db.SaveChanges();
                }
                log.WriteLine("Confirmation Sent!");
                return true;
            }
            catch (Exception ex)
            {
                
                log.Error(ex, "Resend Confirmation");
            }
            return false;
        }

        public bool RegisterNewUser(User user)
        {
            if (user == null) return false;
            try
            {
                using (var db = new UserDbContainer())
                {
                    db.AddToUsers(user);
                    db.AddToUserEmailConfirmations(new UserEmailConfirmation { User = user });
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                var log = IOCContainer.Resolve<ILogger>();
                log.Error(ex, "Register New User");
            }
            return false;
        }

        public User GetUserByKey(string provider, string key)
        {
            using (var db = new UserDbContainer())
            {
                var user = db.Users.FirstOrDefault(q => q.IdentityProviderKey == key && q.IdentityProviderName == provider);
                return user;
            }
        }
    }
}
