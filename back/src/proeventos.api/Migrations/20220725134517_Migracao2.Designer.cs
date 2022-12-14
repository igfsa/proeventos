// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proeventos.api.Models;

#nullable disable

namespace proeventos.api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220725134517_Migracao2")]
    partial class Migracao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("proeventos.api.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("proeventos.api.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DataEvento")
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .HasColumnType("longtext");

                    b.Property<string>("Lote")
                        .HasColumnType("longtext");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .HasColumnType("longtext");

                    b.HasKey("EventoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("proeventos.api.Models.Evento", b =>
                {
                    b.HasOne("proeventos.api.Models.Categoria", "Categoria")
                        .WithMany("Eventos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proeventos.api.Models.Categoria", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
