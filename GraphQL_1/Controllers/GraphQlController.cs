using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQL_1.Controllers
{
    #region GraphQlController
    [Route("[controller]")]
    [ApiController]
    public class GraphQlController :
        Controller
    {
        IDocumentExecuter executer;
        ISchema schema;

        public GraphQlController(ISchema schema, IDocumentExecuter executer)
        {
            this.schema = schema;
            this.executer = executer;
        }

        [HttpPost]
        public Task<ExecutionResult> Post(
            [BindRequired, FromBody] PostBody body,
            [FromServices] AppDbContext dbContext,
            CancellationToken cancellation)
        {
            return Execute(dbContext, body.Query, body.OperationName, body.Variables, cancellation);
        }

        public class PostBody
        {
            public string OperationName;
            public string Query;
            public JObject Variables;
        }

        [HttpGet]
        public Task<ExecutionResult> Get(
            [FromQuery] string query,
            [FromQuery] string variables,
            [FromQuery] string operationName,
            [FromServices] AppDbContext dbContext,
            CancellationToken cancellation)
        {
            var jObject = ParseVariables(variables);
            return Execute(dbContext, query, operationName, jObject, cancellation);
        }

        async Task<ExecutionResult> Execute(
            AppDbContext dbContext,
            string query,
            string operationName,
            JObject variables,
            CancellationToken cancellation)
        {
            var options = new ExecutionOptions
            {
                Schema = schema,
                Query = query,
                OperationName = operationName,
                Inputs = variables?.ToInputs(),
                UserContext = dbContext,
                CancellationToken = cancellation,
#if (DEBUG)
                ExposeExceptions = true,
                EnableMetrics = true,
#endif
            };

            var result = await executer.ExecuteAsync(options);

            if (result.Errors?.Count > 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return result;
        }

        static JObject ParseVariables(string variables)
        {
            if (variables == null)
            {
                return null;
            }

            try
            {
                return JObject.Parse(variables);
            }
            catch (Exception exception)
            {
                throw new Exception("Could not parse variables.", exception);
            }
        }
    }
    #endregion
}
