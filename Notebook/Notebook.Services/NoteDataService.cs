using MvvmCross.Plugins.File;
using MvvmCross.Plugins.Json;
using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Services
{
    public class NoteDataService : INoteDataService
    {
        private readonly IMvxFileStore storage;
        private MvxJsonConverter converter;
        private string filePath;

        public NoteDataService(IMvxFileStore mvxFileStorage)
        {
            filePath = "noteStorage.json";
            converter = new MvxJsonConverter();

            storage = mvxFileStorage;
            if (!storage.Exists(filePath))
            {
                storage.WriteFile(filePath, converter.SerializeObject(Enumerable.Empty<Note>()));
            }
        }

        public void Delete(Note note)
        {
            var items = Notes().Where(w => w.Id != note.Id);
            storage.WriteFile(filePath, converter.SerializeObject(items));
        }

        public void Insert(Note note)
        {
            note.Date = DateTime.Now;
            var items = Notes();
            note.Id = 0;
            if (items.Count() != 0)
            {
                note.Id = items.Max(w => w.Id) + 1;
            }

            storage.WriteFile(filePath, converter.SerializeObject(items.Concat(new[] { note })));
        }

        public void InsertOrUpdate(Note note)
        {
            if (note.Id == 0)
            {
                Insert(note);
            }
            else
            {
                Update(note);
            }

        }

        public IEnumerable<Note> Notes()
        {
            string json;
            storage.TryReadTextFile(filePath, out json);
            return converter.DeserializeObject<IEnumerable<Note>>(json);
        }

        public void Update(Note note)
        {
            note.Date = DateTime.Now;
            var notes = Enumerable.Concat(Notes().Where(w => w.Id != note.Id), new[] { note });
            storage.WriteFile(filePath, converter.SerializeObject(notes));
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
