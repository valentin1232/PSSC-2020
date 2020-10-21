using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Text { get; private set; }
        [Required]
        public List<string> Tags { get; private set; }

        public CreateQuestionCmd(string title, string text, List<string> tags)
        {
            Title = title;
            Text = text;
            Tags = tags;
        }
    }
}