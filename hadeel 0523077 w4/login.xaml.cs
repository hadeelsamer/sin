using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        menagerEntities db=new menagerEntities();
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (passtxt.Text==""|| emailtxt.Text=="")
            {
                MessageBox.Show("please enter data");
                return;
            }

            if (passtxt.Text=="1"|| emailtxt.Text=="1")
            {
                MessageBox.Show("welcome manager");
                manager manager = new manager();
                NavigationService.Navigate(manager);

            }
            var stu= db.users.Where(x=> x.UEmail==emailtxt.Text&& x.Upass==passtxt.Text).FirstOrDefault();
            if (stu!=null)
            {

                MessageBox.Show("sucssfull");
              viewTask viewTask = new viewTask();
                NavigationService.Navigate(viewTask);

            }

        }
    }
}
       