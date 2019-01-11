using System;
using System.Collections.Generic;
using System.Text;
using VeterinarioConsulta.Utils;

namespace VeterinarioConsulta.Modelos
{
    public class Enderecos
    {
        public string Titulo { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TiposPins TipoDeEstabelecimento { get; set; }
    }
}
