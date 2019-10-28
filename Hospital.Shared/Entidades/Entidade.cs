using System;
using System.Collections.Generic;

namespace Hospital.Shared.Entidades
{
    public class Entidade
    {
        public Entidade(Guid id)
        {
            Id = id;
        }
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public List<Tuple<string, string>> Erros { get; private set; }

        public void AddErros(string chave, string erro)
        {
            Erros.Add(new Tuple<string, string>(chave, erro));
        }
    }
}
