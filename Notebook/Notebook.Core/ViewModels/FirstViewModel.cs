using MvvmCross.Core.ViewModels;
using Notebook.Models;
using Notebook.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Notebook.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly INoteDataService _mvxFileStore;
        private bool isDecreesing = true;

        public FirstViewModel(INoteDataService mvxFileStore)
        {
            _mvxFileStore = mvxFileStore;
            Notes = _mvxFileStore.Notes().OrderByDescending(w => w.Date);
        }

        private IEnumerable<Note> _notes;
        public IEnumerable<Note> Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                RaisePropertyChanged(() => Notes);
            }
        }


        private Note _selectedNote;
        public Note SelectedNote
        {
            get
            {
                return _selectedNote;
            }
            set
            {
                _selectedNote = value;
                RaisePropertyChanged(() => SelectedNote);
                ShowViewModel<DetailsViewModel>(SelectedNote);
            }
        }


        public ICommand Create
        {
            get
            {
                return new MvxCommand(CreateItem);
            }
        }
        private void CreateItem()
        {
            ShowViewModel<CreateEditViewModel>();
        }


        public ICommand SortByDate
        {
            get
            {
                return new MvxCommand(SortNotesByDate);
            }
        }
        private void SortNotesByDate()
        {
            Notes = isDecreesing ? Notes.OrderBy(w => w.Date) : Notes.OrderByDescending(w => w.Date);
            isDecreesing = !isDecreesing;
        }


        public ICommand SortByName
        {
            get
            {
                return new MvxCommand(SortNotesByName);
            }
        }
        private void SortNotesByName()
        {
            Notes = isDecreesing ? Notes.OrderBy(w => w.Title) : Notes.OrderByDescending(w => w.Title);
            isDecreesing = !isDecreesing;
        }

        public void Close()
        {
            Close(this);
        }

    }
}
