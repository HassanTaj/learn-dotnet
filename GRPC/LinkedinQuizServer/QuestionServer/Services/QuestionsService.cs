using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Questions.Proto.Bufs;

namespace QuestionServer.Services {
    public class QuestionService : QuestionsService.QuestionsServiceBase {

        private static List<Question> Questions = new List<Question>() {
            new Question{ Id=1, Text = "Question 1"},
            new Question{ Id=2, Text = "Question 2"},
            new Question{ Id=3, Text = "Question 3 (this fucker will be deleted.)"},
            new Question{ Id=4, Text = "Question 4"},
        };

        public override Task<Question> CreateOrUpdate(CreateOrUpdateQuestionRequest request, ServerCallContext context) {
            //return base.CreateOrUpdate(request, context);
            var id = (Questions.Count + 1);
            var o = new Question() {
                Id = request.Id == 0 ? 0 : request.Id,
                Text = request.Text
            };

            if (o.Id == 0) {
                o.Id = (Questions.Count + 1);
                Questions.Add(o);
            } else {
                ;
                Questions.Remove(Questions.Find(x => x.Id == request.Id));
                Questions.Add(o);
            }
            return Task.FromResult(o);
        }

        public override Task<Question> Delete(DefaultFilterReq request, ServerCallContext context) {
            //return base.Delete(request, context);
            var found = Questions.FirstOrDefault(x => x.Id == Convert.ToInt32(request.Id));
            Questions.Remove(found);
            return Task.FromResult(found);
        }
        public override Task<Question> GetQuestionById(DefaultFilterReq request, ServerCallContext context) {
            //return base.GetQuestionById(request, context);
            var found = Questions.FirstOrDefault(x => x.Id == Convert.ToInt32(request.Id));
            return Task.FromResult(found);
        }

        /// <summary>
        /// for repeated fields
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<QuestionListResponse> GetAllQuestionsList(EmptyReq request, ServerCallContext context) {
            var res = new QuestionListResponse();
            res.Questions.AddRange(Questions);
            return Task.FromResult(res);
            //return base.GetAllQuestionsList(request, context);
        }

        /// <summary>
        /// stream based
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GetAllQuestionsStream(EmptyReq request, IServerStreamWriter<Question> responseStream, ServerCallContext context) {
            foreach (var q in Questions) {
                await responseStream.WriteAsync(q);
            }
            //return base.GetAllQuestionsStream(request, responseStream, context);
        }

    }
}
