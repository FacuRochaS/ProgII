using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api24.Modelos
{
    [Table("T_Usuarios")] // le digo que la clase y la tbala se vinculen
    public class Usuario
    {
        [Key]
        [Column("Id_usuario")]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Clave { get; set; }

        public bool activo{ get; set; }

        //agrego el id y el objeto
        //[ForeignKey("Rol")] // busco una tabla que se llama rols que tiene un id que es pk
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
