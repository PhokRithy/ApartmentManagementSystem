using APARTMENT_MANAGEMENT_SYSTEM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APARTMENT_MANAGEMENT_SYSTEM.DbInterface
{
    public class CRoom
    {
        public List<Room> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from room_tbl", Global.Connection());
            List<Room> roomList = new List<Room>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               Room room = new Room();
                room.id = Convert.ToInt32(dr["id"]);
                room.room_no = dr["room_no"].ToString();
                room.roomtypeid = Convert.ToInt32(dr["roomtypeid"]);
                room.servicecharge = Convert.ToDecimal(dr["servicecharge"]);
                room.floorid = Convert.ToInt32(dr["floorid"]);
                room.roomkey = dr["roomkey"].ToString();
                room.price = Convert.ToDecimal(dr["price"]);
                room.status = dr["status"].ToString();
                room.note = dr["note"].ToString();
            }
            dr.Close();
            Global.Connection().Close();  
            return roomList;
        }


        public Room GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from room_tbl" + id, Global.Connection());
            Room room = new Room();
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read())
                {
                    room.id = Convert.ToInt32(dr["id"]);
                    room.room_no = dr["room_no"].ToString();
                    room.roomtypeid = Convert.ToInt32(dr["roomtypeid"]);
                    room.servicecharge = Convert.ToDecimal(dr["servicecharge"]);
                    room.floorid = Convert.ToInt32(dr["floorid"]);
                    room.roomkey = dr["roomkey"].ToString();
                    room.price = Convert.ToDecimal(dr["price"]);
                    room.status = dr["status"].ToString();
                    room.note = dr["note"].ToString();
                   
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            Global.Connection().Close() ;
            return room;
        }
           
        public bool Insert(Room room)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Global.Connection();
                cmd.Parameters.AddWithValue("", room.room_no);
                cmd.Parameters.AddWithValue("", room.roomtypeid);
                cmd.Parameters.AddWithValue("", room.servicecharge);
                cmd.Parameters.AddWithValue("", room.floorid);
                cmd.Parameters.AddWithValue("", room.roomkey);
                cmd.Parameters.AddWithValue("", room.price);
                cmd.Parameters.AddWithValue("", room.status);
                cmd.Parameters.AddWithValue("", room.note);
                result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            Global.Connection().Close();    
            return result;
            
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM room_tbl WHERE id = @id", Global.Connection());
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


        public bool Update(Room room)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE room_tbl SET room_no = @room_no, " +
                                                "roomtypeid = @roomtypeid, servicecharge = @servicecharge," +
                                                " floorid = @floorid, " +
                                                "roomkey = @roomkey, price = @price, status = @status," +
                                                " note = @note WHERE id = @id", Global.Connection());
                cmd.Parameters.AddWithValue("@id", room.id);
                cmd.Parameters.AddWithValue("@room_no", room.room_no);
                cmd.Parameters.AddWithValue("@roomtypeid", room.roomtypeid);
                cmd.Parameters.AddWithValue("@servicecharge", room.servicecharge);
                cmd.Parameters.AddWithValue("@floorid", room.floorid);
                cmd.Parameters.AddWithValue("@roomkey", room.roomkey);
                cmd.Parameters.AddWithValue("@price", room.price);
                cmd.Parameters.AddWithValue("@status", room.status);
                cmd.Parameters.AddWithValue("@note", room.note);
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
