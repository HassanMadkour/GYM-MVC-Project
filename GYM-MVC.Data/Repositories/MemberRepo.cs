using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Data.Data;

namespace GYM_MVC.Data.Repositories
{
    public class MemberRepo : BaseRepo<Member>, IMemberRepo
    {
        public MemberRepo(GYMContext context) : base(context)
        {
        }

    }
}
