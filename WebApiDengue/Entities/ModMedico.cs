namespace WebApiDengue.Entities
{
    public class ModMedico
    {
        public int      idMedico { get; set; }
        public string   nombres { get; set; }
        public string   apellidos { get; set; }
        public int      idTipDoc { get; set; }
        public string   NroDocumento { get; set; }
        public string   Especialidad { get; set; }
        public string   telefono { get; set; }
        public string   correo { get; set; }
        public string   foto { get; set; }
        public string tipoAccion { get; set; }

    }
}
