using System;
using System.Collections.Generic;
using Question.Domain.AskQuestionWorkflow;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> taglist = new List<string>{ "Java", "AngularJS" };
            var cmd = new CreateQuestionCmd("How to change the placeholder for the input", "How can i change the css properties for the placeholder in input field", taglist);
            var result = CreateQuestionCmd(cmd);
            
            result.Match(
                ProcessQuestionAdded,
                ProcessQuestionNotAdded,
                ProcessQuestionValidationFailed
            );
        }

        private static string ProcessQuestionNotAdded(CreateQuestionResult.QuestionNotAdded question)
        {
            Console.WriteLine("Question was not added. Error: " + question.ErrorMessage.ToString());
            
            return question.ErrorMessage.ToString();
        }

        private static string ProcessQuestionValidationFailed(CreateQuestionResult.QuestionValidationFailed question)
        {
            Console.WriteLine("Validation failed: ");
            foreach(var error in question.ValidationErrros)
            {
                Console.WriteLine(question);
            }

        }

        private static string ProcessQuestionAdded(CreateQuestionResult.QuestionAdded question)
        {
            Console.WriteLine("QId:" + question.Id);
            Console.WriteLine("Title: " + question.Title);
            Console.WriteLine("Body: " + question.Text);
            Console.WriteLine("Tags:");
            foreach(var item in question.Tags)
            {
                Console.WriteLine(item);
            }

            return question.ToString();
        }

        static CreateQuestionResult.IAskQuestionResult AskQuestion(CreateQuestionCmd cmd)
        {
            if(string.IsNullOrWhiteSpace(cmd.Title))
            {
                string error = new string ("Title must not be empty!");
                return new CreateQuestionResult.QuestionNotAdded(error);
            }

            if(string.IsNullOrWhiteSpace(cmd.Text))
            {
                string error = new string ("Body must not be empty!");
                return new CreateQuestionResult.QuestionNotAdded(error);
            }

            if(new Random().Next(10) > 7) //simulare analiza text
            {
                var error = new List<string> {"ML validation failed!"};
                return new CreateQuestionResult.QuestionValidationFailed(error);
            }

            var Id = Guid.NewGuid();
            var result = new CreateQuestionResult.QuestionAdded(Id, cmd.Title, cmd.Text, cmd.Tags);
            return result;
        }
    }
}