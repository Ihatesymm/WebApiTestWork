using DataApiService.Models;
using System.Collections.Generic;

namespace WebServer.Models
{
    public class CommandsViewModel
    {
        public IEnumerable<Commands> Commands { get; set; }
        public List<CommandResult> CommandResults { get; set; }
    }
}
