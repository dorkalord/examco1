using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Services
{
    public interface IQuestionService : IService<Question>
    {
        IEnumerable<Question> getByExam(int examID);
    }

    public class QuestionService : IQuestionService
    {
        private DataContext _context;

        public QuestionService(DataContext context)
        {
            _context = context;
        }

        public Question Create(Question newObject)
        {
            _context.Questions.Add(newObject);
            _context.SaveChanges();

            return _context.Questions.Last(x => x.Text == newObject.Text);
        }

        public void Delete(int id)
        {
            Question x = _context.Questions.Find(id);
            if (x != null)
            {
                _context.Questions.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions;
        }

        public IEnumerable<Question> getByExam(int examID)
        {
            return _context.Questions.Where(x => x.ExamID == examID);
        }

        public Question GetById(int id)
        {
            return _context.Questions.Find(id);
        }

        public Question Update(Question updatedObject)
        {
            Question x = _context.Questions.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Question not found");

            /*copy properties here*/
            x.SeqencialNumber = updatedObject.SeqencialNumber;
            x.Text = updatedObject.Text;
            x.ProposedWeight = updatedObject.ProposedWeight;
            x.FinalWeight = updatedObject.FinalWeight;
            x.ExamID = updatedObject.ExamID;
            x.ParentQuestionID = updatedObject.ParentQuestionID;

            _context.Questions.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
