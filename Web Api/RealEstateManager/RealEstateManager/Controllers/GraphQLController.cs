using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Utils;

namespace RealEstateManager.Controllers {
    [Route("[controller]")]
    public class GraphQLController : Controller {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter) {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query) {
            if (query == null) {
                throw new ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var res = await _documentExecuter.ExecuteAsync(executionOptions);
            if (res.Errors?.Count > 0) {
                return BadRequest();
            }

            return Ok(res);
        }

    }
}