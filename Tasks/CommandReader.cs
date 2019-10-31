using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tasks
{
    public class CommandReader
    {
        private List<Job> Tasks = new List<Job>() {};

        private string jsonFile = Environment.CurrentDirectory + "\\tasks.json";

        private string startMsg = @"Введите addjob для добавления задачи
Введите showall для просмотра задач
Введите exit для выхода";
        private string delimeter = "\r\n-----------------------------------------------\r\n";

        private bool stop = false;

        public CommandReader ()
        {
            if (File.Exists(jsonFile)) {
                string json = File.ReadAllText(jsonFile);
                Tasks = JsonConvert.DeserializeObject<List<Job>>(json);
            }
        }

        public void start ()
        {
            Console.WriteLine(startMsg + delimeter);
            while (true) 
            {
                string command = Console.ReadLine();

                doAction(command);

                if (stop)
                    break;
            }
        }

        public void doAction(string command)
        {
            command = command.Trim();

            switch (command) {
                case "addjob":
                    Console.WriteLine("Введите название задачи: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите описание задачи: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Введите метку для задачи: ");
                    string tag = Console.ReadLine();
                    Console.WriteLine("Введите дату выполнения задачи: ");
                    string strDate = Console.ReadLine();
                    DateTime? date;

                    if (strDate.Length > 0) {
                        date = Convert.ToDateTime(strDate);
                    } else {
                        date = null;
                    }
                        

                    Tasks.Add(new Job()
                    {
                        Name = name,
                        Description = description,
                        Tag = tag,
                        Date = date
                    });

                    Console.WriteLine("Задача успешно добавлена" + delimeter);

                    break;

                case "showall": 
                    Tasks.ForEach(delegate (Job j) {
                        string result = @"Id - {0}
Name - {1}
Description - {2},
Tag - {3},
CreatedDate - {4},
Date - {5}
";
                        Console.WriteLine(result, j.Id, j.Name, j.Description, j.Tag, j.CreationDate, j.Date);
                    });
                    break;

                case "exit":
                    string json = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
                    File.WriteAllText(jsonFile, json);

                    stop = true;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда" + delimeter);
                    break;
            }

        }
    }
}