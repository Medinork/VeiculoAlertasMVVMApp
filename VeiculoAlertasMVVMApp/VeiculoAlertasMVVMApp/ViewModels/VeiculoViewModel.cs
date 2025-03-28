using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace VeiculoAlertasMVVMApp.ViewModels
{
    public class VeiculoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string marca;
        public string Marca
        {
            get => marca;
            set
            {
                marca = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Marca)));
            }
        }

        private string modelo;
        public string Modelo
        {
            get => modelo;
            set
            {
                modelo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Modelo)));
            }
        }

        private int ano;
        public int Ano
        {
            get => ano;
            set
            {
                ano = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ano)));
            }
        }

        public ICommand ExibirDetalhesCommand { get; }

        public VeiculoViewModel()
        {
            ExibirDetalhesCommand = new Command(ExibirDetalhes);
        }

        private void ExibirDetalhes()
        {
            if (string.IsNullOrWhiteSpace(Marca) || string.IsNullOrWhiteSpace(Modelo) || Ano <= 0)
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Preencha marca, modelo e ano.", "OK");
                return;
            }
            Application.Current.MainPage.DisplayAlert("Detalhes", $"Marca: {Marca}\nModelo: {Modelo}\nAno: {Ano}", "OK");
        }
    }
}
