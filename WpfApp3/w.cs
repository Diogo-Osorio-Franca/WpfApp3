using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3
{
    public abstract class BaseNotifyPropertyChanged : System.ComponentModel.INotifyPropertyChanged
    {
#pragma warning disable CS8612 // A nulidade de tipos de referência no tipo de 'event PropertyChangedEventHandler BaseNotifyPropertyChanged.PropertyChanged' não corresponde ao membro implicitamente implementado 'event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged'.
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS8612 // A nulidade de tipos de referência no tipo de 'event PropertyChangedEventHandler BaseNotifyPropertyChanged.PropertyChanged' não corresponde ao membro implicitamente implementado 'event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged'.

        protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

