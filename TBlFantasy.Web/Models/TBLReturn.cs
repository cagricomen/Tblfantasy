using System.Collections.Generic;
using Newtonsoft.Json;

namespace TBlFantasy.Web
{
     public class TBLReturn
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; set; }
        public int Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
        public bool Success { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<TBLReturnError> Errors { get; set; }
    }
    public class TBLReturnError
    {
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; set; }
        public string Name { get; set; }
    }
}
