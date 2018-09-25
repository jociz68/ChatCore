using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Model
{
    public class ChatDataManager : IChatDataManager
    {
        ChatModelCtx _context;
        public ChatDataManager(ChatModelCtx contex)
        {
            _context = contex;
        }
        #region Public Methods


        //public bool AddServices(string login, string password)
        //{
        //    using (var context = new ChatModel())
        //    {
        //        var service = new Service()
        //        {
        //            Login = login,
        //            Password = password
        //        };
        //        context.Services.Add(service);
        //        return context.SaveChanges() == 1;
        //    }
        //}

        //public int GetServiceUserId(string login)
        //{
        //    using (var context = new ChatModel())
        //    {
        //        var serviceUser = context.Services.FirstOrDefault(u => u.Login.Equals(login, StringComparison.InvariantCulture));
        //        return serviceUser != null ? serviceUser.Id : -1;
        //    }
        //}

        //public bool IsValidLogin(string login, string password)
        //{
        //    using (var context = new ChatModel())
        //    {
        //        var service = context.Services.SingleOrDefault(s => s.Login.Equals(login, StringComparison.InvariantCulture));
        //        if (service == null)
        //        {
        //            return false;
        //        }
        //        return service.Password.Equals(password);
        //    }
        //}

        public bool CreateAnswer(Answer answer, int questionId)
        {

            var answerToBe = new Answer()
            {
                Text = answer.Text,
                UserId = answer.UserId,
                AnswerTime = DateTime.Now,
                QuestionID = questionId
            };
            _context.Answers.Add(answerToBe);
            return _context.SaveChanges() == 1;
        }

        public bool CreatQuestion(Question questionData)
        {
            var question = new Question()
            {
                Text = questionData.Text,
                Session = questionData.Session,
                CreateTime = DateTime.Now
            };
            _context.Questions.Add(question);
            return _context.SaveChanges() == 1;

        }

        public int GetActiveQuestionsCount()
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> GetPagedActiveQuestions(int startNumber, int pageSize)
        {
            throw new NotImplementedException();
        }


        public ICollection<Question> GetQuestionsByAnswerId(int answerId)
        {

            return _context.Questions.Where(q => q.Answer.ID == answerId).ToList();

        }

        public ICollection<Question> GetQuestionsNotAnswered()
        {

            return _context.Questions.Where(q => q.Answer == null).ToList();

        }

        public ICollection<Question> GetActiveQuestions(string session)
        {
            var list = _context.Questions
                .Where(q => q.Session.Equals(session))
                .ToList();
            //foreach (var item in list)
            //{
            //    var answer = _context.Answers.FirstOrDefault(a => a.ID == item.Answer.ID);
            //    if (answer != null)
            //    {
            //        item.Answer.ID = answer.ID;
            //    }

            //}
            return list.OrderBy(o =>
            {
                if (o.Answer != null)
                {
                    return o.Answer.AnswerTime;
                }
                else
                {
                    return o.CreateTime;
                }
            }).ToList();
        }


        #endregion

        #region private
      
        #endregion private
    }
}
