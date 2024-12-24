using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public class LessonList
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Start} - {End}";
        }
    }
}
