using System;
using System.Collections.Generic;
using System.Text;
using VeterinarioConsulta.Modelos;

namespace VeterinarioConsulta.Servicos
{
    public class EnderecosServico
    {
        public List<Enderecos> ObterTodos()
        {
            var enderecos = new List<Enderecos>()
            {
                new Enderecos(){ Endereco= "Rua Gêres", Latitude = -23.65964, Longitude = -46.781793, Numero = 210},
                new Enderecos(){ Endereco = "Estr. de Itapecerica", Latitude = -23.6592171, Longitude = -46.7744844, Numero=4830},
                new Enderecos() { Endereco = "R. Pedro José da Silva, 280-398 - Jardim Campo dos Ferreiros, São Paulo - SP", Latitude = -23.658941, Longitude = -46.778368, Numero = 280 }
            };
            return enderecos;
        }
    }
}
