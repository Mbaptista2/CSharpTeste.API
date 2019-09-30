using CSharp.ApiProject.Serialization;
using CSharp.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CSharp.ApiProject.Response
{
    public class Presenter : IOutputPort<CasoDeUsoResponseMessage>, IOutputPort<IEnumerable<CasoDeUsoResponseMessage>>
    {
        public JsonContentResult ContentResult { get; }

        public Presenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handler(CasoDeUsoResponseMessage response)
        {
            var isValid = response.IsValid();
            ContentResult.StatusCode = (int)(isValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = isValid ? JsonSerializer.SerializeObject(response) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void Handler(IEnumerable<CasoDeUsoResponseMessage> response)
        {
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
