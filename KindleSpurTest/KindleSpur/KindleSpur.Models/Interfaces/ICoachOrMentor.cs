using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models.Interfaces
{
   public interface ICoachOrMentor
    {
         string AdditionalRef { get; set; }
         int LoginUserId { get; set; }
         string Skill { get; set; }
         decimal Experience { get; set; }
         string Proficiency { get; set; } 
         string Language { get; set; }
         Boolean Published { get; set; }
         string Role { get; set; }
         string Bookmarks { get; set; }
         DateTime CreateDate { get; set; }
         DateTime UpdateDate { get; set; }
         List<IProgramConducted> ProgramsConducted { get; set; }
         List<IFeedback> Feedbacks { get; set; }

    }

    public interface IProgramConducted
    {
        string Skill { get; set; }
        int Count { get; set; }
    }
}
