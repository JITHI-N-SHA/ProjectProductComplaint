﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectProductComplaint.DAL
{
    public class ComplaintDAL
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();



        public ComplaintDAL()
        {
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }



        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        //public int complaintReg(BAL.ComplaintBAL obj)
        //{ 
        //    string s = "insert into tbl_complaint  values('" + obj.productid + "','" + obj.userid + "','" + obj.cmpmsg + "','Complaint Received','" + obj.cmpdate + "')"; 
        //    SqlCommand cmd = new SqlCommand(s, Getcon()); 
        //    return cmd.ExecuteNonQuery();  
        //}



        public DataTable Product_list()
        {
            string qry = "select  * from product";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public int complaintReg(BAL.ComplaintBAL obj)
        {
            string s = "insert into Complaint  values('" + obj.cmpmsg + "','" + obj.productid + "','" + obj.userid + "','Complaint Received','" + DateTime.Now.ToLongDateString().ToString() + "')";



            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public DataTable users_list()
        {
            string qry = "select  * from Registration";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable view_complaints(BAL.ComplaintBAL c)

        {

          //  string qry = "select * from complaint";

           string qry = "select  c.date,c.complaintid,c.userid, p.productid,p.productname,u.name, c.complaint, c.status from Product p  INNER JOIN Complaint c  ON p.productid = c.productid INNER JOIN Registration u ON c.userid = u.id";



           SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int Update_Status(BAL.ComplaintBAL obj)
        {
            string s = "update complaint  set status='" + obj.cmpsts + "' where complaintid='" + obj.complaintid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
    }
}