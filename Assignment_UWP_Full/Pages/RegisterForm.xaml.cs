using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Midi;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Assignment_UWP_Full.Entity;
using Assignment_UWP_Full.Service;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP_Full.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterForm : Page
    {
        int gender;
        private MemberService memberService;
        public RegisterForm()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceImp();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           RadioButton radioButton = sender as RadioButton;
           if (radioButton != null)
           {
               gender = int.Parse(radioButton.Tag.ToString());
           }
        }

        private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResetMessage();
            if (this.Password.Password != this.ConfirmPassword.Password)
            {
                ConfirmPasswordMessage.Text = "Password is not matched!";
                return;
            }
            else
            {
                ConfirmPasswordMessage.Text = string.Empty;
            }


            var member = new Member
            {
                firstName = this.FirstName.Text,
                lastName = this.LastName.Text,
                phone = this.Phone.Text,
                address = this.Address.Text,
                introduction = this.Introduction.Text,
                email = this.Email.Text,
                gender = this.gender,
                birthday = this.Birthday.Date.ToString("yyyy-MM-dd"),
                avatar = this.AvatarUrl.Text,
                password = this.Password.Password
            };
            
                //validate phía client
                Dictionary<string, string> errors = Validate.ValidateMember(member);
                if (errors.Count > 0)
                {
                    if (errors.ContainsKey("FirstName"))
                    {
                        FirstNameMessage.Text = errors["FirstName"];
                        FirstNameMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("LastName"))
                    {
                        LastNameMessage.Text = errors["LastName"];
                        LastNameMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Phone"))
                    {
                        PhoneMessage.Text = errors["Phone"];
                        PhoneMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Gender"))
                    {
                        GenderMessage.Text = errors["Gender"];
                        GenderMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Birthday"))
                    {
                        BirthdayMessage.Text = errors["Birthday"];
                        BirthdayMessage.Visibility = Visibility.Visible;
                    }
                    if (errors.ContainsKey("Email"))
                    {
                        EmailMessage.Text = errors["Email"];
                        EmailMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Introduction"))
                    {
                        IntroductionMessage.Text = errors["Introduction"];
                        IntroductionMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Address"))
                    {
                        AddressMessage.Text = errors["Address"];
                        AddressMessage.Visibility = Visibility.Visible;
                    }
                    if (errors.ContainsKey("Password"))
                    {
                        PasswordMessage.Text = errors["Password"];
                        PasswordMessage.Visibility = Visibility.Visible;
                    }

                    if (errors.ContainsKey("Avatar"))
                    {
                        AvatarMessage.Text = errors["Avatar"];
                        AvatarMessage.Visibility = Visibility.Visible;
                    }

                    return;
                }
                Debug.WriteLine(JsonConvert.SerializeObject(member));
                MemberServiceImp memberServiceImp = new MemberServiceImp();
                member = memberServiceImp.Register(member);
                Debug.WriteLine(Birthday);

        }

        private void ResetMessage()
        {
            FirstNameMessage.Visibility = Visibility.Collapsed;
            LastNameMessage.Visibility = Visibility.Collapsed;
            PhoneMessage.Visibility = Visibility.Collapsed;
            AddressMessage.Visibility = Visibility.Collapsed;
            BirthdayMessage.Visibility = Visibility.Collapsed;
            IntroductionMessage.Visibility = Visibility.Collapsed;
            GenderMessage.Visibility = Visibility.Collapsed;
            EmailMessage.Visibility = Visibility.Collapsed;
            PasswordMessage.Visibility = Visibility.Collapsed;
            AvatarMessage.Visibility = Visibility.Collapsed;
        }
    }
}
