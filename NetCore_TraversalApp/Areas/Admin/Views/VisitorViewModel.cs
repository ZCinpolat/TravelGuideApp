using Newtonsoft.Json;

namespace NetCore_TraversalApp.Areas.Admin.Views
{
    public class VisitorViewModel
    {
        [JsonProperty("visitorID")]
        public int VisitorID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }
    }
}
