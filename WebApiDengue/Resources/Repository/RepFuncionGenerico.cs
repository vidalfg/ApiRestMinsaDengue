using WebApiDengue.Resources.Data;

namespace WebApiDengue.Resources.Repository
{
    public class RepFuncionGenerico : IRepFuncionGenerico
    {
        public Task<dynamic> Listar(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false)
        {
            return DataAccess.ListarTablasToJson(nombreProcedimiento, parametros, prSalida);
        }

        public Task<dynamic> EjecutarInsDelUp(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false)
        {
            return DataAccess.EjecutarInsDelUp(nombreProcedimiento, parametros, prSalida);
        }
    }
}
