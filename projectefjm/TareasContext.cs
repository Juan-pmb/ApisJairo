using Microsoft.EntityFrameworkCore;
using projectefjm.Models;
namespace profectefjm;

public class TareasContext:DbContext {
    
    public DbSet<Categoria> Categorias{get; set;} 

    public DbSet<Tarea> Tareas{get; set;} 

    public TareasContext (DbContextOptions<TareasContext>options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Categoria>(categoria=>
        {
        categoria.ToTable("categorias"); //CREAR LA TABLA CATEGORÍA
        categoria.HasKey(p=> p.CategoriaId); //CREAR EL CATEGORIA ID

        categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150); //Crear validar al campo categoria
        categoria.Property(p=> p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea=> //CREAR ENTIDAD PARA TAREA
        {
            tarea.ToTable("Tarea"); //CREAR LA TABLA TAREA
            tarea.HasKey(p=> p.TareaId); //CREAR LA  PK DE LA TABLA
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId); //CLAVE FORÁNEA
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen); //NO GUARDAR EN BD

        });
    }

}