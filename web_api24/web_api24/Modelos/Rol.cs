using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api24.Modelos
{
    [Table("T_Roles")] // le digo que la clase y la tbala se vinculen, esta entidad se corresponde a una tabla, si no le digo nada se va a dar cuenta del dbcontext
    public class Rol
    {
        [Key] // le digo que el id va a ser una primary key
        [Column("id_rol")] // le aclaro el nombre del id
        public int Id { get; set; }


        [Required]
        public string Nombre { get; set; }

        //la relacion de los 2 lados
        public ICollection<Usuario> Usuarios = new List<Usuario>();
    }
}
