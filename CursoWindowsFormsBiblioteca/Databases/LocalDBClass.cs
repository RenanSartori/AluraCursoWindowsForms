﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class LocalDBClass
    {

        public string stringConn { get; set; }
        public SqlConnection connDB { get; set; }

        public LocalDBClass()
        {
            try
            {
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\re_sa\\Documents\\Visual Studio Projects\\AluraCursoWindowsForms\\CursoWindowsForms\\CursoWindowsFormsBiblioteca\\Databases\\Fichario.mdf\";Integrated Security=True";
                connDB = new SqlConnection(stringConn);

                connDB.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SQLQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, this.connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }


        public string SQLCommand(string sql)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, this.connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();

                return "";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close()
        {
            connDB.Close();
        }



    }
}
