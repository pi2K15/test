
        /*
        input : shell commands
filtering : check if there is only numbers
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

        using System.Diagnostics;
using System.Text.RegularExpressions;
using System;
using System.Data.SqlClient;
using System.IO;
        

        namespace default_namespace{

            

            class MainClass{

                public static void Main(string[] args){

                    string tainted_0 = null, tainted_1 = null;


                    
                Process process = new Process();
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = "-c 'cat /tmp/tainted.txt'";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                using(StreamReader reader = process.StandardOutput) {
                    tainted_0 = reader.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                }
            

                    
                    string pattern = @"/^[0-9]*$/";
                    Regex r = new Regex(pattern);
                    Match m = r.Match(tainted_0);
                    if(!m.Success){
                        tainted_1 = "";
                    }
                

                    string query = "SELECT * FROM Articles WHERE id="+tainted_1;

                    
            string connectionString =  @"server=localhost;uid=sql_user;password=sql_password;database=dbname";
            SqlConnection dbConnection = null;

            try {
                dbConnection = new SqlConnection(connectionString);
                dbConnection.open();
                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()){
                    Console.WriteLine(reader.ToString());
                }

                dbConnection.close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        

                    
                    
                }

                
            }

        }
        