using Note.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note.Interfaces
{
    public interface IDataService
    {
        Task<List<Thread>> GetLastNThreads(int top = 10);
        void SaveNote(Thread thread);
        Tag GetTagByName(string tagname);
        Task<List<string>> GetSuggestedTags();
        Task<Thread> GetThreadById(int id);
    }
}
