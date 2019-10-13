using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Assignment_UWP_Full.Entity;
using Assignment_UWP_Full.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP_Full.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Information : Page
    {
        int gender;
        private MemberService memberService;
        public Information()
        {
            this.InitializeComponent();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && gender != null)
            {
                gender = int.Parse(radioButton.Tag.ToString());
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                CreateReadFile createReadFile = new CreateReadFile();
                var token = createReadFile.GetToken();
                MemberServiceImp memberServiceImp = new MemberServiceImp();
                var member = memberServiceImp.GetInformation(token);
                this.FirstName.Text = member.firstName;
                this.LastName.Text = member.lastName;
                this.Phone.Text = member.phone;
                this.Address.Text = member.address;
                this.Introduction.Text = member.introduction;
                this.Email.Text = member.email;
                if (member.gender == 0)
                {
                    Male.IsChecked = true;
                }
                else
                {
                    Female.IsChecked = true;
                }

                var datetime = member.birthday.Split("T");
                this.Birthday.Date = DateTime.ParseExact(datetime[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                try
                {
                    this.Avatar.ImageSource = new BitmapImage(new Uri(member.avatar));
                }
                catch (Exception exception)
                {

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Chưa đăng nhập");
                
            }
            
            
        }

    }
}
