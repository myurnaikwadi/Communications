using KindleSpur.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models
{
    public class CoacheeOrMentee : ICoacheeOrMentee
    {
       public string Brief { get; set; }
       public string AdditionRef { get; set; }
       public int LoginUserId { get; set; }
       public string Skill { get; set; }
       public string Role { get; set; }
       public string Bookmarks { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime UpdateDate { get; set; }
       public List<IProgramConducted> ProgramsConducted { get; set; }
       public List<Interfaces.IFeedback> Feedbacks { get; set; }
    }
}
