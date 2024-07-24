using APARTMENT_MANAGEMENT_SYSTEM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APARTMENT_MANAGEMENT_SYSTEM.DbInterface
{
    public class CGuest
    {
        public List<Guest> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from guest_tbl",Global.Connection());
            List<Guest> guestlist = new List<Guest>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Guest guest = new Guest();
                guest.id = Convert.ToInt32(dr["id"]);
                guest.name = Convert.ToString(dr["name"]);
                guest.namekh = Convert.ToString(dr["namekh"]);
                guest.sex = Convert.ToString(dr["sex"]);
                guest.dob = Convert.ToDateTime(dr["dob"]);
                guest.address = Convert.ToString(dr["address"]);
                guest.nationality = Convert.ToString(dr["nationality"]);
                guest.phone = Convert.ToString(dr["phone"]);
                guest.email = Convert.ToString(dr["email"]);
                guest.ssn = Convert.ToString(dr["ssn"]);
                guest.passport = Convert.ToString(dr["passport"]);
                guest.status = Convert.ToString(dr["status"]);  

            }
            dr.Close();
            Global.Connection().Close();
            return guestlist;
        }


        public Guest GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from guest_tbl" + id, Global.Connection());
            Guest guest = new Guest();
            SqlDataReader dr = cmd.ExecuteReader();
            
            try
            {
                if(dr.Read())
                {
                    guest.id = Convert.ToInt32(dr["id"]);
                    guest.name = Convert.ToString(dr["name"]);
                    guest.namekh = Convert.ToString(dr["namekh"]);
                    guest.sex = Convert.ToString(dr["sex"]);
                    guest.dob = Convert.ToDateTime(dr["dob"]);
                    guest.address = Convert.ToString(dr["address"]);
                    guest.nationality = Convert.ToString(dr["nationality"]);
                    guest.phone = Convert.ToString(dr["phone"]);
                    guest.email = Convert.ToString(dr["email"]);
                    guest.ssn = Convert.ToString(dr["ssn"]);
                    guest.passport = Convert.ToString(dr["passport"]);
                    guest.status = Convert.ToString(dr["status"]);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close ();
            Global.Connection().Close();    
            return guest;
        }


        public bool Insert(Guest guest)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Global.Connection();
                cmd.Parameters.AddWithValue("", guest.name);
                cmd.Parameters.AddWithValue("", guest.namekh);
                cmd.Parameters.AddWithValue("", guest.sex);
                cmd.Parameters.AddWithValue("", guest.dob);
                cmd.Parameters.AddWithValue("", guest.address);
                cmd.Parameters.AddWithValue("", guest.nationality);
                cmd.Parameters.AddWithValue("", guest.phone);
                cmd.Parameters.AddWithValue("", guest.email);
                cmd.Parameters.AddWithValue("", guest.ssn);
                cmd.Parameters.AddWithValue("", guest.passport);
                cmd.Parameters.AddWithValue("", guest.status);
                result = true;

            }
            catch(Exception ex)
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
                SqlCommand cmd = new SqlCommand("Delete From guest_tbl Where id = @id", Global.Connection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Global.Connection().Close() ;
            return result;
        }

        public bool Update(Guest guest)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new SqlCommand("Update guest_tbl Set name = @name, namekh = @namekh, sex = @sex, dob = @dob, address = @address, nationality = @nationality, phone = @phone, phone = @phone, email = @email, ssn = @ssn, passport = @passport, status = @status Where id = @id", Global.Connection());
                cmd.Parameters.AddWithValue("@id", guest.id);
                cmd.Parameters.AddWithValue("@name", guest.name);
                cmd.Parameters.AddWithValue("namekh", guest.namekh);
                cmd.Parameters.AddWithValue("sex", guest.sex);
                cmd.Parameters.AddWithValue("dob", guest.dob);
                cmd.Parameters.AddWithValue("address", guest.address);
                cmd.Parameters.AddWithValue("nationality", guest.nationality);
                cmd.Parameters.AddWithValue("phone", guest.phone);
                cmd.Parameters.AddWithValue("email", guest.email);
                cmd.Parameters.AddWithValue("ssn", guest.ssn);
                cmd.Parameters.AddWithValue("passport", guest.passport);
                cmd.Parameters.AddWithValue("status", guest.status);
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
