using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models.Interfaces
{
    public interface ICoacheeOrMentee
    {
        string Brief { get; set; }
        string AdditionRef { get; set; }
        int LoginUserId { get; set; }
        string Skill { get; set; }
        string Role { get; set; }
        string Bookmarks { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        List<IProgramConducted> ProgramsConducted { get; set; }
        List<Interfaces.IFeedback> Feedbacks { get; set; }

    }
}
