using hadeel_0523077_w4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hadeel_0523077_w4
{
    
    public partial class sinup : Page
    {
       
        menagerEntities db = new menagerEntities();
        public sinup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                if (___nametxt.Text ==""|| ___emailtxt.Text == ""|| passtxt.Text == ""|| conftxt.Text== "" || roletxt.Text =="")
                {
                    MessageBox.Show("please enter all data");
                    return;



                }

                if (passtxt.Text!=conftxt.Text)
                {
                    MessageBox.Show("Password not match");
                    return;
                }

                if (!(Regex.IsMatch(passtxt.Text, "[8]")))
                {
                    MessageBox.Show("not corect pass");
                    return;
                }
                
               
                if (!(roletxt.Text=="manager"|| roletxt.Text=="user"))
                {
                    MessageBox.Show(" role rong");
                }
                user user = new user();
                if (___emailtxt.Text== user.UEmail)
                {
                    MessageBox.Show("email un corrct");
                }

             if (!(Regex.IsMatch(___nametxt.Text, "[\\d]")))
             {
                    MessageBox.Show("rong");
             }
            else
            {
                user us = new user();
                us.UName= ___nametxt.Text;
                us.UEmail= ___emailtxt.Text;
                us.Upass=passtxt.Text;
                us.Urole=roletxt.Text;

                us= db.users.Add(us);
                db.SaveChanges();
                login loginn = new login();
                this.NavigationService.Navigate(loginn);
                MessageBox.Show("DONE");
                return;
            }
            
        }

    }
}




    
