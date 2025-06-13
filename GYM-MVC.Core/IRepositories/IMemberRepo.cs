using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.Domain.Entities;

namespace GYM_MVC.Core.IRepositories
{
    public interface IMemberRepo : IBaseRepo<Member>
    {
        List<Member> GetMembersByTrainerId(int trainerId);
    }
}
