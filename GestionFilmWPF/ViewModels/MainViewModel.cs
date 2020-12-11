using GestionFilmWPF.Models;
using GestionFilmWPF.MVVMTools;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace GestionFilmWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private string _titre;

        public string Titre
        {
            get { return _titre; }
            set 
            { 
                if(_titre != value)
                {
                    _titre = value;
                    RaisePropertyChanged(nameof(Titre));
                }
            }
        }

        private int _annee;

        public int Annee
        {
            get { return _annee; }
            set {
                if (_annee != value)
                {
                    _annee = value;
                    RaisePropertyChanged(nameof(Annee));
                }
            }
        }

        private ObservableCollection<DetailViewModel> _items;

        public ObservableCollection<DetailViewModel> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        #endregion

        public MainViewModel()
        {
            _items = new ObservableCollection<DetailViewModel>();
            Messenger.Register(Delete);
        }

        #region Command

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(Add)); }
        }

        

        #endregion

        public void Add()
        {
            Movie m = new Movie
            {
                Titre = Titre,
                Annee = Annee
            };
            Items.Add(new DetailViewModel(m));
            Titre = "";
            Annee = 0;
        }

        public void Delete(DetailViewModel detail)
        {
            Items.Remove(detail);
        }
    }
}
