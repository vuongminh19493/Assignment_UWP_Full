using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assignment_UWP_Full.Entity;
using Microsoft.Toolkit.Extensions;

namespace Assignment_UWP_Full.Service
{
    
    class Validate
    {
        public static Dictionary<string, string> errors = new Dictionary<string, string>();

        public static Dictionary<string, string> ValidateMember(Member member)
        {
            errors.Clear();
            if (string.IsNullOrEmpty(member.firstName))
            {
                errors.Add("FirstName", "FirstName is required!");
            }
            if (string.IsNullOrEmpty(member.lastName))
            {
                errors.Add("LastName", "LastName is required!");
            }
            if (string.IsNullOrEmpty(member.avatar))
            {
                errors.Add("Avatar", "Avatar is required!");
            }
            if (!member.phone.IsPhoneNumber())
            {
                errors.Add("Phone", "Please enter the number!");
            }
            else if (string.IsNullOrEmpty(member.phone))
            {
                errors.Add("Phone", "Phone is required!");
            }
            if (string.IsNullOrEmpty(member.address))
            {
                errors.Add("Address", "Address is required!");
            }
            if (string.IsNullOrEmpty(member.introduction))
            {
                errors.Add("Introduction", "Introduction is required!");
            }

            if (member.birthday == "01-01-01")
            {
                errors.Add("Birthday", "Birthday is required!");
            }
            if (member.gender != 0 && member.gender != 1)
            {
                errors.Add("Gender", "Gender is required!");
            }
            if (!member.email.IsEmail())
            {
                errors.Add("Email", "Please enter a vaild email address!");
            }
            if (string.IsNullOrEmpty(member.password))
            {
                errors.Add("Password", "Password is required!");
            }
            else if (member.password.Length < 8)
            {
                errors.Add("Password", "Password must be more than 8 characters!");
            }
            

            return errors;
        }

        
        public static Dictionary<string, string> ValidateLogin(MemberLogin memberLogin)
        {
            errors.Clear();
            if (string.IsNullOrEmpty(memberLogin.email) || !Regex.IsMatch(memberLogin.email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                errors.Add("Email", "Email is required!");
            }

            if (string.IsNullOrEmpty(memberLogin.password))
            {
               errors.Add("Password", "Password is required!");
            }

            return errors;
        }
        public static Dictionary<string, string> ValidateSong(Song song)
        {

            
            errors.Clear();
            if (string.IsNullOrEmpty(song.name))
            {
                errors.Add("Name", "Name is required!");
            }else if (song.name.Length > 50)
            {
                errors.Add("Name","Max 50 characters!");
            }

            if (string.IsNullOrEmpty(song.thumbnail))
            {
                errors.Add("Thumbnail", "Image is required!");
            }
            if (string.IsNullOrEmpty(song.author))
            {
                errors.Add("Author", "Author is required!");
            }
            if (string.IsNullOrEmpty(song.description))
            {
                errors.Add("Description", "Description is required!");
            }

            if (string.IsNullOrEmpty(song.singer))
            {
                errors.Add("Singer", "Singer is required!");
            }
            if (string.IsNullOrEmpty(song.link))
            {
                errors.Add("Link", "Link is required!");
            }

            return errors;
        }
    }
}
