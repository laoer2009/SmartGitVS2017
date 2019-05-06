using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMvc
{
    public class StudentClass
    {
        public string Name{ get; set; }
        public string Age { get; set; }
        public List<Students> Students { get; set; }
    }

    public class Students
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }

}
