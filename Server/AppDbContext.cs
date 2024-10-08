using Microsoft.EntityFrameworkCore;
using IrepoQuizAppp.Model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuizAnswer> QuizAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizQuestion>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.QuizQuestion)
            .HasForeignKey(a => a.QuizQuestionId); // Set foreign key

        // Additional configurations can go here

        base.OnModelCreating(modelBuilder);
    }
}
