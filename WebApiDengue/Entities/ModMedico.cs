namespace WebApiDengue.Entities
{
    public class ModMedico
    {
        public int      idMedico { get; set; }
        public string   nombres { get; set; }
        public string   apellidos { get; set; }
        public int      idTipDoc { get; set; }
        public string   nroDocumento { get; set; }
        public string   especialidad { get; set; }
        public string   telefono { get; set; }
        public string   correo { get; set; }
        public string   foto { get; set; }
        public int tipoAccion { get; set; }
        public string userAccion { get; set; }

    }
}
