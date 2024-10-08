using IrepoQuizAppp.Interfaces;
using IrepoQuizAppp.Model;
using Microsoft.EntityFrameworkCore;

public class DatabaseRepository<T> : IRepository<T> where T : QuizQuestion
{
    private readonly AppDbContext _context;

    public DatabaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        Console.WriteLine("hello");
        return await GetSampleQuestionsAsync(); // Adjust return type
    }

    public async Task<IEnumerable<T>> GetSampleQuestionsAsync()
    {
        var questions = await _context.QuizQuestions
            .Include(q => q.Answers)
            .ToListAsync();

        // Convert QuizQuestion to QuizQuestionDto
        var questionDtos = questions.Select(q => new QuizQuestion
        {
            Id = q.Id,
            QuestionText = q.QuestionText,
            Answers = q.Answers.Select(a => new QuizAnswer
            {
                Id = a.Id,
                AnswerText = a.AnswerText
            }).ToList()
        });

        return questionDtos.Cast<T>();
    }


    
}
