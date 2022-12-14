using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using System.Text;
using System.Data;
using Dapper;
using Data.Interfaces;

namespace AvanadeInternalTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IClassRepository @object;

        public ClassesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClassesController(IClassRepository @object)
        {
            this.@object = @object;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Entities.ClassEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                // ACESSO AO BANCO COM O ADO 
                // criamos um objeto que contém a string de conexão do banco
                string strConnection = _configuration.GetConnectionString("Sql");

                // abrimos uma conexão com o banco
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                // criamos um comando SELECT
                StringBuilder strCommand = new StringBuilder();
                strCommand.AppendLine("SELECT [Id]");
                strCommand.AppendLine("       ,[Name]");
                strCommand.AppendLine("       ,[Description]");
                strCommand.AppendLine("       ,[InitialPeriod]");
                strCommand.AppendLine("       ,[FinalPeriod]");
                strCommand.AppendLine(" FROM [dbo].[Classes]");

                // executamos o comando na conexão aberta
                SqlCommand cmd = new SqlCommand(strCommand.ToString(), connection);

                // capturamos o retorno do SELECT
                SqlDataReader returnSelect = cmd.ExecuteReader();   

                List<Data.Entities.ClassEntity> classes = new List<Data.Entities.ClassEntity>();

                // vamos ler o retorno e fazer o parse
                while (returnSelect.Read())
                {
                    classes.Add(new Data.Entities.ClassEntity()
                    {
                        Id = Convert.ToInt32(returnSelect["Id"] ?? "0"),
                        Name = returnSelect.GetString("Name"),

                        Description = returnSelect["Description"] != DBNull.Value
                            ? Convert.ToString(returnSelect["Description"])
                            : string.Empty,

                        InitialPeriod = Convert.ToDateTime(
                            returnSelect["InitialPeriod"] == DBNull.Value
                                ? DateTime.MinValue
                                : returnSelect["InitialPeriod"]
                            ),

                        FinalPeriod = Convert.ToDateTime(
                            returnSelect["FinalPeriod"] == DBNull.Value
                                ? DateTime.MinValue
                                : returnSelect["FinalPeriod"]
                            )
                    });
                }

                // fechando a conexão com o banco
                connection.Close();

                return base.Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GelAllDapper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Entities.ClassEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelAllDapper()
        {
            try
            {
                // ACESSO AO BANCO COM O DAPPER 

                // criamos um comando SELECT e armazenamos em strCommand
                StringBuilder strCommand = new StringBuilder();
                strCommand.AppendLine("SELECT [Id]");
                strCommand.AppendLine("       ,[Name]");
                strCommand.AppendLine("       ,[Description]");
                strCommand.AppendLine("       ,[InitialPeriod]");
                strCommand.AppendLine("       ,[FinalPeriod]");
                strCommand.AppendLine(" FROM [dbo].[Classes]");

                // abrimos uma conexão com o banco
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                // criamos uma lista que vai receber o parse da query strCommand
                List<Data.Entities.ClassEntity> classes = connection.Query<Data.Entities.ClassEntity>(strCommand.ToString()).ToList();

                return base.Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOne/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Entities.ClassEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelOne(int Id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);

                Data.Entities.ClassEntity classForId = 
                    connection.Query<Data.Entities.ClassEntity>(
                        "Select Id, Name From Classes Where Id = @Id", dynamicParameters
                        ).FirstOrDefault();
                
                return base.Ok(classForId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Data.Entities.ClassEntity newClass)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                int returnLines = connection.Execute(
                    "INSERT INTO [dbo].[Classes] " +
                    "([Name], [Description], [InitialPeriod], [FinalPeriod]" +
                    "     VALUES(@Name, @Description, @InitialPeriod, @FinalPeriod)", newClass);

                return Ok(returnLines);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update/{id}")]
        public IActionResult Update(Data.Entities.ClassEntity classUpdate)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                int returnLines = connection.Execute(
                          "UPDATE [dbo].[Classes]" +
                          "   SET[Name] = @Name" +
                          "      ,[Description] = @Description" +
                          "      ,[InitialPeriod] = @InitialPeriod" +
                          "      ,[FinalPeriod] = @FinalPeriod" +
                          " WHERE Id = @Id", classUpdate);

                return Ok(returnLines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Data.Entities.ClassEntity classDelete)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                int returnLines = connection.Execute(
                      "DELETE FROM [dbo].[Classes] WHERE Id = @Id", classDelete);

                return Ok(returnLines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
