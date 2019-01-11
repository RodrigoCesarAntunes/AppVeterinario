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
                new Enderecos(){ Endereco= "Rua Gêres", Latitude = -23.65964, Longitude = -46.781793, Numero = 210, Titulo="Consultório 1", TipoDeEstabelecimento = Utils.TiposPins.Veterinario },
                new Enderecos(){ Endereco = "Estr. de Itapecerica", Latitude = -23.6592171, Longitude = -46.7744844,
                    Numero =4830, Titulo="Loja de ração 1", TipoDeEstabelecimento = Utils.TiposPins.Patrocinador},
                new Enderecos() { Endereco = "R. Pedro José da Silva, 280-398 - Jardim Campo dos Ferreiros, São Paulo - SP",
                    Latitude = -23.658941, Longitude = -46.778368, Numero = 280, Titulo="Instituição de caridade 1" , TipoDeEstabelecimento = Utils.TiposPins.InstituicaoDeCaridade}
            };
            return enderecos;
        }
    }
}
