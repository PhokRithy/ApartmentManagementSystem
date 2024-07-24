using APARTMENT_MANAGEMENT_SYSTEM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APARTMENT_MANAGEMENT_SYSTEM.DbInterface
{
    public class CFloor
    {
        public List<Floor> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from floor_tbl", Global.Connection());
            List<Floor> floorList = new List<Floor>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Floor floor = new Floor();
                floor.id = Convert.ToInt32(dr["id"]);
                floor.buildingid = Convert.ToInt32(dr["buildingid"]);
                floor.floor_no = dr["floor_no"].ToString();
                floor.status = dr["status"].ToString(); 
            }
            dr.Close();
            Global.Connection().Close();
            return floorList;
        }
      
        public Floor GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from floor_tbl" + id, Global.Connection());
            Floor floor = new Floor();
            SqlDataReader dr = cmd.ExecuteReader(); 
            try
            {
                if (dr.Read())
                {
                    floor.id = Convert.ToInt32(dr["id"]);
                    floor.buildingid = Convert.ToInt32(dr["buildingid"]);
                    floor.floor_no = dr["floor_no"].ToString();
                    floor.status = dr["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close ();
            Global.Connection().Close();
            return floor;
        }

        public bool Insert(Floor floor)
        {
            bool result = false;
            try
            {
               SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Global.Connection();
                cmd.Parameters.AddWithValue("", floor.buildingid);
                cmd.Parameters.AddWithValue("", floor.floor_no);
                cmd.Parameters.AddWithValue("", floor.status);
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Global.Connection().Close();
            return result;

        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new SqlCommand("Delete from floor_tbl where id = @id", Global.Connection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                result = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Global.Connection().Close();
            return result;
        }

        public bool Update(Floor floor)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update floor_tbl Set buildingid = @buildingid, floor_no = @floor_no, status = @status where id =@id", Global.Connection());
                cmd.Parameters.AddWithValue("@id", floor.id);
                cmd.Parameters.AddWithValue("@buildingid", floor.buildingid);
                cmd.Parameters.AddWithValue("@floor_no", floor.floor_no);
                cmd.Parameters.AddWithValue("@status", floor.status);
                result=true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Global.Connection().Close();
            return result;
        }








    }
}
