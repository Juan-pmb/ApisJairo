using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace projectefjm.Models;
public class Categoria {

// [Key]
    public Guid CategoriaId {get; set;}
    // [Required]
    // [MaxLength(150)]

    public string Nombre {get; set;}

    public string Descripcion {get; set;}

    public virtual  ICollection<Tarea> Tareas {get;set;} 
    //Metodo para facilitar la relacion entre las tablas
}