using IrepoQuizAppp.Interfaces;
using IrepoQuizAppp.Model;
using IrepoQuizAppp.Services;

namespace IrepoQuizAppp.Factories
{
    public class RepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<T> CreateRepository<T>(string source) where T : QuizQuestion // Change here
        {
            return source switch
            {
                "file" => _serviceProvider.GetService<FileRepository<T>>()!,
                "db" => _serviceProvider.GetService<DatabaseRepository<T>>()!,
                _ => throw new ArgumentException("Invalid repository source", nameof(source))
            };
        }
    }
}
