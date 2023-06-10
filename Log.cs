using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    public class Log {

        const string log_file_name = "LOG.txt";

        public static void print(string str) {
            File.AppendAllText(log_file_name, DateTime.Now.ToString() + ":\t\t" + str + "\n");
        }
    }
}
