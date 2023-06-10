using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    internal class AppVersion {
        public static float get_version() {
			try {
                return float.Parse(File.ReadAllText("version.txt"));
            } catch (Exception) {
                return 0;
			}
            
        }
    }
}
