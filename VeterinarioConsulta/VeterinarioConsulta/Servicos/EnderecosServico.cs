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
                new Enderecos(){ Endereco= "Rua Gêres", Latitude = -23.6592706, Longitude = -46.7812831, Numero = 210},
                new Enderecos(){ Endereco = "Estr. de Itapecerica", Latitude = -23.6599295, Longitude = -46.7782246, Numero=4830}
            };

            return enderecos;
        }
    }
}
