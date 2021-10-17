using System.Text.Json.Serialization;

namespace DataApiService.Models
{
    /// <summary>
    /// Результат выполнения команды
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор терминала
        /// </summary>
        [JsonPropertyName("terminal_id")]
        public int Termital_id { get; set; }

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        [JsonPropertyName("command_id")]
        public int Command_id { get; set; }

        /// <summary>
        /// Значение первого параметра
        /// </summary>
        [JsonPropertyName("parameter1")]
        public int First_parameter { get; set; }

        /// <summary>
        /// Значение второго параметра
        /// </summary>
        [JsonPropertyName("parameter2")]
        public int Second_parameter { get; set; }

        /// <summary>
        /// Значение третьего параметра
        /// </summary>
        [JsonPropertyName("parameter3")]
        public int Third_parameter { get; set; }

        /// <summary>
        /// Значение четвертого
        /// </summary>
        [JsonPropertyName("parameter4")]
        public int Fourth_parameter { get; set; }

        /// <summary>
        /// Строковое значение первого параметра
        /// </summary>
        [JsonPropertyName("str_parameter1")]
        public string Str_first_parameter { get; set; }

        /// <summary>
        /// Строковое значение второго параметра
        /// </summary>
        [JsonPropertyName("str_parameter2")]
        public string Str_second_parameter { get; set; }

        /// <summary>
        /// Статус выполнения команды
        /// </summary>
        [JsonPropertyName("state")]
        public int State { get; set; }

        /// <summary>
        /// Текст статуса
        /// </summary>
        [JsonPropertyName("state_name")]
        public string State_name { get; set; }

        /// <summary>
        /// Время запроса команды
        /// </summary>
        [JsonPropertyName("time_created")]
        public string Time_created { get; set; }

        /// <summary>
        /// Время доставки команды
        /// </summary>
        [JsonPropertyName("time_delivered")]
        public string Time_delivered { get; set; }
    }
}
