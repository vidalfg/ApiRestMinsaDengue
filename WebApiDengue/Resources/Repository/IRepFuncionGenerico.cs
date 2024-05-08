using WebApiDengue.Resources.Data;

namespace WebApiDengue.Resources.Repository
{
    public interface IRepFuncionGenerico
    {
        public Task<dynamic> Listar(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false);

        public Task<dynamic> EjecutarInsDelUp(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false);
    }
}
