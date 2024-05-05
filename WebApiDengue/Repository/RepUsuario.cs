using System.Data;

namespace WebApiDengue.Repository
{
    public class RepUsuario
    {
        FuncionesGenerales _funciones = new();
        Dictionary<string, string> _parametros = new();

        public bool VerficarUsuario(string usuario, string pass)
        {
            _parametros.Add("@USUARIO", usuario);
            _parametros.Add("@CONTRASENHA", pass);

            DataTable dt = new DataTable();

            dt = _funciones.CargarDatos("sel_usa_usuario_api", _parametros);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
