using GestionFilmWPF.Models;
using GestionFilmWPF.MVVMTools;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GestionFilmWPF.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private Movie _entity;

        public string Titre
        {
            get { return _entity.Titre; }
            set { _entity.Titre = value; }
        }

        public int Annee
        {
            get { return _entity.Annee; }
            set { _entity.Annee = value; }
        }

        public DetailViewModel(Movie m)
        {
            _entity = m;
        }

        private ICommand _detailCommand, _deleteCommand;

        public ICommand DetailCommand
        {
            get { return _detailCommand ?? (_detailCommand = new RelayCommand(Detail)); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete)); }
        }

        public void Detail()
        {
            DetailView dv = new DetailView();
            dv.DataContext = this;

            dv.Show();
        }

        public void Delete()
        {
            Messenger.Send(this);
        }
    }
}
