using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrepoQuizAppp.Model
{
    public class QuizResponse
    {
        public List<QuizQuestion> Values { get; set; } // List of quiz questions

        // Constructor
        public QuizResponse()
        {
            Values = new List<QuizQuestion>();
        }
    }

    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        // Navigation property for answers (kept for database context but will not be used in DTO)
        public virtual List<QuizAnswer> Answers { get; set; }

        public QuizQuestion()
        {
            Answers = new List<QuizAnswer>();
        }
    }

    public class QuizAnswer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        // Foreign key to QuizQuestion
        public int QuizQuestionId { get; set; }

        [ForeignKey("QuizQuestionId")]
        public QuizQuestion QuizQuestion { get; set; } // Navigation property
    }


}
