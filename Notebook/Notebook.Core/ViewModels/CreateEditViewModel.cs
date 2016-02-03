using MvvmCross.Core.ViewModels;
using Notebook.Models;
using Notebook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notebook.Core.ViewModels
{
    public class CreateEditViewModel : MvxViewModel
    {
        private readonly INoteDataService _service;
        public CreateEditViewModel(INoteDataService service)
        {
            _service = service;
        }

        public void Init(Note note)
        {
            Note = note;
        }


        private Note _note;
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                RaisePropertyChanged(() => Note);
            }
        }


        public ICommand Submit
        {
            get
            {
                return new MvxCommand(SaveItem);
            }
        }
        private void SaveItem()
        {
            _service.InsertOrUpdate(Note);
            ShowViewModel<FirstViewModel>();
        }

        public void Close()
        {
            Close(this);
        }
    }
}
