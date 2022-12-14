// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src.Data;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("src.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Armazenamento")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemoriaRam")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacaMae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("VelocidadeProcessador")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Computers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Armazenamento = 512,
                            Marca = "Acer",
                            MemoriaRam = 8,
                            Modelo = "Nitro 5 AN515-44",
                            PlacaMae = "RO Stonic RNS",
                            VelocidadeProcessador = 4.2999999999999998
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
