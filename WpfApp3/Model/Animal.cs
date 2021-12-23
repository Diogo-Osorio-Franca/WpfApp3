using System;

namespace WpfApp3.Model
{
    internal class Animal
    {
        public int Id { get; internal set; }
        public object Nome { get; internal set; }
        public object raça { get; internal set; }
        public object idade { get; internal set; }

        internal Animal Clone()
        {
            throw new NotImplementedException();
        }
    }
}