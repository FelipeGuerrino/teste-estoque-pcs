namespace src.Models
{
    public class Computer
    {
        public Computer() { }
        public Computer(int id, string marca, string modelo, string placaMae, int memoriaRam, int armazenamento, double velocidadeProcessador)
        {
            this.Id = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.PlacaMae = placaMae;
            this.MemoriaRam = memoriaRam;
            this.Armazenamento = armazenamento;
            this.VelocidadeProcessador = velocidadeProcessador;

        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string PlacaMae { get; set; }
        public int MemoriaRam { get; set; }
        public int Armazenamento { get; set; }
        public double VelocidadeProcessador { get; set; }
    }
}