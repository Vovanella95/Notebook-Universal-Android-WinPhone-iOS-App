using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Services
{
    public interface INoteDataService
    {
        IEnumerable<Note> Notes();
        void Insert(Note note);
        void Delete(Note note);
        void Update(Note note);
        void Clear();
        void InsertOrUpdate(Note note);
    }
}
