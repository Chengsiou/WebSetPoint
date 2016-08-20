using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SetPoint.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using SetPoint.Utility;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity.Owin;
namespace SetPoint.DAO
{
    public class AccountDAO
    {
        class UserInfo
        {
            public string _id;
            public string name;
            public string uid;
            public string pwd;
        }
        public static async Task<SignInStatus> Login(LoginViewModel model)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("uid", model.Email) & builder.Eq("pwd", model.Password);
            var resultList = await MongoDb.QueryDB(filter, "Account");
            
            var result = SignInStatus.RequiresVerification;
            if (resultList != null && resultList.Count > 0)
            {
                if (resultList[0].GetElement("uid").Value == model.Email)
                {
                    result = SignInStatus.Success;
                }
            }
            return result;
        }
    }
}