using KindleSpur.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace KindleSpur.Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".

    [BsonIgnoreExtraElements]
    public class User : IUser
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mobile { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Photo { get; set; }
        public Boolean IsExternalAuthentication { get; set; }
        public Boolean IsVerified { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [BsonId]
        public ObjectId Id
        {
            get; set;
        }
    }
}
