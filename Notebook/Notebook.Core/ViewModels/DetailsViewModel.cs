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
    public class DetailsViewModel : MvxViewModel
    {

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

        private readonly INoteDataService _service;
        public DetailsViewModel(INoteDataService service)
        {
            _service = service;
        }

        public void Init(Note note)
        {
            Note = note;
        }

        public ICommand Edit
        {
            get
            {
                return new MvxCommand(EditItem);
            }
        }
        private void EditItem()
        {
            ShowViewModel<CreateEditViewModel>(Note);
        }


        public ICommand Remove
        {
            get
            {
                return new MvxCommand(RemoveItem);
            }

        }
        private void RemoveItem()
        {
            _service.Delete(Note);
            ShowViewModel<FirstViewModel>();
        }

        public void Close()
        {
            Close(this);
        }
    }
}
