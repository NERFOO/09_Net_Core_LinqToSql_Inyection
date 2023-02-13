namespace _09_Net_Core_LinqToSql_Inyection.Models
{
    public interface ICoche
    {
        //AQUI SOLAMENTE SE DECLARAN LOS METODOS Y PROPIEDADES QUE TENDRAN CUALQUIER CLASE QUE HEREDE
        string Marca { get; set; }
        string Modelo { get; set; }
        string Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMaxima { get; set; }
        int Acelerar();
        int Frenar();
    }
}
