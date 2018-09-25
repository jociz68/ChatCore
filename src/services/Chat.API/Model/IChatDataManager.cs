using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Model
{
    public interface IChatDataManager
    {

        bool CreatQuestion(Question question);
        bool CreateAnswer(Answer answer, int questionId);

        ICollection<Question> GetQuestionsByAnswerId(int answerId);

        ICollection<Question> GetActiveQuestions(string session);
        ICollection<Question> GetQuestionsNotAnswered();

        int GetActiveQuestionsCount();

        ICollection<Question> GetPagedActiveQuestions(int startNumber, int pageSize);
    }
}
