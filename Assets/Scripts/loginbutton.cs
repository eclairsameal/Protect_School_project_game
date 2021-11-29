using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data.Common;
using System;
public class loginbutton : MonoBehaviour {

    public InputField Field1;
    public InputField Field2;
    public Text t;

    string username = "new";
    string password;
    
    public void take_password(string input)
    {
        string pasw = "" ;

        string Constr = "Server= 140.126.11.186; Database= game_account;User ID=yuma;Password=yuma123; Integrated Security=false;";
    
        string Sqlstr = @"SELECT pw  FROM Account WHERE ac = '" + input + "';";
        // step 3 . 建立SqlConnection

        string newID;
        // step 4 . 宣告查詢字串
        using (SqlConnection conn = new SqlConnection(Constr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sqlstr,conn);
            try
            {
              
                pasw = (string)cmd.ExecuteScalar();
                

                password = password.Replace("\n", String.Empty);
                pasw = pasw.Replace("\n", String.Empty);
                pasw = pasw.Replace("\r", String.Empty);
                pasw = pasw.Replace(" ", String.Empty);

                if (pasw == "")
                {
                    t.text = "帳號密碼錯誤";
                    print("帳號密碼錯誤");
                }
                else if(pasw == password)
                {
                    t.text = "密碼正確";
                    print("password correct\n");
                }
                else
                {
                    t.text = "密碼錯誤";
                    print("password incorrect\n");
                }
            }
            catch
            {
                t.text = "帳號密碼錯誤";
                print("帳號密碼錯誤");
                //Console.WriteLine(ex.Message);Exception ex
            }
        }




        try
        {
            SqlConnection conn = new SqlConnection(Constr);
            SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            // step 6. 建立DataSet來儲存Table
            DataTable ds = new DataTable();


        }
        catch
        {

        }
        

        // step 5. 建立SqlDataAdapter

     
    }
    public void StoreUser(string _username)
    {
        username = _username;
    }

    public void StorePassword(string _password)
    {
        password = _password;
    }
    public void EnterPlayerName()
    {////(2)
        StoreUser(Field1.text);
        StorePassword(Field2.text);
       take_password(Field1.text);
    
    }
}
