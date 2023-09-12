using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;

namespace LandonApi.Models {
    public class ApiError {
        public ApiError() {

        }

        public ApiError(string message) {
            Message = message;
        }

        public ApiError(ModelStateDictionary modelstate) {
            Message = "Invalid parameters";
            Detail = modelstate.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors.FirstOrDefault().ErrorMessage;
        }
        public string Message { get; set; }
        public string Detail { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore,DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }
    }
}
