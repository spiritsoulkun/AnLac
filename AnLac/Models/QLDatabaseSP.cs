using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnLac.Models
{
    public class QLDatabaseSP
    {
        public int productCode { set; get; }


        [Required(ErrorMessage = "Bạn cần nhập Tên sản phẩm")]
        [Display(Name = "Tên Sản Phẩm")]
        public string productName { set; get; }

        [Required(ErrorMessage = "Bạn cần mô tả sản phẩm")]
        [Display(Name = "Mô tả Sản Phẩm")]
        public string productDescription { set; get; }
       
        public int productQuantityInStock { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập giá sản phẩm")]
        [Display(Name = "giá Sản Phẩm")]
        public decimal productBuyPrice { set; get; }

        [Required(ErrorMessage = "Bạn cần ảnh sản phẩm")]
        [Display(Name = "ảnh Sản Phẩm")]
        public string productImage { set; get; }
        
        public DateTime productCreateOn { set; get; }


        

    }

    class ProductlistSP
    {
        private DatabaseService db;

        public ProductlistSP()
        {
            db = new DatabaseService();
        }

        public List<QLDatabaseSP> GetSanpham(string productCode)
        {
            string sql;
            if (string.IsNullOrEmpty(productCode))
            {
                sql = "select * from dbo.Products";
            }
            else
            {
                sql = "select * from dbo.Products where productCode =" + productCode;
            }
            List<QLDatabaseSP> strList = new List<QLDatabaseSP>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            //Open Connect
            con.Open();
            cmd.Fill(dt);
            //close connect
            cmd.Dispose();
            con.Close();

            QLDatabaseSP strSP;
            for(int i=0;i<dt.Rows.Count; i++)
            {
                strSP = new QLDatabaseSP();
                strSP.productCode = Convert.ToInt32(dt.Rows[i]["productCode"].ToString());
                strSP.productName = dt.Rows[i]["productName"].ToString();
                strSP.productDescription = dt.Rows[i]["productDescription"].ToString();
                strSP.productQuantityInStock = Convert.ToInt32(dt.Rows[i]["productQuantityInStock"].ToString());
                strSP.productBuyPrice = Convert.ToDecimal(dt.Rows[i]["productBuyPrice"].ToString());
                strSP.productImage = dt.Rows[i]["productImage"].ToString();             
                strList.Add(strSP);
            }
            return strList;
        }
        public void insertProduct(QLDatabaseSP strSP)
        {
            String sqlQuery;
            sqlQuery = "INSERT INTO dbo.Products(productName, productDescription, productQuantityInStock, productBuyPrice, productImage) VALUES (@productName, " +
                       "@productDescription, @productQuantityInStock, @productBuyPrice, @productImage)";
            SqlConnection sqlConnection = db.getConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            cmd.Parameters.AddWithValue("@productName", strSP.productName);
            cmd.Parameters.AddWithValue("@productDescription", strSP.productDescription);
            cmd.Parameters.AddWithValue("@productQuantityInStock", strSP.productQuantityInStock);
            cmd.Parameters.AddWithValue("@productBuyPrice", strSP.productBuyPrice);
            cmd.Parameters.AddWithValue("@productImage", strSP.productImage);


            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void updataProduct(QLDatabaseSP strSP)
        {
            String sqlQuery;
            sqlQuery = "UPDATE Products SET productName = @productName, productDescription = @productDescription, " +
                "productQuantityInStock = @productQuantityInStock, " +
                "productBuyPrice = @productBuyPrice, productImage = @productImage WHERE productCode = @productCode";
            SqlConnection sqlConnection = db.getConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            cmd.Parameters.AddWithValue("@productCode", strSP.productCode);
            cmd.Parameters.AddWithValue("@productName", strSP.productName);
            cmd.Parameters.AddWithValue("@productDescription", strSP.productDescription);
            cmd.Parameters.AddWithValue("@productQuantityInStock", strSP.productQuantityInStock);
            cmd.Parameters.AddWithValue("@productBuyPrice", strSP.productBuyPrice);
            cmd.Parameters.AddWithValue("@productImage", strSP.productImage);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void deleteProduct(QLDatabaseSP strSP)
        {
            String sqlQuery;
            sqlQuery = "DELETE FROM Products WHERE productCode = @productCode";
            SqlConnection sqlConnection = db.getConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.AddWithValue("@productCode", strSP.productCode);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

       


    }
    
}