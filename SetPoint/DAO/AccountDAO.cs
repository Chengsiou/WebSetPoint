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
        public static async Task<Dictionary<string, string>> GetAccountPoint(string uid)
        {
            string[] shops = { "SE", "FM", "OK", "WS", "CM" };
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("uid", uid);
            var resultList = await MongoDb.QueryDB(filter, "AccountPoint");
            var pointDictionary = new Dictionary<string, string>();
            for (int i = 0; i < resultList.Count; i++)
            {
                for (int j = 0; j < shops.Length; j++)
                {
                    string shopContent = "";
                    if (resultList[i].Contains(shops[j]))
                    {
                        shopContent = resultList[i].GetElement(shops[j]).Value.ToJson();
                    }
                    pointDictionary.Add(shops[j], shopContent);
                }
            }
            return pointDictionary;
        }
    }
}