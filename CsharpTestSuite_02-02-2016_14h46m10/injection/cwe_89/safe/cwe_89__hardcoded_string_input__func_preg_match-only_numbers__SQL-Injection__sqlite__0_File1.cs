
        /*
        Hardcoded string input
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

        using System.Text.RegularExpressions;
using System.Data.SQLite;
        

        namespace default_namespace{

            

            class MainClass{

                public static void Main(string[] args){

                    string tainted_0 = null, tainted_1 = null;


                    
                tainted_0 = "hardcoded";
            

                    
                    string pattern = @"/^[0-9]*$/";
                    Regex r = new Regex(pattern);
                    Match m = r.Match(tainted_0);
                    if(!m.Success){
                        tainted_1 = "";
                    }
                

                    string query = "SELECT * FROM Articles WHERE id="+tainted_1;

                    
            SQLiteConnection dbConnection = null;
            try{
                dbConnection = new SQLiteConnection("data source=C:\\data");
                SQLiteCommand command = new SQLiteCommand(query, dbConnection);

                SQLiteDataReader reader = command.ExecuteReader();

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
        