
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CadastroEventos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private string nomeEvento;
        private DateTime dataInicio = DateTime.Today;
        private DateTime dataTermino = DateTime.Today.AddDays(1);
        private int numeroParticipantes;
        private string localEvento;
        private decimal custoPorParticipante;

        public string NomeEvento
        {
            get => nomeEvento;
            set { nomeEvento = value; OnPropertyChanged(); }
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set
            {
                dataInicio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duracao));
            }
        }

        public DateTime DataTermino
        {
            get => dataTermino;
            set
            {
                dataTermino = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duracao));
            }
        }

        public int NumeroParticipantes
        {
            get => numeroParticipantes;
            set
            {
                numeroParticipantes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public string LocalEvento
        {
            get => localEvento;
            set => localEvento = value;
        }

        public decimal CustoPorParticipante
        {
            get => custoPorParticipante;
            set
            {
                custoPorParticipante = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public TimeSpan Duracao =>
            (DataTermino.Date - DataInicio.Date);

        public decimal CustoTotal =>
            NumeroParticipantes * CustoPorParticipante;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string nome = null)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(nome));
        }
    }
}
