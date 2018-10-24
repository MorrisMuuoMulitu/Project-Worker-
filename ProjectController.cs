using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorker
{
    class ProjectController
    {
        private List<Worker> Workers = new List<Worker>();
        internal void Start()
        {
            InitiateStaticValues();
            Hiring();
            WriteOutput("The Hired Workers");
            Console.WriteLine("\nThe hiring process is finished, lets start work\n");
            WorkerWorks();
            PaidSalary();
            TotalSalary();
        }

        private void InitiateStaticValues()
        {
            Worker.HourlyRate = 1000;
            Trainee.SalaryPercent = 65;
        }

        private void Hiring()
        {
            StreamReader reader = new StreamReader("emplyees.txt");
            string name, job, type;
            Worker workerObject;

            type = reader.ReadLine();
            while (type != null)
            {
                name = reader.ReadLine();
                job = reader.ReadLine();
                if (type.Equals("worker"))
                {
                    workerObject = new Worker(name, job);
                }
                else
                {
                    workerObject = new Trainee(name, job);
                }
                Workers.Add(workerObject);
                type = reader.ReadLine();

            }
            reader.Close();
        }

        private void WriteOutput(string title)
        {
           Console.WriteLine(title) ;
            foreach (Worker worker in Workers)
            {
                Console.WriteLine(worker);
            }
        }

        private void WorkerWorks()
        {
           int maxHour=180 ;
            Random rand = new Random();
                int hour;
            Console.WriteLine("Number of hours worked by employees:");
            foreach (Worker worker in Workers)
            {
                hour = rand.Next(maxHour);
                worker.Work(hour);
                Console.WriteLine(worker.Name + "worked" + worker.NumberOfHoursWorked + "hours+");
            }
        }

        private void PaidSalary()
        {
            Console.WriteLine("\n The salary of workers: \n");
            foreach (Worker worker in Workers)
            {
                Console.WriteLine(worker.Name + "salary is " + worker.Salary() + "Ft.");
            }
        }

        private void TotalSalary()
        {
            int total = 0;
            foreach (Worker worker in Workers)
            {
                total += worker.Salary();

            }
            Console.WriteLine("\n The all salary paid to the employees:" + total + "Ft.");
            }
    }
}