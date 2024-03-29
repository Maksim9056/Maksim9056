﻿using Class_chat;
using Microsoft.Data.Sqlite;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ServersAccept
{
    internal class GlobalClass
    {
        public static string connectionString = "Data Source=usersdata.db";
        public static bool UserConnect { get; set; }
        public static bool User_Insert { get; set; }
        public static bool User_Select_Chats { get; set; }
        public static bool Mess_Chats { get; set; }
        public static string Current_User { get; set; }
        public static byte[] Image_User { get; set; }
        public static User_photo AUser { get; set; }
        public static User_photo[] List_Friend { get; set; }
        public static MessСhat[] aChatss { get; set; }
        public static MessСhat List_Mess { get; set; }
        public static string Id_Users { get; set; }
        public static int Frinds { get; set; }
        public static int[] Frend { get; set; }
        public static UseImage Use_image { get; set; }

        public static string Frends_id { get; set; }

          public static string Searh_Friend { get; set; } 
         public static bool  _Searh_Freind { get; set; }
        public static int Insert_Friend_by_id { get; set; }

        public static int Id_Users_Name { get; set; }
        public static MessСhat[] Frends_Chat_Wath { get; set; }

        public static int Id_Image { get; set; }




        public static bool Friends { get; set; }


        public static void CreateTable_Users()
        {
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER NOT NULL UNIQUE," +
                                      "Age INTEGER," +
                                      "Name TEXT  NOT NULL UNIQUE," +
                                      "Password TEXT NOT NULL, " +
                                      "Image INTEGER ," +
                                      "DataMess datetime NOT NULL," +
                                      "Mark boolean NOT NULL," +
                                      "PRIMARY KEY(Id AUTOINCREMENT)" +
                                      "FOREIGN KEY(Image) REFERENCES Files(Id))";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        //public static void CreateTable_Friends()
        //{

        //    using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //    {
        //        connection.Open();
        //        SqliteCommand command = new SqliteCommand();
        //        command.CommandText = "CREATE TABLE Friends (Id INTEGER NOT NULL UNIQUE,"+ 
        //                              "IdUserFrom INTEGER NOT NULL ,"+ 
        //                              "IdUserTo INTEGER NOT NULL ,"+ 
        //                              " PRIMARY KEY(Id AUTOINCREMENT))";
        //        command.Connection = connection;
        //        command.ExecuteNonQuery();
        //    }
        //}
        public static void CreateTable_Friends()
        {
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Friends (Id INTEGER NOT NULL UNIQUE," +
                                      " IdUserFrom	INTEGER , " +
                                      "IdUserTo	INTEGER , " +
                                      //"Message TEXT NOT NULL," +
                                      "PRIMARY KEY(Id AUTOINCREMENT)" +
                                      "FOREIGN KEY(IdUserFrom) REFERENCES Users(Id), " +
                                      "FOREIGN KEY(IdUserTo) REFERENCES Users(Id))";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        public static void CreateTable_Chat()
        {
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Chat (Id INTEGER NOT NULL UNIQUE," +
                                      " IdUserFrom	INTEGER , " +
                                      "IdUserTo	INTEGER , " +
                                      "Message TEXT NOT NULL," +
                                      "DataMess datetime NOT NULL," +
                                      "Image  INTEGER ," +
                                      "Mark boolean NOT NULL," +
                                      "PRIMARY KEY(Id AUTOINCREMENT)" +
                                      "FOREIGN KEY(IdUserFrom) REFERENCES Users(Id), " +
                                      "FOREIGN KEY(IdUserTo) REFERENCES Users(Id)" +
                                      "FOREIGN KEY(Image) REFERENCES Files(Id))";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public static void CreateTable_Files()
        {
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Files (Id INTEGER NOT NULL UNIQUE," +
                                      "Name TEXT," +
                                      "Image BLOB NOT NULL," +
                                      "PRIMARY KEY(Id AUTOINCREMENT))";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }


        async static public void Insert_Friends()
        {

            string sq = " Select  " +
                       "p.Id as 'Код', " +
                       "c.name as 'Отправитель', " +
                      "b.name as 'Получатель' " +
                       "From Friends p " +
                       "Join Users b ON p.IdUserFrom = b.id " +
                       "Join Users c ON p.IdUserTo = c.id ";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sq, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sq;
            }

        }

        //  string sq = $"INSERT INTO Users ( Messege, DataMess, Mark) VALUES ( {msg.ToString()}'{data}','{dateTime:s}','1')";and Password='{pasword}
        async public static void Insert_User(string data, string pasword, string age, DateTime dateTime)
        {
            try
            {
                string sq = $"INSERT INTO Users (Age,Name,Image,Password,DataMess,Mark) VALUES ({age},'{data}','{Id_Image}','{pasword}','{dateTime:s}','1')";
                using (var connection = new SqliteConnection(GlobalClass.connectionString))
                {
                    await connection.OpenAsync();
                    SqliteCommand command = new SqliteCommand(sq, connection);
            //        command.Parameters.Add(new SqliteParameter("@buf", buf));

                    await command.ExecuteNonQueryAsync();
                    command.CommandText = sq;
                }
            }
            catch
            {
                string sqlExpressio = $"SELECT * FROM Users  WHERE Name = '{data}'";

                using (var connection = new SqliteConnection(GlobalClass.connectionString))
                {
                    await connection.OpenAsync();
                    SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                    var n = await command.ExecuteReaderAsync();
                    if (n.HasRows == true)
                    {
                        Console.WriteLine("Такое имя уже есть");
                        User_Insert = true;
                    }
                    else
                    {
                        User_Insert = false;
                    }
                }
            }
        }
        async public static void Insert_Image(byte[] buf)
        {
            try
            {
                string sq = $"INSERT INTO Files (Image) VALUES (@buf)";
                using (var connection = new SqliteConnection(GlobalClass.connectionString))
                {
                    await connection.OpenAsync();
                    SqliteCommand command = new SqliteCommand(sq, connection);
                    command.Parameters.Add(new SqliteParameter("@buf", buf));
                    await command.ExecuteNonQueryAsync();
                    command.CommandText = sq;
                    command.CommandText = "select last_insert_rowid()";
                    int lastId = Convert.ToInt32(command.ExecuteScalar());
                    //int number = command.ExecuteNonQuery();
                    Id_Image = lastId;

                }
            }
            catch
            {

            }
        }

        async static public void Select_Users(string data, string pasword)
        {
            //string Name = "";
            string sqlExpressio = $"SELECT * FROM Users  WHERE Name = '{data}' and Password='{pasword}'";

            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                SqliteCommand commandS = new SqliteCommand(sqlExpressio, connection);
                var n = await command.ExecuteReaderAsync();
                SqliteDataReader sqReader = commandS.ExecuteReader();

                if (n.HasRows == true)
                {
                    Console.WriteLine("Такое имя уже есть");
                    UserConnect = true;
                    // Always call Read before accessing data.
                    while (sqReader.Read())
                    {

                        Current_User = sqReader["Id"].ToString();
                     int Image =Convert.ToInt32( sqReader["Image"].ToString() );
                        int Id = Convert.ToInt32(Current_User);
                      //  byte[] foto = null;
                        AUser = new User_photo(sqReader["Name"] as string, "", sqReader["Age"] as string, Image, Id);

                        Console.WriteLine(Current_User);
                    }
                }
                else
                {
                    UserConnect = false;
                }
            }
        }

        async static public void Select_Friend(string curent_user)
        {
            int UserCount = 0;
            string sqlExpressioCount = $"SELECT COUNT(*)  FROM Friends  WHERE IdUserFrom = {curent_user}";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressioCount, connection);
                SqliteCommand commandS = new SqliteCommand(sqlExpressioCount, connection);
                var n = await commandS.ExecuteReaderAsync();


                SqliteDataReader sqReader = command.ExecuteReader();
                if (n.HasRows == true)
                {
                    Friends = true;

                    while (sqReader.Read())
                    {
                        UserCount = sqReader.GetInt32(0);
                    }
                }
                else
                {
                 Friends = false;


                }
            }

            if (Friends == true) 
            { 

                 string sqlExpressio = $"SELECT IdUserTo  FROM Friends  WHERE IdUserFrom = {curent_user}";
                int[] Frend = new int[UserCount];
                int i = 0;

                using (var connection = new SqliteConnection(GlobalClass.connectionString))
                {
                    await connection.OpenAsync();
                    SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                    SqliteCommand commandS = new SqliteCommand(sqlExpressio, connection);
                    var n = await command.ExecuteReaderAsync();
                    SqliteDataReader sqReader = commandS.ExecuteReader();
                    if (n.HasRows == true)
                    {
                        Console.WriteLine("У пользователя есть друзья");
                        while (sqReader.Read())
                        {

                            Frend[i] = sqReader.GetInt32(0);
                            i = i + 1;
                            //Проходим по созданию фильтра для таблицы Users
                        }





                    //Делаем запрос к таблице Users с фильтром  по всем id с фильтром  и считываем поля в массив List_Friend

                        sqlExpressio = $"SELECT * FROM Users  WHERE Id in ({String.Join(",", Frend)})";

                        //using (var connections = new SqliteConnection(GlobalClass.connectionString))
                        //{
                            await connection.OpenAsync();
                            SqliteCommand commands_Fr = new SqliteCommand(sqlExpressio, connection);
                            SqliteCommand _commandS_Fr = new SqliteCommand(sqlExpressio, connection);
                            var _n = await commands_Fr.ExecuteReaderAsync();
                            SqliteDataReader sqReaders_Fr = _commandS_Fr.ExecuteReader();
                            if (_n.HasRows == true)
                            { //sqReader["Image"] as byte[]
                                int j = 0;
                                User_photo[] UserRG = new User_photo[UserCount];
                                while (sqReaders_Fr.Read())
                                {
                                    int Id = Convert.ToInt32(sqReaders_Fr["Id"].ToString());
                                    //  byte[] image = null;
                                    int Image = Convert.ToInt32(sqReaders_Fr["Image"].ToString());

                                    User_photo User = new User_photo(sqReaders_Fr["Name"] as string, "", sqReaders_Fr["Age"] as string, Image, Id);
                                    UserRG[j] = User;
                                    j++;
                                }
                                List_Friend = UserRG;
                                Friends = true;          
                                Console.WriteLine(curent_user);

                            }
                            else
                            {
                                //друзей нет 
                                Friends = false;
                            }
                        //}
                    }
                    else
                    {
                        //друзей нет 
                        Friends = false;
                    }
                }

            }
        }

        async static public void Select_From_Users(string data)
        {
            string sqlExpressi = $"SELECT * FROM Users  WHERE Name = '{data}'";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressi, connection);
                var n = await command.ExecuteReaderAsync();

                //         // Заполняем Dataset
                SqliteDataReader sqReader = command.ExecuteReader();

                if (n.HasRows == true)
                {
                    while (sqReader.Read())
                    {

                    }
                    User_Select_Chats = true;
                }
                else
                {
                    User_Select_Chats = false;
                }  
            }
        }


        async static public void Select_From_Users(string IdUserFrom, string IdUserTo)
        {
            Select_From_Users(IdUserFrom);
            Select_From_Users(IdUserTo);
            string sq = $"INSERT INTO Friends ( IdUserFrom,IdUserTo) VALUES ('{IdUserTo}','{IdUserFrom}')";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sq, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sq;
            }
            string sqй = $"INSERT INTO Friends ( IdUserFrom,IdUserTo) VALUES ('{IdUserFrom}','{IdUserTo}')";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqй, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sqй;
            }
        }

        async static public void Insert_Message(MessСhat messСhat)
        {        
            string sq = $"INSERT INTO Chat ( IdUserFrom,IdUserTo,Message,DataMess,Mark) VALUES ({messСhat.IdUserFrom},{messСhat.IdUserTo},'{messСhat.Message}','{messСhat.DataMess:s}',{messСhat.Mark})";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sq, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sq;
            }
            int UserCount = 0;
            string sqlExpressioCount = $"SELECT COUNT(*) AS rec_count FROM Chat WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                                                     $"(IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressioCount, connection);
                SqliteDataReader sqReader = command.ExecuteReader();
                //while (sqReader.Read())
                //{
                //    UserCount = sqReader.GetInt32(0);
                //}
                sqReader.Read();
                UserCount = Convert.ToInt32(sqReader["rec_count"].ToString());
            }


            string sqlExpressio = $"SELECT *  FROM Chat  WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                              $"(IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";

            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                SqliteCommand command2 = new SqliteCommand(sqlExpressio, connection);
                var n = await command.ExecuteReaderAsync();
                //   SqliteDataReader adapter = new SqliteDataReader(sqlExpressi, connection);

                //   SQLiteCommand cmd = new SQLiteCommand(sqlExpression, connection);
                //      ds = new DataSet();
                //         // Заполняем Dataset
                SqliteDataReader sqReader = command2.ExecuteReader();

                // Always call Read before accessing data.
                if (n.HasRows == true)
                {
                    MessСhat[] aClats = new MessСhat[UserCount];
                    int k = 0;

                    while (sqReader.Read())
                    {
                        int Id_message = Convert.ToInt32(sqReader["Id"].ToString());
                        int  IdUserFrom = Convert.ToInt32(sqReader["IdUserFrom"].ToString());
                        int  IdUserTo = Convert.ToInt32(sqReader["IdUserTo"].ToString());
                        DateTime DataMess = Convert.ToDateTime(sqReader["DataMess"].ToString());
                        int Mark = Convert.ToInt32(sqReader["Mark"].ToString());
                        MessСhat mСhats = new MessСhat(Id_message, IdUserFrom, IdUserTo, sqReader["Message"] as string,DataMess, Mark);
                        //aChat = mСhat;

                        aClats[k] = mСhats;
                        k++;

                    }
                    Frends_Chat_Wath = aClats;
                }
                else
                {
                 
                }
            }
        }


        async static public void Update_Message(MessСhat messСhat)
        {
            DateTime dateTime = DateTime.Now;

            string sq = $"UPDATE Chat SET  IdUserFrom = '{messСhat.IdUserFrom}',IdUserTo = '{messСhat.IdUserTo}',Message ='{messСhat.Message}',DataMess ='{dateTime:s}',Mark = '{messСhat.Mark}' WHERE Id = '{messСhat.Id}'";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sq, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sq;
            }


            int UserCount = 0;
            string sqlExpressioCount = $"SELECT COUNT(*) AS rec_count FROM Chat WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                                                    $" (IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressioCount, connection);
                SqliteDataReader sqReader = command.ExecuteReader();
 
                sqReader.Read();
                UserCount = Convert.ToInt32(sqReader["rec_count"].ToString());
            }


            string sqlExpressio = $"SELECT *  FROM Chat  WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                            $" (IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                SqliteCommand command2 = new SqliteCommand(sqlExpressio, connection);
                var n = await command.ExecuteReaderAsync();          
                SqliteDataReader sqReader = command2.ExecuteReader();
                // Always call Read before accessing data.
                if (n.HasRows == true)
                {
                    MessСhat[] aClats = new MessСhat[UserCount];
                    int k = 0;

                    while (sqReader.Read())
                    {
                        int Id_message = Convert.ToInt32(sqReader["Id"].ToString());
                        int IdUserFrom = Convert.ToInt32(sqReader["IdUserFrom"].ToString());
                        int IdUserTo = Convert.ToInt32(sqReader["IdUserTo"].ToString());
                        DateTime DataMess = Convert.ToDateTime(sqReader["DataMess"].ToString());
                        int Mark = Convert.ToInt32(sqReader["Mark"].ToString());
                        MessСhat mСhats = new MessСhat(Id_message, IdUserFrom, IdUserTo, sqReader["Message"] as string, DataMess, Mark);

                        aClats[k] = mСhats;
                        k++;                     
                    }
                    Frends_Chat_Wath = aClats;
                }
                else
                {

                }
            }
        }


        async static public void Delete_Message_make_up(MessСhat messСhat)
        {
            string sqlExpression = $"DELETE   FROM Chat  WHERE Id = '{messСhat.Id}'";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {

                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = sqlExpression;
            }
            int UserCount = 0;
            string sqlExpressioCount = $"SELECT COUNT(*) AS rec_count FROM Chat WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                                                    $" (IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressioCount, connection);
                SqliteDataReader sqReader = command.ExecuteReader();

                sqReader.Read();
                UserCount = Convert.ToInt32(sqReader["rec_count"].ToString());
            }


            string sqlExpressio = $"SELECT *  FROM Chat  WHERE ((IdUserFrom = '{messСhat.IdUserFrom}' and IdUserTo = '{messСhat.IdUserTo}') or " +
                                                            $" (IdUserTo = '{messСhat.IdUserFrom}' and IdUserFrom = '{messСhat.IdUserTo}'))";

            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                SqliteCommand command2 = new SqliteCommand(sqlExpressio, connection);
                var n = await command.ExecuteReaderAsync();

                SqliteDataReader sqReader = command2.ExecuteReader();
           
                if (n.HasRows == true)
                {
                    MessСhat[] aClats = new MessСhat[UserCount];
                    int k = 0;

                    while (sqReader.Read())
                    {
                        int Id_message = Convert.ToInt32(sqReader["Id"].ToString());
                        int IdUserFrom = Convert.ToInt32(sqReader["IdUserFrom"].ToString());
                        int IdUserTo = Convert.ToInt32(sqReader["IdUserTo"].ToString());
                        DateTime DataMess = Convert.ToDateTime(sqReader["DataMess"].ToString());
                        int Mark = Convert.ToInt32(sqReader["Mark"].ToString());
                        MessСhat mСhats = new MessСhat(Id_message, IdUserFrom, IdUserTo, sqReader["Message"] as string, DataMess, Mark);

                        aClats[k] = mСhats;
                        k++;
                    }
                    Frends_Chat_Wath = aClats;
                }
                else
                {

                }
            }
        }
        //async static public void Select_From_Users(string data, string message, DateTime dateTime)
        //{

        //    string sqlExpression = $"UPDATE Users SET  Name = '{data}',Messege= '{message}, Image = @buf WHERE Id = '{Id}'";

        //    using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //    {
        //        connection.Open();
        //        SqliteCommand command = new SqliteCommand(sqlExpression, connection);


        //        command.ExecuteNonQuery();


        //    } //      command.Parameters.Add(new ("@buf", buf));
        //}




        //async public void UPDATE_User(byte[] msg, string data, DateTime dateTime)
        //{  //*{/*Age*/', {Namme}*/{Id}{Namme} Age = ' Name = '', Image = @buf WHERE Id = ''
        //    try  /*{data}*/
        //    {
        //      string sqlExpression = $"UPDATE Users SET Messege ={msg.ToString()}', DataMess={dateTime:s}, Mark ='1'";

        //        using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //        {
        //        await    connection.OpenAsync();
        //           SqliteCommand command = new SqliteCommand(sqlExpression, connection);
        //         //   command.Parameters.Add(new SqliteParameter("@buf", buf));

        //          await  command.ExecuteNonQueryAsync();

        //            connection.Close();
        //            connection.Dispose();
        //        }
        //    }
        //    catch
        //    {

        //        string sqlExpressio = $"SELECT * FROM Users  WHERE Name = ''";

        //        using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //        {
        //            connection.Open();
        //            SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
        //          var n =  await command.ExecuteReaderAsync();
        //            if (n.HasRows == true)
        //            {
        //                Console.WriteLine("Такое имя уже есть");
        //               // N = true;
        //            }
        //        }
        //    }
        //}



        //using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //{
        //    connection.Open();
        //    SqliteCommand command = new SqliteCommand();
        //    command.CommandText = "CREATE TABLE IF NOT EXISTS Chat ( Id	INTEGER UNIQUE," +
        //        " IdUserFrom INTEGER , " +
        //     //   "IdUserTo INTEGER , " +
        //         "Messege TEXT NOT NULL, " +
        //        "Mark boolean NOT NULL," +
        //        "PRIMARY KEY(Id), FOREIGN KEY(IdUserFrom) REFERENCES Users(Id)," +
        //        "FOREIGN KEY(IdUserTo) REFERENCES Users(Id));";

        //    command.Connection = connection;
        //    command.ExecuteNonQuery();
        //}
        async static public void Select_Message_Users(User_photo data)
        {

            int UserCount = 0;
            string sqlExpressioCount = $"SELECT COUNT(*) AS rec_count FROM Chat " +
                                       $"WHERE ((IdUserTo = '{data.Id}' and IdUserFrom = '{Current_User}') or " +
                                       $" (IdUserFrom = '{data.Id}' and IdUserTo = '{Current_User}')) ";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressioCount, connection);
                SqliteDataReader sqReader = command.ExecuteReader();
                //while (sqReader.Read())
                //{
                //    UserCount = sqReader.GetInt32(0);
                //}
                sqReader.Read();
                UserCount = Convert.ToInt32(sqReader["rec_count"].ToString());
            }
            
            string sqlExpressi = $"SELECT  * FROM Chat WHERE ((IdUserTo = '{data.Id}' and IdUserFrom = '{Current_User}') or " +
                                                           $"(IdUserFrom = '{data.Id}' and IdUserTo = '{Current_User}'))";
            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressi, connection);
                SqliteCommand commandS = new SqliteCommand(sqlExpressi, connection);
                var n = await command.ExecuteReaderAsync();
                SqliteDataReader sqReader = commandS.ExecuteReader();

                if (n.HasRows == true)
                {
                    //int k = 0;

                    int j = 0;
                    //MessСhat  aChat ; // пока 10
                    MessСhat[] aChats = new MessСhat[UserCount];
                    while (sqReader.Read())
                    {
                        int Id = Convert.ToInt32(sqReader["Id"].ToString());
                        int IdIdUserFrom = Convert.ToInt32(sqReader["IdUserFrom"].ToString());
                        int IdUserTo = Convert.ToInt32(sqReader["IdUserTo"].ToString());
                        int Mark = Convert.ToInt32(sqReader["Mark"].ToString());
                        DateTime DataMess = Convert.ToDateTime(sqReader["DataMess"].ToString());

                        MessСhat mСhat = new MessСhat(Id, IdIdUserFrom, IdUserTo, sqReader["Message"] as string,
                                                DataMess, Mark);
                        //aChat = mСhat;

                        aChats[j] = mСhat;
                        j++;

                    }
                    //List_Mess = aChats;                         


                    aChatss = aChats;
                    Mess_Chats = true;

                }
                else
                {
                    //сообщений нет 
                    Mess_Chats = false;
                }



                // Frends_id = sqReader["Id"].ToString();

                //   string questions = sqReader["Id"];
                //.Items.Add(questions);
                // Console.WriteLine(questions);
                //  Id_Users =  questions;
                //}
                //if (n.HasRows == true)
                //    {      
                //       Console.WriteLine($" Такое имя уже есть" );
                //       User_Select_Chats = true;
                //    }
                //    else
                //    {
                //    User_Select_Chats = false;
                //    }
            }
         
            //string sqlExpressio = $"SELECT IdUserTo  FROM Friends  WHERE IdUserFrom = {Frends_id}";
            ////int[] Frend = new int[UserCount];
            //int i = 0;

            //using (var connection = new SqliteConnection(GlobalClass.connectionString))
            //{
            //    await connection.OpenAsync();
            //    SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
            //    SqliteCommand commandS = new SqliteCommand(sqlExpressio, connection);
            //    var n = await command.ExecuteReaderAsync();
            //    SqliteDataReader sqReader = commandS.ExecuteReader();
            //    if (n.HasRows == true)
            //    {
            //        Console.WriteLine("У пользователя есть друзья");
            //        while (sqReader.Read())
            //        {

            //            Frend[i] = sqReader.GetInt32(0);
            //            i = i + 1;
            //            //Проходим по созданию фильтра для таблицы Users
            //        }
            //    }
            //    else
            //    {
            //        //друзей нет 
            //    }
            //}

        }
        async static public void Searh_Users(Searh_Friends data)
        {
            //string Name = "";
            string sqlExpressio = $"SELECT * FROM Users  WHERE Name = '{data.Name}'";

            using (var connection = new SqliteConnection(GlobalClass.connectionString))
            {
                await connection.OpenAsync();
                SqliteCommand command = new SqliteCommand(sqlExpressio, connection);
                SqliteCommand commandS = new SqliteCommand(sqlExpressio, connection);
                var n = await command.ExecuteReaderAsync();
                SqliteDataReader sqReader = commandS.ExecuteReader();

                if (n.HasRows == true)
                {
                    //   Console.WriteLine("Такое имя уже есть");
                    // UserConnect = true;
                    // Always call Read before accessing data.
                    while (sqReader.Read())
                    {

                        //       Current_User = sqReader["Id"].ToString();
                        Insert_Friend_by_id = Convert.ToInt32(sqReader["Id"].ToString());
                        //Еще будет нужна
                        //  int Id = Convert.ToInt32(Current_User);
                        string Friend = sqReader["Name"].ToString();

                        Searh_Friend = Friend;

                        Console.WriteLine(Current_User);
                    }
                    _Searh_Freind = true;
                }
                else
                {
                    _Searh_Freind = false;
                }
            }
            string sqlExpressi = $"SELECT * FROM Users  WHERE Name = '{data.User}'";
            using (var connectio = new SqliteConnection(GlobalClass.connectionString))
                {
                    await connectio.OpenAsync();
                    SqliteCommand _command = new SqliteCommand(sqlExpressi, connectio);
                    SqliteCommand __commandS = new SqliteCommand(sqlExpressi, connectio);
                    var ns = await _command.ExecuteReaderAsync();
                    SqliteDataReader sqReaders = __commandS.ExecuteReader();

                    if (ns.HasRows == true)
                    {
                        //   Console.WriteLine("Такое имя уже есть");
                        // UserConnect = true;
                        // Always call Read before accessing data.
                        while (sqReaders.Read())
                        {

                          //       Current_User = sqReader["Id"].ToString();
                           Id_Users = sqReaders["Id"].ToString() ;
                            //Еще будет нужна
                            //  int Id = Convert.ToInt32(Current_User);
                            string Friend = sqReaders["Name"].ToString();

                            Searh_Friend = Friend;

                            Console.WriteLine(Current_User);
                        }
                    }
                    else
                    {

                    }
                }

            //Обработать ситуацию, когда _Searh_Freind=false т.е. не найден пользователь для добавления в друзья 
            string sqlE = $"SELECT * FROM Friends  WHERE IdUserFrom = {Insert_Friend_by_id} and IdUserTo ={Id_Users} and IdUserFrom = {Id_Users} and IdUserTo ={Insert_Friend_by_id}";

                 using (var connections = new SqliteConnection(GlobalClass.connectionString))
               {
                        await connections.OpenAsync();
                        SqliteCommand command_ = new SqliteCommand(sqlE, connections);
                        var n1 = await command_.ExecuteReaderAsync();

                SqliteCommand commands_ = new SqliteCommand(sqlE, connections);

                SqliteDataReader sqReader2 = commands_.ExecuteReader();

                        // Always call Read before accessing data.
                       if (n1.HasRows == true)
                        {
                            while (sqReader2.Read())
                            {

                                //   string questions = sqReader["Id"];
                                //.Items.Add(questions);
                                // Console.WriteLine(questions);
                                //  Id_Users =  questions;

                            }
                            Console.WriteLine("Друг уже добавлен");                            
                       }
                       else
                       {
                            string sq = $"INSERT INTO Friends ( IdUserFrom,IdUserTo) VALUES ('{Insert_Friend_by_id}','{Id_Users}')";
                            using (var connecti = new SqliteConnection(GlobalClass.connectionString))
                            {
                                await connecti.OpenAsync();
                                SqliteCommand comman = new SqliteCommand(sq, connecti);
                                await comman.ExecuteNonQueryAsync();
                                comman.CommandText = sq;
                            }
                    string sq1 = $"INSERT INTO Friends ( IdUserFrom,IdUserTo) VALUES ('{Id_Users}','{Insert_Friend_by_id}')";
                    using (var connecti = new SqliteConnection(GlobalClass.connectionString))
                    {
                        await connecti.OpenAsync();
                        SqliteCommand comman = new SqliteCommand(sq1, connecti);
                        await comman.ExecuteNonQueryAsync();
                        comman.CommandText = sq1;
                    }
                }
                Id_Users = "";
         Insert_Friend_by_id = 0;
                 }
         }
            
        
        //async static public void Select_Image_Userss(Use_Photo data)
        //{
        //    string sqlExpressi = $"SELECT * FROM Users  WHERE Name = '{data.User}'";
        //    using (var connection = new SqliteConnection(GlobalClass.connectionString))
        //    {
        //        await connection.OpenAsync();
        //        SqliteCommand command = new SqliteCommand(sqlExpressi, connection);
        //       var n = await command.ExecuteReaderAsync();
        //        //   SqliteDataReader adapter = new SqliteDataReader(sqlExpressi, connection);

        //        //   SQLiteCommand cmd = new SQLiteCommand(sqlExpression, connection);
        //        //      ds = new DataSet();
        //        //         // Заполняем Dataset
        //        SqliteDataReader sqReader = command.ExecuteReader();
        //        // Always call Read before accessing data
        //        if (n.HasRows == true)
        //        {
        //            while (sqReader.Read())
        //            {
        //                UseImage useImage = new UseImage(sqReader["Image"] as byte[]);
        //                //  string questions = sqReader["Id"];
        //                //.Items.Add(questions);
        //                // Console.WriteLine(questions);
        //                //  Id_Users =  questions;
        //                Use_image = useImage;
        //            }
        //        }
        //        else
        //        {
        //            //    User_Select_Chats = false;
        //        }
        //    }
        //}
    }
}
