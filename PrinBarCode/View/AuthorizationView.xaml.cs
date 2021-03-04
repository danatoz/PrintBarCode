using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PrinBarCode.DAL;
using PrinBarCode.DAL.DataModel;
using PrinBarCode.Model;
using PrinBarCode.ViewModel;

namespace PrinBarCode.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        private List<Employee> employeeList = new List<Employee>();
        public AuthorizationView()
        {
            InitializeComponent();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            try
            {
                throw new Exception("1");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cath clause caught");
            }

            try
            {
                using (BarCodeContext db = new BarCodeContext())
                {
                    var employees = db.Employees.Select(p => new
                    {
                        Name = p.Name,
                        Surname = p.Surname,
                        Role = p.Role,
                        Password = p.Password
                    });
                    foreach (var e in employees)
                    {
                        employeeList.Add(new Employee() { Name = e.Name, Surname = e.Surname, Password = e.Password, Role = e.Role });
                    }

                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        cbLogin.Items.Add($"{employeeList[i].Name} {employeeList[i].Surname}");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            StreamWriter er = new StreamWriter("errors.txt");
            er.WriteLine("MyHandler caught: " + e.Message);
            er.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            er.Close();
        }

        private void PbPassword_OnKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.IsDown == (e.Key == Key.Enter))
                {
                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        string s = cbLogin.SelectedItem.ToString();
                        if (s == ($"{employeeList[i].Name} {employeeList[i].Surname}"))
                        {
                            if (pbPassword.Password == employeeList[i].Password)
                            {
                                int role = employeeList[i].Role.Id;
                                MainWindow mw = new MainWindow(role);
                                mw.Show();
                                this.Owner = mw;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void CbLogin_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
