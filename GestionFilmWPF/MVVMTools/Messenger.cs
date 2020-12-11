using GestionFilmWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFilmWPF.MVVMTools
{
    public static class Messenger
    {
        private static Action<DetailViewModel> Messaging;

        public static void Register(Action<DetailViewModel> toExecute)
        {
            Messaging += toExecute;
        }

        public static void Send(DetailViewModel detail)
        {
            Messaging?.Invoke(detail);
        }
    }
}
