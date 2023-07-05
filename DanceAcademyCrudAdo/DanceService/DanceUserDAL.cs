using DanceAcademyCrudAdo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DanceAcademyCrudAdo.DanceService
{
    public class DanceUserDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DanceConnStr"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public List<DanceUserModel> GetDanceUsers()
        {
            cmd = new SqlCommand("sp_danceSelect", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            List<DanceUserModel> list = new List<DanceUserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new DanceUserModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    StuName = dr["StuName"].ToString(),
                    StuAge = Convert.ToInt32(dr["StuAge"]),
                    StuParentName = dr["StuParentName"].ToString(),
                    StuEmail = dr["StuEmail"].ToString(),
                    StuMobile = dr["StuMobile"].ToString()
                });
            }
            return list;
        }

        public bool InsertDanceUser(DanceUserModel danceUser)
        {
            try
            {
                cmd = new SqlCommand("sp_danceInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stuName", danceUser.StuName);
                cmd.Parameters.AddWithValue("@stuAge", danceUser.StuAge);
                cmd.Parameters.AddWithValue("@stuParentName", danceUser.StuParentName);
                cmd.Parameters.AddWithValue("@stuEmail", danceUser.StuEmail);
                cmd.Parameters.AddWithValue("@stuMobile", danceUser.StuMobile);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateDanceUser(DanceUserModel danceUser)
        {
            try
            {
                cmd = new SqlCommand("sp_danceUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stuName", danceUser.StuName);
                cmd.Parameters.AddWithValue("@stuAge", danceUser.StuAge);
                cmd.Parameters.AddWithValue("@stuParentName", danceUser.StuParentName);
                cmd.Parameters.AddWithValue("@stuEmail", danceUser.StuEmail);
                cmd.Parameters.AddWithValue("@stuMobile", danceUser.StuMobile);
                cmd.Parameters.AddWithValue("@stuId", danceUser.Id);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteDanceUser(int id)
        {
            try
            {
                cmd = new SqlCommand("sp_danceDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stuId", id);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateDanceUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}