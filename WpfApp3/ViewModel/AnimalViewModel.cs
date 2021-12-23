using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class Animal : ICloneable
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string raça { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
#pragma warning disable CS0116 // Um namespace não pode conter diretamente membros, como campos, métodos ou instruções
    public NovoCommand Novo { get; private set; } = new NovoCommand();
#pragma warning restore CS0116 // Um namespace não pode conter diretamente membros, como campos, métodos ou instruções

#pragma warning disable CS0116 // Um namespace não pode conter diretamente membros, como campos, métodos ou instruções
    public EditarCommand Editar { get; private set; } = new EditarCommand();
#pragma warning restore CS0116 // Um namespace não pode conter diretamente membros, como campos, métodos ou instruções
    public class AnimalViewModel : BaseNotifyPropertyChanged
    {
#pragma warning disable CS0053 // Acessibilidade inconsistente: tipo de propriedade "ObservableCollection<Animal>" é menos acessível do que a propriedade "AnimalViewModel.Animal"
        public System.Collections.ObjectModel.ObservableCollection<Model.Animal> Animal { get; private set; }
#pragma warning restore CS0053 // Acessibilidade inconsistente: tipo de propriedade "ObservableCollection<Animal>" é menos acessível do que a propriedade "AnimalViewModel.Animal"

        private Model.Animal _animalSelecionado;
#pragma warning disable CS0053 // Acessibilidade inconsistente: tipo de propriedade "Animal" é menos acessível do que a propriedade "AnimalViewModel.AnimalSelecionado"
        public Model.Animal AnimalSelecionado
#pragma warning restore CS0053 // Acessibilidade inconsistente: tipo de propriedade "Animal" é menos acessível do que a propriedade "AnimalViewModel.AnimalSelecionado"

        {
            get { return _animalSelecionado; }
            set { SetField(ref _animalSelecionado, value); }
        }
        public AnimalViewModel()
        {
            Animal = new System.Collections.ObjectModel.ObservableCollection<Model.Animal>();
            Animal.Add(new Model.Animal(){ });
            AnimalSelecionado = Animal.FirstOrDefault();
        } }
    public class DeletarCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as AnimalViewModel;
            return viewModel != null && viewModel.AnimalSelecionado != null;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (AnimalViewModel)parameter;
            viewModel.Animal.Remove(viewModel.AnimalSelecionado);
            viewModel.AnimalSelecionado = viewModel.Animal.FirstOrDefault();
        }
    }
    public class EditarCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as AnimalViewModel;
            return viewModel != null && viewModel.AnimalSelecionado != null;
        }

#pragma warning disable CS0115 // "EditarCommand.Execute(object, object)": não encontrado nenhum método adequado para substituição
        public override void Execute(object parameter, object cloneAnimal)
#pragma warning restore CS0115 // "EditarCommand.Execute(object, object)": não encontrado nenhum método adequado para substituição
        {
            var viewModel = (AnimalViewModel)parameter;
            Model.Animal? cloneAnimal = Model.Animal.Clone();
            var fw = new AnimalWindow();
            fw.DataContext = cloneAnimal;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                viewModel.AnimalSelecionado.Nome = cloneAnimal.Nome;
                viewModel.AnimalSelecionado.Id = cloneAnimal.Id;
                viewModel.AnimalSelecionado.raça = cloneAnimal.raça;
                viewModel.AnimalSelecionado.idade = cloneAnimal.idade;
            }
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
