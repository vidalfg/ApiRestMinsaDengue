using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using WebApiDengue.Repository;
using Newtonsoft.Json;

namespace WebApiDengue.Resources.Data
{
    public class DataAccess
    {

        // Cadena de conexión a la BBDD SQL
        public static string cadenaConexion = "";

        #region Listado InitForm en formatos ListarTablas JSON
        /// <summary>
        /// Metodo para Listar Inicializar Formulario 
        /// </summary>
        /// <param name="nombreProcedimiento"></param>
        /// <param name="parametros"></param>
        /// <param name="prSalida"></param>
        /// <returns></returns>
        public static async Task<dynamic> ListarTablasToJson(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Name, parametro.Value);
                    }
                    if (prSalida)
                    {
                        cmd.Parameters.Add("@NameTable", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                    }

                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (prSalida)
                    {
                        string dataName = Convert.ToString(cmd.Parameters["@NameTable"].Value) ?? string.Empty;
                        string[] partes = dataName.Split("|");
                        int index = 0;
                        foreach (DataTable table in dataSet.Tables)
                        {
                            table.TableName = partes[index];
                            index++;
                        }
                    }

                    var resultObject = new
                    {
                        iscorrect = true,
                        status = 200,
                        message = "exito",
                        data = ConvertDataSetToDictionary(dataSet)
                    };

                    string jsonResult = JsonConvert.SerializeObject(resultObject, Newtonsoft.Json.Formatting.Indented);
                    return jsonResult;

                }

            }
            catch (Exception ex)
            {
                return new Response<object>(false, -1, ex.Message, new List<object>());
            }
            finally
            {
                conexion.Close();
            }
        }

        // Método para convertir un DataSet a un diccionario de listas de objetos dinámicos
        private static Dictionary<string, List<object>> ConvertDataSetToDictionary(DataSet dataSet)
        {
            var result = new Dictionary<string, List<object>>();

            foreach (DataTable table in dataSet.Tables)
            {
                var list = ConvertDataTableToList(table);
                result.Add(table.TableName, list);
            }
            return result;
        }
        //convertir un table a objeto con sus respectivos columnas tb
        private static List<object> ConvertDataTableToList(DataTable table)
        {
            List<object> list = new List<object>();

            foreach (DataRow row in table.Rows)
            {
                var obj = new ExpandoObject() as IDictionary<string, object>;

                foreach (DataColumn col in table.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }

                list.Add(obj);
            }
            return list;
        }

        #endregion


        /// <summary>
        /// Ejecuta acciones de Insertar, Actualizar y Eliminar
        /// </summary>
        /// <param name="nombreProcedimiento"></param>
        /// <param name="parametros"></param>
        /// <param name="prSalida"></param>
        /// <returns></returns>
        public static async Task<dynamic> EjecutarInsDelUp(string nombreProcedimiento, List<Parameter>? parametros = null, bool prSalida = false)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Name, parametro.Value);
                    }
                    if (prSalida)
                    {
                        cmd.Parameters.Add("@NameTable", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                    }
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (prSalida)
                    {
                        string dataName = Convert.ToString(cmd.Parameters["@NameTable"].Value) ?? string.Empty;
                        string[] partes = dataName.Split("|");
                        int index = 0;
                        foreach (DataTable table in dataSet.Tables)
                        {
                            table.TableName = partes[index];
                            index++;
                        }
                    }

                    var resultObject = new
                    {
                        iscorrect = true,
                        status = 200,
                        message = "exito",
                        data = ConvertDataSetToDictionary(dataSet)
                    };

                    string jsonResult = JsonConvert.SerializeObject(resultObject, Newtonsoft.Json.Formatting.Indented);
                    return jsonResult;

                }

            }
            catch (Exception ex)
            {
                return new Response<object>(false, -1, ex.Message, new List<object>());
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
