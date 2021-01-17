using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamApi.Models;
using DreamApi.Mongo;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DreamApi.Services
{
    public class QuestionService : IQuestionService
    {
        public QuestionService()
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.QuestionCollection = MongoHelper.database.GetCollection<Question>("questions");
            MongoHelper.CompanyCollection = MongoHelper.database.GetCollection<Company>("company");
        }
        public Question GetQuestionById(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionByQuery(string company,string stack,string position)
        {
            
            var filterBuilder = Builders<Question>.Filter;
            var filter = filterBuilder.Eq("Company", company) & filterBuilder.Eq("Stack", stack) &
                         filterBuilder.Eq("Position", position);
            
            var _result= MongoHelper.QuestionCollection.Find(filter).ToList();
            return _result;
        }

        public void UpdateQuestionById(Question question)
        {
            var filter = Builders<Question>.Filter.Eq("_id", question._id);
            var update = Builders<Question>.Update
                .Set("AskedQuestion", question.AskedQuestion)
                .Set("Answer", question.Answer)
                .Set("Company", question.Company)
                .Set("Position", question.Position)
                .Set("Stack", question.Stack);
            var result = MongoHelper.QuestionCollection.UpdateOneAsync(filter, update);
            
        }

        public bool AddNewQuestion(Question question)
        {
            MongoHelper.QuestionCollection.InsertOneAsync(question);
            return true;
        }

        public IEnumerable<Company> GetListedCompanies()
        {
            var filter = Builders<Company>.Filter.Exists("_id");
            var companies = MongoHelper.CompanyCollection.Find(filter).ToList().Distinct();

            return companies;
        }
    }
}
