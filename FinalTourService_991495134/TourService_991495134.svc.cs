using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FinalTourService_991495134
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TourService_991495134" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TourService_991495134.svc or TourService_991495134.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticateUser : IAuthenticateUser
    {
        ABCTour_991495134Entities context = new ABCTour_991495134Entities();
        public string Authenticate(string name, string pass)
        {
            List<User> users = context.Users.ToList();

            foreach (User user in users)
            {
                if (user.Username == name && user.Password == pass)
                    return "Login Success";
            }
            return "Login Failed";
        }
    }
    public class DBOperations : IDBOperations
    {
        ABCTour_991495134Entities context = new ABCTour_991495134Entities();
        public string InsertATour(string dest)
        {
            User user = new User();
            if (!String.IsNullOrEmpty(dest))
            {
                user.Destination = dest;
                context.Users.Add(user);
                context.SaveChanges();
                return "Record Inserted";
            }
            else
                return "Data Inseertion Failed";
        }

        public List<User> RetrieveTourInfo()
        {
            return context.Users.ToList();
        }
    }
}
