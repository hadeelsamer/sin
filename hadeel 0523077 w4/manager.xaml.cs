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
using System.Data.Entity;
namespace hadeel_0523077_w4
{
    /// <summary>
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Page
    {
        menagerEntities db=new menagerEntities();
        public manager()
        {
            InitializeComponent();
            var emmp = db.users.Select(x => new { x.UEmail, x.taskID, x.task.title, x.task.Statuss, x.task.Descriptions }).ToList();
            data.ItemsSource = emmp;
            refrech();


        }
        public void refrech()
        {
            var emmp = db.users.Select(x => new { x.UEmail ,x.taskID , x.task.title, x.task.Statuss,x.task.Descriptions}).ToList();
            data.ItemsSource = emmp;
        }

       
        private void delete(object sender, RoutedEventArgs e)
        {
            if (idtxt.Text == "")
            {
                MessageBox.Show(" enter id");
                return;
            }
            int id = int.Parse(idtxt.Text);
            var user = db.users.Where(x => x.UsID == id).FirstOrDefault();
            if (user!= null)
            {
                db.users.Remove(user);
                db.SaveChanges();
                MessageBox.Show("delete sucssuel");
                
            }
            refrech();

        }

        private void add( object sender, RoutedEventArgs e)
        {
            if (idtxt.Text==""|| titltxt.Text==""||deptxt.Text==""||emailtxt.Text=="")
            {
                MessageBox.Show("please enter all data");
                return;
            }
            var use = db.users.Where(x => x.UEmail==emailtxt.Text).FirstOrDefault();      

            if (use == null)
            {
              
                task t =new task();
                use.task.Descriptions= deptxt.Text;
                 db.users.Add(use);
                 db.SaveChanges();
                MessageBox.Show("DATA SAVED");
                login login = new login();
                NavigationService.Navigate(login);

                return;

            }
            else
            {
                MessageBox.Show("error");
            }
            refrech() ;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (idtxt.Text == "" )
            {
                MessageBox.Show("Fileds Are reqiured");
                return;
            }

            int id = int.Parse(idtxt.Text);
            var stu = db.users.Where(x => x.UsID == id).FirstOrDefault();
            if (stu != null)
            {
                if (stu.task.title == "" || stu.task.title == null)
                {
                    task t = new task();
                    t.title = titltxt.Text;
                    stu.task = t;
                    t.Descriptions = deptxt.Text;
                    stu.task=t;

                    return;

                }
                else
                {
                    stu.task.title = titltxt.Text;
                }
                db.SaveChanges();
                MessageBox.Show("Updated Successfully");
            }
            refrech();
        }
       

        private void ComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string j = combo.SelectedItem.ToString();
            if (!(j == null))
            {
                var stuu = db.users.Where(s => s.task.title == j).Select(stu => new { stu.UsID, stu.UName, stu.task.Statuss, stu.task.Descriptions}).ToList();
                data.ItemsSource = stuu;

            }
        }
    }
}


