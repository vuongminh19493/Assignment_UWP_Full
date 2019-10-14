using System;
using System.Collections.Generic;
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
    public sealed partial class LoginForm : Page
    {
        public LoginForm()
        {
            this.InitializeComponent();
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            ResetMessage();
            MemberLogin memberLogin = new MemberLogin
            {
                email = this.Email.Text,
                password = this.Password.Password
            };
            Dictionary<string, string> errors = Validate.ValidateLogin(memberLogin);
            if (errors.Count > 0)
            {
                if (errors.ContainsKey("Email"))
                {
                    EmailMessage.Text = errors["Email"];
                    EmailMessage.Visibility = Visibility.Visible;
                }

                if (errors.ContainsKey("Password"))
                {
                    PasswordMessage.Text = errors["Password"];
                    PasswordMessage.Visibility = Visibility.Visible;
                }
                return;
            }
            MemberServiceImp memberServiceImp = new MemberServiceImp();
            memberServiceImp.Login(Email.Text, Password.Password);
            var token = memberServiceImp.GetTokenFromApi(memberLogin);
            var member = memberServiceImp.GetInformation(token);
            ResetLoginForm();
            GoToInfo(null,null);

        }

        private void ResetMessage()
        {
            EmailMessage.Visibility = Visibility.Collapsed;
            PasswordMessage.Visibility = Visibility.Collapsed;
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            ResetLoginForm();
            ResetMessage();
        }
        private void ResetLoginForm()
        {
            this.Email.Text = string.Empty;
            this.Password.Password = string.Empty;
        }
        private void GoToInfo(object sender, RoutedEventArgs e)
        {
            Home home = FindParent<Home>(this);
            if (home != null)
            {
                home.TheContentFrame.Navigate(typeof(Information));
            }
        }

        public static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}

