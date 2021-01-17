using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamApi.Models;

namespace DreamApi.Services
{
  public interface IQuestionService
    { 
        Question GetQuestionById(string Id);
        IEnumerable<Question> GetQuestionByQuery(string company,string stack,string position);
        void UpdateQuestionById(Question question);
        bool AddNewQuestion(Question question);
    }
}
