using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindleSpur.Models.Interfaces;


namespace KindleSpur.Models
{
    public class ProgramConducted: IProgramConducted
    {
       public string Skill { get; set; }
       public int Count { get; set; }
    }
}
