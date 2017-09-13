using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam.Model
{
    class FavouriteModel
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "User")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "FoodItem")]
        public string FoodItem { get; set; }
    }
}
