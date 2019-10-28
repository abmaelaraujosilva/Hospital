using Hospital.Shared.Entidades;
using System;

namespace Hospital.Domain.Entidades
{
    public class Paciente : Entidade
    {
        public Paciente(string nome, string sobrenome, string cpf, string telefone, DateTime dataDeNacimento)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            DataDeNacimento = dataDeNacimento;
            Sobrenome = sobrenome;
            if (string.IsNullOrEmpty(nome))
                AddErros("Nome", "O campo Nome deve ter ao menos 1 caractere");
            if (string.IsNullOrEmpty(sobrenome))
                AddErros("Sobrenome", "O campo Sobrenome deve ter ao menos 1 caractere");
            if (string.IsNullOrEmpty(telefone))
                AddErros("Telefone", "O campo Telefone é obrigatorio");
            if (string.IsNullOrEmpty(cpf))
                AddErros("CPF", "O campo CPF é obrigatorio");
            if (!IsCpf(cpf))
                AddErros("CPF", "O CPF é invalido");
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataDeNacimento { get; private set; }


        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
