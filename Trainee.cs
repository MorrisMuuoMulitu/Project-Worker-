using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorker
{
    class Trainee:Worker
    {
        public static int SalaryPercent { get; set; }
        //constructor
        public Trainee(string name,string job):base(name,job)
        {
        }
        //methods
        public override int Salary()
        {
            return (int)(base.Salary()*(float)SalaryPercent/100);
        }
    }
}
