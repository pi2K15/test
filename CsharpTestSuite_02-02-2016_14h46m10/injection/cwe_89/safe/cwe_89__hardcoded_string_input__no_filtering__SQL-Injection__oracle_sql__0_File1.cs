
        /*
        Hardcoded string input
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

        using System.Data.OracleClient;
        

        namespace default_namespace{

            

            class MainClass{

                public static void Main(string[] args){

                    string tainted_0 = null, tainted_1 = null;


                    
                tainted_0 = "hardcoded";
            

                    
                    //No filtering (sanitization)
                    tainted_1 = tainted_0;
                

                    string query = "SELECT * FROM Articles WHERE id="+tainted_1;

                    
            string connectionString = "Data Source=localhost;User ID=oracle_user;Password=oracle_password";
            OracleConnection dbConnection = null;

            try{
                dbConnection = new OracleConnection(connectionString);
                dbConnection.Open();

                OracleCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = query;

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    Console.WriteLine(reader.ToString());
                }

                dbConnection.Close();

            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        

                    
                    
                }

                
            }

        }
        