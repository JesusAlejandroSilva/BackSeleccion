using EntitiesLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;


namespace APICORE.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/Aspirante")]
   // [Authorize]
    [ApiController]
    public class AspirantesController : ControllerBase
    {
        private readonly string ConnectionString;

        public AspirantesController(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("SQL");
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Lista()
        {
            List<Aspirante> lista = new List<Aspirante>();
            try
            {
                using(var conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_Lista_Aspirante", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Aspirante()
                            {
                                IdAspirante = Convert.ToInt32(reader["IdAspirante"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Estado_Prueba = reader["Estado_Prueba"].ToString(),
                                Calificacion = reader["Calificacion"].ToString()

                            }) ;
                        }
                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = lista });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }


        [HttpGet]
        [Route("Buscar/{IdAspirante:int}")]
        public IActionResult Buscar(int IdAspirante)
        {
            List<Aspirante> lista = new List<Aspirante>();
            Aspirante Aspirante = new Aspirante();
            try
            {
                using (var conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_Lista_Aspirante", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Aspirante()
                            {
                                IdAspirante = Convert.ToInt32(reader["IdAspirante"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Estado_Prueba = reader["Estado_Prueba"].ToString(),
                                Calificacion = reader["Calificacion"].ToString()

                            });
                        }
                    }

                }
                Aspirante = lista.Where(item => item.IdAspirante == IdAspirante).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = Aspirante });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = Aspirante });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Aspirante aspirante)
        {
            try
            {
                using (var conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_Guardar_Aspirante", conexion);
                    cmd.Parameters.AddWithValue("Nombre", aspirante.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", aspirante.Apellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", aspirante.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Email", aspirante.Email);
                    cmd.Parameters.AddWithValue("Telefono", aspirante.Telefono);
                    cmd.Parameters.AddWithValue("EstadoPrueba", aspirante.Estado_Prueba);
                    cmd.Parameters.AddWithValue("Calificacion", aspirante.Calificacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
               

                }
       
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok"});

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message});
            }
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Aspirante aspirante)
        {
            try
            {
                using (var conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_Actualizar_Aspirante", conexion);
                    cmd.Parameters.AddWithValue("IdAspirante", aspirante.IdAspirante == 0 ? DBNull.Value : aspirante.IdAspirante);
                    cmd.Parameters.AddWithValue("Nombre", aspirante.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", aspirante.Apellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", aspirante.Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("Email", aspirante.Email);
                    cmd.Parameters.AddWithValue("Telefono", aspirante.Telefono);
                    cmd.Parameters.AddWithValue("EstadoPrueba", aspirante.Estado_Prueba);
                    cmd.Parameters.AddWithValue("Calificacion", aspirante.Calificacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdAspirante:int}")]
        public IActionResult Eliminar(int IdAspirante)
        {
            try
            {
                using (var conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_Eliminar_Aspirante", conexion);
                    cmd.Parameters.AddWithValue("IdAspirante", IdAspirante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}
