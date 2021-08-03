using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnLac.Models
{
    public class QLDatabaseKH
    {
        public int customerCode { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập Tên Khách Hàng")]
        [Display(Name = "Tên Khách Hàng")]
        public string customerName { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập Email")]
        [Display(Name = "Email Khách Hàng")]
        public string customerEmail { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập Mật khẩu Khách Hàng")]
        [Display(Name = "Mật khẩu Khách hàng")]
        public string customerPassword { set; get; }
  
        public string customerPhone { set; get; }
        public string customerAddress { set; get; }
        public DateTime customerDateCreateOn { set; get; }
        

    }

    class CustomerAction
    {
        private DatabaseService db;

        public CustomerAction()
        {
            db = new DatabaseService();
        }
        public void AddCustomer(QLDatabaseKH n)
        {
            String sqlQuery;
            sqlQuery = "INSERT INTO Customers (customerName, customerEmail, customerPassword, customerPhone)" +
                       "VALUES (@customerName, @customerEmail, @customerPassword, @customerPhone)";
            SqlConnection sqlConnection = db.getConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            cmd.Parameters.AddWithValue("@customerName", n.customerName);
            cmd.Parameters.AddWithValue("@customerEmail", n.customerEmail);
            cmd.Parameters.AddWithValue("@customerPassword", n.customerPassword);
            cmd.Parameters.AddWithValue("@customerPhone", n.customerPhone);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}