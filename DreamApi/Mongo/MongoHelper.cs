using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamApi.Models;
using MongoDB.Driver;

namespace DreamApi.Mongo
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        
        //public static string MongoConnection = "mongodb+srv://<username>:<password>@cluster0.xbznn.mongodb.net/<dbname>?retryWrites=true&w=majority";
        public static string MongoConnection = "mongodb+srv://new_user001:dreamapi@cluster0.xbznn.mongodb.net/dreamapi?retryWrites=true&w=majority";
        public static string MongoDatabase = "dreamapi";


        public static IMongoCollection<Question>QuestionCollection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
               client=new MongoClient(MongoConnection);
               database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
