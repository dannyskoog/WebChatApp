using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebChatApp.Models
{
    public class HubUser
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("isTyping")]
        public bool IsTyping { get; set; }

        public HubUser(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}