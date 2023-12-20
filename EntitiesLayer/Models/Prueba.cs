namespace EntitiesLayer.Models
{
    public class Prueba
    {
        public int IdPrueba { get; set; }

        public string Nombre { get; set; }

        public int AspiranteId { get; set; }

        public DateTime F_Inicio { get; set; }

        public DateTime F_final { get; set; }

        public string Tipo_Prueba { get; set; }

        public string Lenguaje_Prg {  get; set; }

        public string Cant_Preguntas { get; set; }

        public string Nivel { get; set; }

        public string Estado { get; set; }

        public virtual ICollection<Aspirante> Aspirantes { get; set; }

    }
}
