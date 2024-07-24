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
    public class CBuilding
    {
        public object CommandType { get; private set; }

        public List<Building> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from building_tbl", Global.Connection());
            List<Building> buildingList = new List<Building>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Building building = new Building();
                building.id = Convert.ToInt32(dr["id"]);
                building.buildingname = dr["buildingname"].ToString();
                building.buildingnamekh = dr["buildingnamekh"].ToString() ; 
            }
            dr.Close();
            Global.Connection().Close();
            return buildingList;
        }

        public Building GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from building_tbl" + id, Global.Connection());
            Building building = new Building();
            SqlDataReader dr = cmd.ExecuteReader(); 
            try
            {
                if (dr.Read())
                {
                    building.id = Convert.ToInt32(dr["id"]);
                    building.buildingname = dr["buildingname"].ToString();
                    building.buildingnamekh = dr["buildingnamekh"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            Global.Connection().Close() ;
            return building;

        }
        
        public bool Insert(Building building)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                cmd.Connection = Global.Connection();
                cmd.Parameters.AddWithValue("", building.buildingname);
                cmd.Parameters.AddWithValue("", building.buildingnamekh);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM building_tbl WHERE id = @id", Global.Connection());
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

        public bool Update(Building building)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE building_tbl SET buildingname = @buildingname, buildingnamekh = @buildingnamekh WHERE id = @id", Global.Connection());
                cmd.Parameters.AddWithValue("@id",building.id);
                cmd.Parameters.AddWithValue("@buildingname",building.buildingname);
                cmd.Parameters.AddWithValue("@buildingnamekh",building.buildingnamekh);              
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



    }
}
