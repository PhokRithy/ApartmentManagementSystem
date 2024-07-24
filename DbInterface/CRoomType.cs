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
    public class CRoomType
    {
        //CRUD
        public RoomType GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from roomtype_tbl where id="+id, Global.Connection());
            RoomType roomType = new RoomType();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    roomType.id = Convert.ToInt32(dr["id"]);
                    roomType.name = dr["roomTypename "].ToString();
                    roomType.namekh = dr["roomtypenamekh"].ToString();
                    roomType.note = dr["note"].ToString();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            Global.Connection().Close();
            return roomType;
        }

        public List<RoomType> GetAll() 
        {
            SqlCommand cmd = new SqlCommand("select * from roomtype_tbl", Global.Connection());
            List<RoomType> roomTypeList  = new List<RoomType>();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) 
            {
                RoomType roomType = new RoomType();
                roomType.id = Convert.ToInt32(dr["id"]);
                roomType.name = dr["roomTypename "].ToString();
                roomType.namekh = dr["roomtypenamekh"].ToString();
                roomType.note = dr["note"].ToString();      
            }
            dr.Close();
            Global.Connection() .Close();
             return roomTypeList;  
        }


        public bool Insert(RoomType roomType)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Global.Connection();
                cmd.Parameters.AddWithValue("", roomType.name);
                cmd.Parameters.AddWithValue("",roomType.namekh);
                cmd.Parameters.AddWithValue("", roomType.note);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Global.Connection() .Close();
            return result;
        }




    }


}
