using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class NovoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is Animal;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (AnimalViewModel)parameter;
            var animal = new Model.Animal();
            var maxId = 0;
            if (viewModel.Animal.Any())
            {
                maxId = viewModel.Animal.Max(f => f.Id);
            }
            animal.Id = maxId + 1;

            var fw = new AnimalWindow();
            fw.DataContext = animal;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                viewModel.Animal.Add(animal);
                viewModel.AnimalSelecionado = animal;
            }
        }
    }
}
