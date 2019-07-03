using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatatableToListConverter
{
    class Program
    {
        static void Main(string[] args)
        {
           var dt = CreateDatatable();

            

            List<Employee> employees = new List<Employee>();

            #region Foreach

            //foreach (DataRow dtRow in dt.Rows)
            //{
            //    employees.Add(new Employee
            //    {
            //        ID = Convert.ToInt32(dtRow["ID"]),
            //        Name = dtRow["Name"].ToString(),
            //        Surname = dtRow["Surname"].ToString(),
            //        Occupation = dtRow["Occupation"].ToString()
            //    });
            //}

            #endregion

            #region GenericMethod
            employees = ConvertToList<Employee>(dt);
            #endregion

            employees.ForEach(e => Console.WriteLine(e.ToString()));
            Console.ReadLine();
        }

        private static List<T> ConvertToList<T>(DataTable dt)
        {

            List<T> data = new List<T>();

            foreach (DataRow dtRow in dt.Rows)
            {
                T item = GetItem<T>(dtRow);
                data.Add(item);
            }


            return data;
        }

        private static T GetItem<T>(DataRow dtRow)
        {

            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn dtColumn in dtRow.Table.Columns)
            {
              
                foreach (PropertyInfo property in obj.GetType().GetProperties())
                {
                    if (property.Name == dtColumn.ColumnName)
                    {
                        if (dtRow[dtColumn.ColumnName] == DBNull.Value)
                            property.SetValue(obj, null);
                        else
                            property.SetValue(obj, dtRow[dtColumn.ColumnName]);
                        break;

                    }
                    else
                        continue;
                }
            }
            return obj;
        }


        
        private static DataTable CreateDatatable()
        {
            DataTable dt = new DataTable("Employees");
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Surname", typeof(String));
            dt.Columns.Add("Occupation", typeof(String));

            dt.Rows.Add(1, "John", "Happy", "Engineer");
            dt.Rows.Add(1, "Patrick", "Yeah", "Dentist");  
            dt.Rows.Add(1, "Joseph", "July", "Bank Officer");
            dt.Rows.Add(1, "Katrine", "What", null);

            return dt;
        }
    }

    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Occupation { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0}, Name: {1}, Surname: {2}, Occupation : {3}", ID, Name, Surname, Occupation);
        }
    }
}
