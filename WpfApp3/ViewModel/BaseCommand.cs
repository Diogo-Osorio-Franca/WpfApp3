using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public abstract class BaseCommand : System.Windows.Input.ICommand
    {
#pragma warning disable CS8612 // A nulidade de tipos de referência no tipo de 'event EventHandler BaseCommand.CanExecuteChanged' não corresponde ao membro implicitamente implementado 'event EventHandler? ICommand.CanExecuteChanged'.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS8612 // A nulidade de tipos de referência no tipo de 'event EventHandler BaseCommand.CanExecuteChanged' não corresponde ao membro implicitamente implementado 'event EventHandler? ICommand.CanExecuteChanged'.

#pragma warning disable CS8767 // A nulidade de tipos de referência no tipo de parâmetro 'parameter' de 'bool BaseCommand.CanExecute(object parameter)' não corresponde ao membro implementado implicitamente 'bool ICommand.CanExecute(object? parameter)' (possivelmente devido a atributos de nulidade).
        public virtual bool CanExecute(object parameter) => true;
#pragma warning restore CS8767 // A nulidade de tipos de referência no tipo de parâmetro 'parameter' de 'bool BaseCommand.CanExecute(object parameter)' não corresponde ao membro implementado implicitamente 'bool ICommand.CanExecute(object? parameter)' (possivelmente devido a atributos de nulidade).
#pragma warning disable CS8767 // A nulidade de tipos de referência no tipo de parâmetro 'parameter' de 'void BaseCommand.Execute(object parameter)' não corresponde ao membro implementado implicitamente 'void ICommand.Execute(object? parameter)' (possivelmente devido a atributos de nulidade).
        public abstract void Execute(object parameter);
#pragma warning restore CS8767 // A nulidade de tipos de referência no tipo de parâmetro 'parameter' de 'void BaseCommand.Execute(object parameter)' não corresponde ao membro implementado implicitamente 'void ICommand.Execute(object? parameter)' (possivelmente devido a atributos de nulidade).

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
