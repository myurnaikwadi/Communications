using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models.Interfaces.Management
{
    public interface ICoacheeOrMenteeManagement
    {
        bool AddNewCoacheeOrMentee(ICoacheeOrMentee Data);

        bool EditCoacheeOrMentee(int id, ICoacheeOrMentee Data);

        bool DeleteCoacheeOrMentee(int Id);

        List<ICoacheeOrMentee> GetAllCoacheeOrMenteeDetails();

        ICoacheeOrMentee GetCoacheeOrMenteeDetail(int Id);
    }
}
