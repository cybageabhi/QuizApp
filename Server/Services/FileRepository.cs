namespace IrepoQuizAppp.Services
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using IrepoQuizAppp.Interfaces;
    using IrepoQuizAppp.Model; // Make sure to include your model's namespace

    public class FileRepository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        // Handles fetching all quiz questions from the JSON file, assuming it's wrapped in a "QuizResponse" type structure

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Example of reading from a file and returning data as a collection of T
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("File not found");
            }

            var fileContent = await File.ReadAllTextAsync(_filePath);

            // Deserialize the file content into a list of T objects
            var items = JsonConvert.DeserializeObject<List<T>>(fileContent);

            return items;
        }
    }
}
