
        /*
        input : direct user input in string
no filtering
sink : SQL query
        */

        /*
        Copyright 2016 Bertrand STIVALET

Permission is hereby granted, without written agreement or royalty fee, to
use, copy, modify, and distribute this software and its documentation for
any purpose, provided that the above copyright notice and the following
three paragraphs appear in all copies of this software.

IN NO EVENT SHALL AUTHORS BE LIABLE TO ANY PARTY FOR DIRECT,
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE
USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF AUTHORS HAVE
BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

AUTHORS SPECIFICALLY DISCLAIM ANY WARRANTIES INCLUDING, BUT NOT
LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE, AND NON-INFRINGEMENT.

THE SOFTWARE IS PROVIDED ON AN "AS-IS" BASIS AND AUTHORS HAVE NO
OBLIGATION TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR
MODIFICATIONS.

        */

        using MySql.Data.MySqlClient;
using System;
        

        namespace default_namespace{

            

            class MainClass{

                public static void Main(string[] args){

                    string tainted_0 = null, tainted_1 = null;


                    
                tainted_0 = Console.ReadLine();
            

                    
                    //No filtering (sanitization)
                    tainted_1 = tainted_0;
                

                    string query = "SELECT * FROM Articles WHERE id="+tainted_1;

                    
            string connectionString = @"server=localhost;uid=mysql_user;password=mysql_password;database=dbname";
            MySqlConnection dbConnection = null;

            try {
                dbConnection = new MySqlConnection(connectionString);
                dbConnection.open();
                MySqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.ToString());
                }

                dbConnection.close();

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

        

                    
                    
                }

                
            }

        }
        