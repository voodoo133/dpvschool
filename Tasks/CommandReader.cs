using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class CommandReader
    {
        private string jsonFile = Environment.CurrentDirectory + "\\tasks.json";

        private string startMsg = @"Введите addjob для добавления задачи
Введите editjob для редактирования задачи
Введите showall для просмотра задач
Введите exit для выхода";
        private string delimeter = "\r\n-----------------------------------------------\r\n";

        private bool stop = false;

        public CommandReader ()
        {

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
                        
                    using (TasksContext db = new TasksContext()) {
                        db.Tasks.Add(new Job()
                        {
                            Name = name,
                            Description = description,
                            Tag = tag,
                            Date = date
                        });
       
                        db.SaveChanges();
                    }

                    Console.WriteLine("Задача успешно добавлена" + delimeter);

                    break;

                case "editjob": 
                    Console.WriteLine("Введите название задачи: ");
                    string taskName = Console.ReadLine();

                    using (TasksContext db = new TasksContext())
                    {
                        Job task = db.Tasks.FirstOrDefault(t => t.Name == taskName);

                        if (task == null) {
                            Console.WriteLine("Задача с таким именем не найдена" + delimeter);
                        } else {
                            Console.WriteLine("Введите новое название задачи: ");
                            string newName = Console.ReadLine();
                            if (newName.Length != 0) task.Name = newName;
                            
                            Console.WriteLine("Введите новое описание задачи: ");
                            string newDescription = Console.ReadLine();
                            if (newDescription.Length != 0) task.Description = newDescription;

                            Console.WriteLine("Введите новую метку для задачи: ");
                            string newTag = Console.ReadLine();
                            if (newTag.Length != 0) task.Tag = newTag;

                            Console.WriteLine("Введите новую дату выполнения задачи: ");
                            string newStrDate = Console.ReadLine();
                            DateTime? newDate;

                            if (newStrDate.Length > 0) {
                                newDate = Convert.ToDateTime(newStrDate);
                            } else {
                                newDate = null;
                            }

                            if (newDate != null)
                                task.Date = newDate;

                            db.SaveChanges();

                            Console.WriteLine("Задача успешно изменена" + delimeter);
                        }
                    }

                    break;

                case "showall": 
                    using (TasksContext db = new TasksContext()) {
                        List<Job> tasks = db.Tasks.ToList();

                        tasks.ForEach(delegate (Job j) {
                            string result = @"Id - {0}
Name - {1}
Description - {2},
Tag - {3},
CreatedDate - {4},
Date - {5}
";
                            Console.WriteLine(result, j.Id, j.Name, j.Description, j.Tag, j.CreationDate, j.Date);
                        });
                    }

                    break;

                case "exit":
                    stop = true;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда" + delimeter);
                    break;
            }

        }
    }
}