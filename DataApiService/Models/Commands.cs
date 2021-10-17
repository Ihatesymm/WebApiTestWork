using System.Text.Json.Serialization;

namespace DataApiService.Models
{
    /// <summary>
    /// Комманды
    /// </summary>
    public class Commands
    {
        /// <summary>
        /// Идентификатор команды
        /// </summary>
        [JsonPropertyName("id")]
        public int Command_id { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        [JsonPropertyName("name")]
        public string Command_name { get; set; }

        /// <summary>
        /// Название первого параметра
        /// </summary>
        [JsonPropertyName("parameter_name1")]
        public string Command_first_param { get; set; }

        /// <summary>
        /// Название второго параметра
        /// </summary>
        [JsonPropertyName("parameter_name2")]
        public string Command_second_param { get; set; }


        /// <summary>
        /// Название третьего параметра
        /// </summary>
        [JsonPropertyName("parameter_name3")]
        public string Command_third_param { get; set; }

        /// <summary>
        /// Значение по умолчанию первого параметра
        /// </summary>
        [JsonPropertyName("parameter_default_value1")]
        public int? Command_first_defval { get; set; }

        /// <summary>
        /// Значение по умолчанию второго параметра
        /// </summary>
        [JsonPropertyName("parameter_default_value2")]
        public int? Command_second_defval { get; set; }

        /// <summary>
        /// Значение по умолчанию третьего параметра
        /// </summary>
        [JsonPropertyName("parameter_default_value3")]
        public int? Command_third_defval { get; set; }   
    }
}
