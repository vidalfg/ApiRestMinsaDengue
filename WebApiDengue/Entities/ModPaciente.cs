namespace WebApiDengue.Entities
{
    public class ModPaciente
    {
        public int idPaciente { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public int idTipoDocumento { get; set; }
        public string? numeroDocumento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string? numeroTelefono { get; set; }
        public string? correo { get; set; }
        public string? idDepartamento { get; set; }
        public string? idProvincia { get; set; }
        public string? idDistrito { get; set; }
        public string? direccion { get; set; }
        public string? ubigeo { get; set; }
        public string? apd1Nombres { get; set; }
        public string?  apd1Telefono { get; set; }
        public string? apd2Nombres { get; set; }
        public string? apd2Telefono { get; set; }
        public string? foto { get; set; }
        public int tipoAccion { get; set; }
        public string? userAccion { get; set; }
    }
}
