using System.Collections.ObjectModel;

namespace EntitiesLayer.Models
{
    public class Preguntas
    {
        public int IdPregunta { get; set; }

        public int PruebaId { get; set; }

        public string Enunciado { get; set; }

        public string Opciones { get; set; }

        public string Res_Correctas { get; set; }


        public virtual Collection<Prueba> Pruebas { get; set; }

    }
}
