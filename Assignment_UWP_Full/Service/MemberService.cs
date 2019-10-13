using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_UWP_Full.Entity;

namespace Assignment_UWP_Full.Service
{
    interface MemberService
    {
        String Login(String email, String password);
        Member Register(Member member);
        Member GetInformation(string token);
    }
}
