using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Assignment_UWP_Full.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment_UWP_Full.Service
{
    class MemberServiceImp : MemberService
    {
       
        
        public string Login(string username, string password)
        {
            
            try
            {
                var memberLogin = new MemberLogin()
                {
                    email = username,
                    password = password
                };
                if (!ValidaTeMemberLogin(memberLogin))
                {
                    throw new Exception("login fails!");
                }
                //lấy token từ api
                var token = GetTokenFromApi(memberLogin);
                CreateReadFile createReadFile = new CreateReadFile();
                createReadFile.SaveTokenToLocalStorage(token);
                return token;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        
        

        public string GetTokenFromApi(MemberLogin memberLogin)
        {
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin), Encoding.UTF8,
                "application/json");
            var client = new HttpClient();
            var responseContent = client.PostAsync(ApiUrl.LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync()
                .Result;
            var jsonObject = JObject.Parse(responseContent);
            Debug.WriteLine(jsonObject);
            if (jsonObject["token"] == null)
            {
                throw new Exception("Login fails!");
            }

            return jsonObject["token"].ToString();
        }

        private bool ValidaTeMemberLogin(MemberLogin memberLogin)
        {
            return true;
        }

        public Member Register(Member member)
        {
            try
            {
                var httpClient = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,
                    "application/json");
                var httpResquestMessenge = httpClient.PostAsync(ApiUrl.REGISTER_URL, content);
                var responseContent = httpResquestMessenge.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(responseContent);
                var resMember = JsonConvert.DeserializeObject<Member>(responseContent);
                return resMember;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public Member GetInformation(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var httpResquestMessenge = httpClient.GetAsync(ApiUrl.GET_INFORMATION_URL);
            var responseContent = httpResquestMessenge.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(responseContent);
            if (responseContent.Contains("id"))
            {
                Member member = JsonConvert.DeserializeObject<Member>(responseContent);
                return member;
            }

            return null;
        }

        
    }
}
