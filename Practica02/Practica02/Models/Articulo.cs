namespace Practica02.Models
{
    public class Articulo
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public override string ToString()
        {
            return @$" Nro |{Id}|  - {Nombre}    ${Precio}";
        }
    }
}
