using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure {
    // hook this up in the startup class
    public class IonOutputFormatter : TextOutputFormatter {
        private readonly JsonOutputFormatter _jsonOutputFormatter;
        public IonOutputFormatter(JsonOutputFormatter jsonOutputFormatter) {
            if (jsonOutputFormatter == null) throw new ArgumentNullException(nameof(jsonOutputFormatter));
            _jsonOutputFormatter = jsonOutputFormatter;

            SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/ion+json"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding) =>
            _jsonOutputFormatter.WriteResponseBodyAsync(context, selectedEncoding);
        
    }
}
