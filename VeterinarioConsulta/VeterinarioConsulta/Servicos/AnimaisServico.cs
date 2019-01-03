using System;
using System.Collections.Generic;
using System.Text;
using VeterinarioConsulta.Modelos;

namespace VeterinarioConsulta.Servicos
{
    public class AnimaisServico
    {
        public static Animal AnimalAtual { get; set; }

        public List<Animal> ObterTodos()
        {
            var animais = new List<Animal>()
            {
                new Animal(){ID = 1, Nome = "Bola", Idade = "1 ano", Especie = "Coelho",
                    Peso = 1.4, Raca = "Lebre", Tamanho = "Medio", Descricao = "Coelho de porte médio, pelo escuro, bem bravo, teve 6 filhotes" },
                new Animal(){ID = 2, Nome = "Bob", Idade = "6 meses", Especie = "Coelho",
                    Peso = 0.6, Raca = "Lebre", Tamanho = "Pequeno", Descricao = "Fraco" }
            };

            return animais;
        }
    }
}
