using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam.Model
{
    class Favourite
    {
        [JsonProperty(PropertyName = "User")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "FoodItem")]
        public string FoodItem { get; set; }
    }
}
