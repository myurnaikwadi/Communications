using KindleSpur.Models.Interfaces;
using KindleSpur.Models;
using KindleSpur.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace KindleSpur.Data
{
    public class UserRepository : IUserRepository
    {
        MongoClient _mongoClient;
        MongoServer _mongoServer;
        MongoDatabase _kindleDatabase;
        MongoCollection _logCollection;

        public UserRepository()
        {
           string mongoServerConfig = "mongodb://127.0.0.1:27017";
               
            try
            {
               _mongoClient = new MongoClient(mongoServerConfig);
               _mongoServer = _mongoClient.GetServer();
               _kindleDatabase = _mongoServer.GetDatabase("KindleSpur");
                _logCollection = _kindleDatabase.GetCollection("ErrorLogs");
            }
            catch (MongoException ex)
            {
                _logCollection.Insert("{ Error : 'Database connection failed.', Log: " + ex.Message + ", Trace: " + ex.StackTrace + "} ");
            }
        }
        public bool AddNewUser(IUser userData)
        {
            bool _transactionStatus = false;

            try
            {
                var _userCollection = _kindleDatabase.GetCollection("UserDetails");
                var result = _userCollection.Find(Query.EQ("EmailAddress", userData.EmailAddress));

                if (result.Count() > 0)
                    return false;

                _userCollection.Insert(userData);
                
                _transactionStatus = true;
            }
            catch (MongoException ex)
            {
                _logCollection.Insert("{ Error : 'Failed at AddNewUser().', Log: " + ex.Message + ", Trace: " + ex.StackTrace + "} ");
                throw new MongoException("Signup failure!!!");
            }
            
            return _transactionStatus;

        }

        public bool EditUser(string userId, IUser userData)
        {
            bool _transactionStatus = false;
            try
            {
                var _userCollection = _kindleDatabase.GetCollection("UserDetails");
                var userDetail = _userCollection.FindOneAs<IUser>(Query.EQ("_id", ObjectId.Parse(userId)));
                userDetail.EmailAddress = userData.EmailAddress;
                userDetail.Password = userData.Password;
                userDetail.IsExternalAuthentication = userData.IsExternalAuthentication;
                userDetail.UpdateDate = DateTime.Now;
                userDetail.IsVerified = true;

                _userCollection.Save(userDetail);
                _transactionStatus = true;
            }
            catch (MongoException ex)
            {
                _logCollection.Insert("{ Error : 'Failed at EditUser().', Log: " + ex.Message + ", Trace: " + ex.StackTrace + "} ");
            }
            return _transactionStatus;
        }

        public User SavePassword(string userId, IUser userData)
        {

                var _userCollection = _kindleDatabase.GetCollection("UserDetails");
            User userDetail = _userCollection.FindOneAs<User>(Query.EQ("_id", ObjectId.Parse(userId)));
            userDetail.Password = userData.Password;
            userDetail.IsExternalAuthentication = userData.IsExternalAuthentication;
            userDetail.UpdateDate = DateTime.Now;
            userDetail.IsVerified = true;

            _userCollection.Save(userDetail);

            return (User)userDetail;

        }

        public IUser GetUserDetail(int userId)
        {
            var _userCollection = _kindleDatabase.GetCollection("UserDetails");
            return _userCollection.FindOneByIdAs<IUser>(userId);
        }
        public IUser GetUserDetail(string EmailAddress)
        {
            var _userCollection = _kindleDatabase.GetCollection("UserDetails");
            return _userCollection.FindOneAs<User>(Query.EQ("EmailAddress", EmailAddress));
        }
    }
}
