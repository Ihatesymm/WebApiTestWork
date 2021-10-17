using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApiService;
using DataApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class CommandsController : Controller
    {
        private readonly ILogger<CommandsController> _logger;
        private IDataManager _dataManager;
        private static CommandsViewModel CommandsViewModel = new CommandsViewModel() { CommandResults = new List<CommandResult>(), Commands = null };

        public CommandsController(ILogger<CommandsController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _dataManager.Auth("demo", "demo15");
        }

        /// <summary>
        /// Список всех событий по умолчанию
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //Заполняем дроп лист выбора автоматов
            await SetMachinesDropList();

            //Формируем запрос событий на сегодня
            CommandsViewModel.Commands = await _dataManager.GetItems<IEnumerable<Commands>>("commands/types");

            return View(CommandsViewModel);
        }

        /// <summary>
        /// Список событий по фильтру
        /// </summary>
        /// <param name="pars">Набор параметров</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            //Проверка параметров запроса
            if (!ModelState.IsValid)
            {
                //Можно формировать сообщение или отправить на страницу ошибок, пока так
                //TODO Не в продакшен
                return BadRequest();
            }

            //Заполняем дроп лист выбора автоматов
            await SetMachinesDropList();

            //Формируем запрос событий
            //Конвертация даты из формата ДД.ММ.ГГГГ в ГГГГ-ММ-ДД происходит при маппинге параметров в классе EventsActionParameters
            CommandsViewModel.Commands = await _dataManager.GetItems<IEnumerable<Commands>>("commands/types");

            //Сохраняем выбранный в фильтре аппарат
            ViewData["Select_Command_id"] = id;

            return View(CommandsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendCommand(string terminal_id, string command_id, string first_param, string second_param, string third_param)
        {
            await SetMachinesDropList();

            var parameters = new Dictionary<string, string>();

            if (command_id != null)
                parameters.Add("command_id", command_id);

            if (first_param != null)
                parameters.Add("parameter1", first_param);

            if (second_param != null)
                parameters.Add("parameter2", second_param);

            if (third_param != null)
                parameters.Add("parameter3", third_param);

            //Формируем запрос событий
            //Конвертация даты из формата ДД.ММ.ГГГГ в ГГГГ-ММ-ДД происходит при маппинге параметров в классе EventsActionParameters

            foreach (var id in terminal_id.Split(new char[] { ' ', ',', '\n', '\r', '\t'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var result = await _dataManager.GetItems<CommandResult>($"terminals/{id}/command", parameters);

                CommandsViewModel.CommandResults.Add(result);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Заполнение списка доступных комманд
        /// </summary>
        /// <remarks>
        /// Заполняет список в ViewData["Commands"]
        /// </remarks>
        /// <returns></returns>
        private async Task SetMachinesDropList()
        {
            //Запрос комманд
            var commands = await _dataManager.GetItems<IEnumerable<Commands>>("commands/types");

            //Мапинг в дроп лист
            var resultList = commands.Select(x => new SelectListItem($"{x.Command_name}", x.Command_id.ToString())).ToList();

            ViewData["Commands"] = resultList;
        }
    }
}
