using Class_chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.ComTypes;
//using static System.Net.Mime.MediaTypeNames;
//using Newtonsoft.Json;


namespace Client_chat
{
    public partial class Chats_main : Form
    {
        public Chats_main()
        {
            InitializeComponent();
        }
        string Na_me { get; set; }
        public static bool Entrance { get; set; }

        public static User_photo[] Friend { get; set; }
        public static MessСhat[] allChat { get; set; }
        public static bool all_Chat { get; set; }
        public static Image Image { get; set; }
        public static int Users { get; set; }
        public static int Friends { get; set; }
        public static bool Update_Message { get; set; }

        public static int Update_id { get; set; }

        public static int selectedBiodataId;

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {



            if (toolStripTextBox1.Text != "")
            {   
                Entrance = true;  
                IP_ADRES.Ip_adress = toolStripTextBox1.Text;
                toolStripButton1.BackColor = Color.Gray;
                //Подключения к сервуру
                toolStripButton1.ForeColor = Color.Gray;
                Password_Users a = new Password_Users();
                a.Show();
                this.Hide();
            }
            else
            {
                Entrance = false;
                MessageBox.Show("Ip_adres:Не заполнен");


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindexs = dataGridViewChat.SelectedCells[0].RowIndex;
                MessСhat tt = allChat[selectedrowindexs];
                textBox1.Text = tt.Message;
                Update_id = tt.Id;
                Update_Message = true;
            }
            catch
            {

            }
        }

        private void toolStripButton1_MouseHover(object sender, EventArgs e)
        {
            // toolTip1.SetToolTip(toolStrip1, "Тут добавьте текст подсказки");
        }
        private void button3_Click(object sender, EventArgs e)
        { 
            string FileFS = "";
            //Отправка сообщений
            if (textBox1.Text == "")
            {
                //MessageBox.Show("Cообщение пустое!");
            }
            else
            {
                if (Update_Message == true)
                {
                    using (MemoryStream Update = new MemoryStream())
                    {
                        DateTime dateTime = DateTime.Now;
                        MessСhat Mes_chat = new MessСhat(Update_id, Users, Friends, textBox1.Text, dateTime, 1);
                        JsonSerializer.Serialize<MessСhat>(Update, Mes_chat);
                        FileFS = Encoding.Default.GetString(Update.ToArray());
                    }
                    Update_Message_make_up(IP_ADRES.Ip_adress, FileFS, "010", dataGridViewChat);
                    Update_Message = false;
                    Update_id = 0;
                    textBox1.Text = "";
                }
                else
                {
                    //Переделать блок на работу с памятью 


                    using (MemoryStream fs = new MemoryStream())
                    {
                        //string serialized = buf.ToString();
                        //Searh_Friends New_Friend = new Searh_Friends(textBox2.Text);
                        DateTime dateTime = DateTime.Now;

                        MessСhat Mes_chat = new MessСhat(0, Users, Friends, textBox1.Text, dateTime, 1);

                        //        JsonSerializer.SerializeToDefaultBytes(fs,);
                        JsonSerializer.Serialize<MessСhat>(fs, Mes_chat);
                        FileFS = Encoding.Default.GetString(fs.ToArray());

                        //Console.WriteLine("Data has been saved to file");*/
                    }
                    // чтение данных
                    textBox1.Text = "";
                    Insert_Message(IP_ADRES.Ip_adress, FileFS, "009", dataGridViewChat);
                }
            }
        }






        async static void Insert_Message(String server, string fs, string command, DataGridView sender)
        {
            try
            {
                Int32 port = 9595;

                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                data = new Byte[99999909];
                String responseData = String.Empty;
                String responseDat = String.Empty;
                Byte[] data2 = new Byte[99999909];
                Int32 bytesMess = await stream.ReadAsync(data2, 0, data2.Length);
                responseDat = System.Text.Encoding.Default.GetString(data2, 0, bytesMess);
                JObject details = JObject.Parse(responseDat);
                JToken Answe = details.SelectToken("Answe");
                JToken List_Mess = details.SelectToken("List_Mess");
                JToken AClass = details.SelectToken("AClass");
                if (Answe.ToString() == "true")
                {
                    MessСhat[] les = new MessСhat[AClass.Count()];

                    for (int i = 0; i < AClass.Count(); i++)
                    {
                        string yu = AClass[i].ToString();
                        MessСhat useTravel = JsonSerializer.Deserialize<MessСhat>(yu);
                        les[i] = useTravel;
                    }
                    sender.Rows.Clear();
                    sender.RowCount = les.Count();
                    sender.ColumnCount = 2;
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    {
                    }

                    sender.Columns.Insert(2, column);

                    for (int i = 0; i < les.Count(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].Message;
                            if (les[i].IdUserFrom != Users)
                                 { sender.Rows[i].Cells[j].Style.ForeColor = Color.Blue; }
                            
                        }
                        for (int j = 1; j < 2; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].DataMess;
                        }
                        for (int j = 2; j < 3; j++)
                        {
                            bool aMark = false;
                            if (les[i].Mark.ToString() == "1")
                            {
                                aMark = true;
                            }
                            sender.Rows[i].Cells[j].Value = aMark;
                        }
                    }
                    allChat = les;
                    sender.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    sender.Visible = true;
                }
                else
                {
                    sender.Rows.Clear();
                }
                stream.Close();
                client.Close();
  
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", e.Message);
            }

        }




        async static void Update_Message_make_up(String server, string fs, string command, DataGridView sender)
        {
            try
            {
                Int32 port = 9595;

                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                data = new Byte[99999909];
                String responseData = String.Empty;
                String responseDat = String.Empty;
                Byte[] data2 = new Byte[99999909];
                Int32 bytesMess = await stream.ReadAsync(data2, 0, data2.Length);
                responseDat = System.Text.Encoding.Default.GetString(data2, 0, bytesMess);

                JObject details = JObject.Parse(responseDat);
                JToken Answe = details.SelectToken("Answe");
                JToken List_Mess = details.SelectToken("List_Mess");
                JToken AClass = details.SelectToken("AClass");
                if (Answe.ToString() == "true")
                {
                    MessСhat[] les = new MessСhat[AClass.Count()];

                    for (int i = 0; i < AClass.Count(); i++)
                    {
                        string yu = AClass[i].ToString();
                        MessСhat useTravel = JsonSerializer.Deserialize<MessСhat>(yu);
                        les[i] = useTravel;
                    }
                    sender.Rows.Clear();
                    sender.RowCount = les.Count();
                    sender.ColumnCount = 2;
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    {
                    }

                    sender.Columns.Insert(2, column);

                    for (int i = 0; i < les.Count(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].Message;
                            if (les[i].IdUserFrom != Users)
                            { 
                                sender.Rows[i].Cells[j].Style.ForeColor = Color.Blue; 
                            }

                        }
                        for (int k = 1; k< 2; k++)
                        {
                            sender.Rows[i].Cells[k].Value = les[i].DataMess;
                        }
                        for (int b = 2; b < 3; b++)
                        {
                            bool aMark = false;
                            if (les[i].Mark.ToString() == "1")
                            {
                                aMark = true;
                            }
                            sender.Rows[i].Cells[b].Value = aMark;
                        }
                    }
                  
                    sender.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    allChat = les;
                    sender.Visible = true;
                }
                else
                {
                    sender.Rows.Clear();
                    //MessageBox.Show("Сообщений нет");
                }
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        public void OpenMes(User_photo ruser, User_photo[] Friends)
        {

            Na_me = ruser.Name;
            //  int id = 0;
            toolStripLabel1.Text = Na_me;
            if (Friends == null)
            {
             
            }
            else
            {   
                //MemoryStream ms = new MemoryStream(ruser.Photo);
                //Image returnImage = Image.FromStream(ms);
                //toolStripButton2.Image = returnImage;


            }
            if (toolStripButton2.Image == null)
            {
                // toolStripButton1.Image = Image.FromFile();
            }
            toolStripButton1.Image = Image.FromFile("Зеленый.png");
            Friend = Friends;
            try {


                //   int h = 0;
                if (Friends == null)
                {



                }
                else
                {
                    dataGridViewUser.RowCount = Friends.Count();
                    dataGridViewUser.ColumnCount = 1;
                    for (int i = 0; i < Friend.Count(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            // Друзья.Displayed.ToString(Friend[j].Name   as String);        //Rows[i].Cells[j].Value = 
                            //Друзья.DataGridView.Rows[i].Cells[j].Value= Friend[i].Name;
                            dataGridViewUser.Rows[i].Cells[j].Value = Friend[i].Name;
                            //Friend[i].Name = Convert.ToString(dataGridViewUser.Rows[i].Cells[j].Value);
                        }
                    }
                    dataGridViewUser.Columns[0].HeaderText = "Друзья";
                    //  dataGridViewUser.Visible = true;

                    /*На будущее заготовка для картинки

                    //Use_Photo use_Photo = new Use_Photo(Na_me);
                    //MemoryStream memoryStream = new MemoryStream();
                    //string FileFS = "";
                    //if (UseCompelete.UC)
                    //{
                    //    using (MemoryStream fs = new MemoryStream())
                    //    {
                    //        JsonSerializer.Serialize<Use_Photo>(memoryStream, use_Photo);
                    //        byte[] buffer = new byte[memoryStream.Length];
                    //        memoryStream.Read(buffer, 0, buffer.Length);
                    //        FileFS = Encoding.Default.GetString(buffer);
                    //    }
                    //}
                    //Connectt("192.168.0.113", FileFS, "007");
                    //toolStripButton2.Image = Image;
                    */
                }
                Users = ruser.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //toolStrip1.
        //textBox2.Text = aMes;
        //textBox1.Text = aIdUserTo;
        //textBox1.Text = aIdUserFrom;

        //DataTable dt = new DataTable();
        //dataGridViewUser.RowCount = 2;
        //dataGridViewUser.ColumnCount = 1;
        // arr = new string[dataGridViewUser.RowCount, dataGridViewUser.ColumnCount];
        //dataGridViewUser.DataSource = dt;


        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void Chats_main_Load(object sender, EventArgs e)
        {
            toolStripButton1.Image = Image.FromFile("Красный.png");
            // BorderStyle.None;
            dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewUser.RowHeadersVisible = false;

            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            dataGridViewChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewChat.RowHeadersVisible = false;

            button2.Visible = false;
            button1.Visible = false;

        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                        dataGridViewChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridViewUser_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dataGridViewUser.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dataGridViewUser.Rows[selectedrowindex];

                //String Friend = Convert.ToString(selectedRow.Cells[0].Value);
                User_photo tt = Friend[selectedrowindex];
                string person = JsonSerializer.Serialize<User_photo>(tt);
                //  Friends = person;


                User_photo Id_Friend = JsonSerializer.Deserialize<User_photo>(person);
                Friends = Id_Friend.Id;

                Connect(IP_ADRES.Ip_adress, person, "006", dataGridViewChat);
                //OpenChat(dataGridViewChat);
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);

            }

        }

        //private static void OpenChat(DataGridView sender)
        //{
        //    try
        //    {
        //        if (all_Chat)
        //        {

        //            sender.RowCount = 2;
        //            sender.ColumnCount = 1;
        //            for (int i = 0; i < allChat.Count(); i++)
        //            {
        //                for (int j = 0; j < 1; j++)
        //                {
        //                  //  sender.Rows[i].Cells[j].Value = allChat[i].Message;
        //                }
        //            }
        //            sender.Visible = true;
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch(Exception e)
        //    {
        //      MessageBox.Show(e.Message); 
        //    }

        //}

        async static void Connect(String server, string fs, string command, DataGridView sender)
        {
            try
            {
                Int32 port = 9595;

                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                data = new Byte[99999999];
                String responseData = String.Empty;
                String responseDat = String.Empty;

                //Int32 bytess = await stream.ReadAsync(data, 0, data.Length);
                // responseData = System.Text.Encoding.Default.GetString(data, 0, bytess);
                // if (responseData != "false")
                // {
                //MessСhat aChat = JsonSerializer.Deserialize<MessСhat>(responseData);

                //    //получить перечень сообщений
                Byte[] data2 = new Byte[99999909];
                Int32 bytesMess = await stream.ReadAsync(data2, 0, data2.Length);


                //   responseDat =System.Text.Encoding.ASCII.GetString(data,0, bytesMess);

                //   data =Convert.FromBase64String(responseDat);
                //responseDat =System.Text.Encoding.Default.(data);

                //responseDat = System.Text.Encoding.Default.GetString(data, 0, bytesMess);
                responseDat = System.Text.Encoding.Default.GetString(data2, 0, bytesMess);

                //Encoding Default = Encoding.Default;
                //Encoding ascii = Encoding.ASCII;

                //string input = "Auspuffanlage \"Century\" f├╝r";
                //string output = ascii.GetString(Encoding.Convert(Default, ascii, Default.GetBytes(responseDat)));
                //all_Chat = true;
                //var a = AClass.Values("IdUserFrom");

                //string Answe1 = Answe.ToString();
                //string List_Mess1 = List_Mess.ToString();
                //string AClass1 = AClass.ToString();
                //string[] les = new string[] {AClass1};

                //JToken id = AClass.Values("IdUserFrom") as JToken;
                //JToken IdUserFrom = AClass.Values("IdUserFrom") as JToken;
                //JToken IdUserTo = AClass.Values("IdUserTo") as JToken;
                //JToken Message = AClass.Values("Message") as JToken; 
                //JToken DataMess = AClass.Values("DataMess") as JToken;
                //JToken Mark = AClass.Values("Mark") as JToken;

                JObject details = JObject.Parse(responseDat);
                JToken Answe = details.SelectToken("Answe");
                JToken List_Mess = details.SelectToken("List_Mess");
                JToken AClass = details.SelectToken("AClass");
                if (Answe.ToString() == "true")
                {


                    MessСhat[] les = new MessСhat[AClass.Count()];

                    for (int i = 0; i < AClass.Count(); i++)
                    {
                        string yu = AClass[i].ToString();
                        MessСhat useTravel = JsonSerializer.Deserialize<MessСhat>(yu);
                        les[i] = useTravel;
                    }
                    sender.Rows.Clear();
                    sender.RowCount = les.Count() ;
                    sender.ColumnCount = 2;


                    allChat = les;
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    {
                        //column.HeaderText = ColumnName.OutOfOffice.ToString();
                        //column.Name = ColumnName.OutOfOffice.ToString();
                        //column.AutoSizeMode =
                        //    DataGridViewAutoSizeColumnMode.DisplayedCells;
                        //column.FlatStyle = FlatStyle.Standard;
                        //column.ThreeState = true;
                        //column.CellTemplate = new DataGridViewCheckBoxCell();
                        //column.CellTemplate.Style.BackColor = Color.Beige;
                    }

                    sender.Columns.Insert(2, column);

                    for (int i = 0; i < les.Count(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].Message;
                            sender.Columns[j].HeaderText = "Сообщение";

                            if (les[i].IdUserFrom != Users)
                            { sender.Rows[i].Cells[j].Style.ForeColor = Color.Blue; }

                        }
                        for (int k = 1; k < 2; k++)
                        {
                            sender.Rows[i].Cells[k].Value = les[i].DataMess;                
                            sender.Columns[k].HeaderText = "Дата отправления";

                        }
                        for (int l = 2; l < 3; l++)
                        {
                            bool aMark = false;
                            if (les[i].Mark.ToString() == "1")
                            {
                                aMark = true; 

                            }

                            //sender.Columns[2].ValueType = typeof(bool);
                            //sender.Columns[2].DefaultCellStyle. = 
                            sender.Rows[i].Cells[l].Value = aMark;            
                                sender.Columns[l].HeaderText = "Прочитал сообщение";

                        }
                    }

                  //  sender.Columns[1].HeaderText = "Сообщение";
                    sender.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    sender.Visible = true;
                }
                else
                {
                    sender.Rows.Clear();
                    //MessageBox.Show("Сообщений нет");
                }









                //JsonObject jsonObj = new JsonObject(JsonSerializer.SerializeToNode<UseTravel>(responseData));
                //int k = int.Parse(jsonObj["kill"].ToString())

                //string yy = Convert.ToBase64String(data);
                //string yy2 = yy.Substring(yy.IndexOf("{"), yy.Length - yy.IndexOf("{") - 1);
                //var txt2 = Encoding.Default.GetString(Convert.FromBase64String(str));
                //string rr = JsonSerializer.Deserialize<string>(responseDat);
                //string response12 = Newtonsoft.Json.JsonConvert.SerializeObject(bytesMess);

                //Int32 bytesMess = await stream.ReadAsync(data, 0, 5);
                //    responseDat = System.Text.Encoding.Default.GetString(data, 0, bytesMess);
                //UseTravel useTravel = JsonSerializer.DeserializeAsync<UseTravel>(data2.);
                //UseTravel useTravel = JsonSerializer.Deserialize<UseTravel>(tr);
                //MessageBox.Show($"{useTravel}");
                //string result = responseDat.Trim(new char[] { '"', '0' });
                //    Int32 it = Convert.ToInt32(result);
                //    MessСhat[] mChat = new MessСhat[it];
                //    Int32 bytesChat1 = await stream.ReadAsync(data, 0, data.Length);
                //    result = System.Text.Encoding.Default.GetString(data, 0, bytesChat1);
                //    string rez2 = result.Substring(0, result.IndexOf("}"));
                //    List<string> tokens = new List<string>(result.Split('}'));
                //  useTravel.aClass

                //    for (int j = 0; j < tokens.Count - 1; j++)
                //    {
                //        string tt = tokens[j] + "}";
                //        mChat[j] = JsonSerializer.Deserialize<MessСhat>(tt);
                //    }
                //allChat = mChat;

                //   }
                //    else
                //    { 
                //        MessageBox.Show("Сообщений нет");
                //    }
                stream.Close();
                client.Close();
          
                // stream.Close();
                //   client.Close();


            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", e.Message);
            }
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}

        }
        //async static void Connectt(String server, string fs, string command  )
        //{
        //    try
        //    {
        //        Int32 port = 9595;
        //        TcpClient client = new TcpClient(server, port);
        //        Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
        //        NetworkStream stream = client.GetStream();
        //        await stream.WriteAsync(data, 0, data.Length);
        //        data = new Byte[99999909];
        //        String responseData = String.Empty;
        //        String responseDat = String.Empty;             
        //        Byte[] data2 = new Byte[99999909];
        //        Int32 bytesMess = await stream.ReadAsync(data2, 0, data2.Length);
        //        responseDat = System.Text.Encoding.Default.GetString(data2, 0, bytesMess);
        //        UseImage useTravel = JsonSerializer.Deserialize<UseImage>(responseDat);

        //       if (useTravel.Bytes != null)
        //       {
        //          MemoryStream ms = new MemoryStream(useTravel.Bytes);
        //          Image returnImage = Image.FromStream(ms);
        //          // returnImage;
        //           Image = returnImage;
        //       }


        //     }
        //    catch (ArgumentNullException e)
        //    {
        //        MessageBox.Show("ArgumentNullException:{0}", e.Message);
        //    }
        //     catch (SocketException e)
        //    {
        //        MessageBox.Show("SocketException: {0}", e.Message);
        //    }
        // }
        private void dataGridViewChat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewChat_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewChat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string FileFS = "";


            using (MemoryStream fs = new MemoryStream())
            {
                //string serialized = buf.ToString();
                Searh_Friends New_Friend = new Searh_Friends(textBox2.Text, Na_me);
                //        JsonSerializer.SerializeToDefaultBytes(fs,);
                JsonSerializer.Serialize<Searh_Friends>(fs, New_Friend); 
                FileFS = Encoding.Default.GetString(fs.ToArray());

                //Console.WriteLine("Data has been saved to file");*/
            }
 
            Connect_Friends(IP_ADRES.Ip_adress, FileFS, "008", dataGridViewUser);
        }
        async static void Connect_Friends(String server, string fs, string command, DataGridView sender)
        {
            try
            {
                Int32 port = 9595;
                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                data = new Byte[99999909];
                Int32 bytesMess = await stream.ReadAsync(data, 0, data.Length);


                //   responseDat =System.Text.Encoding.ASCII.GetString(data,0, bytesMess);

                //   data =Convert.FromBase64String(responseDat);
                //responseDat =System.Text.Encoding.Default.(data);
                String responseDat = String.Empty;
                //responseDat = System.Text.Encoding.Default.GetString(data, 0, bytesMess);
                responseDat = System.Text.Encoding.Default.GetString(data, 0, bytesMess);

                Searh_Friends searh_Friends = JsonSerializer.Deserialize<Searh_Friends>(responseDat);

                //for (int i = 0; i < searh_Friends.Name i++)
                //{
                //    for (int j = 0; j < 1; j++)
                //    {
                //        // Друзья.Displayed.ToString(Friend[j].Name   as String);        //Rows[i].Cells[j].Value = 
                //        //Друзья.DataGridView.Rows[i].Cells[j].Value= Friend[i].Name;
                //        sender.Rows[i].Cells[j].Value = Friend[i].Name;
                //        //Friend[i].Name = Convert.ToString(dataGridViewUser.Rows[i].Cells[j].Value);
                //    }
                //}
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", e.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindexs = dataGridViewChat.SelectedCells[0].RowIndex;
                MessСhat tt = allChat[selectedrowindexs];
                textBox1.Text = tt.Message;
                Update_id = tt.Id;
                string FileFS = "";
                using (MemoryStream fs = new MemoryStream())
                {
                    DateTime dateTime = DateTime.Now;
                    MessСhat Mes_chat = new MessСhat(Update_id, Users, Friends, textBox1.Text, dateTime, 1);
                    JsonSerializer.Serialize<MessСhat>(fs, Mes_chat);
                    FileFS = Encoding.Default.GetString(fs.ToArray());
                }
                textBox1.Text = "";
                Delete_message_make_up(IP_ADRES.Ip_adress, FileFS, "011", dataGridViewChat);
            }
            catch
            {

            }
        }
        async static void Delete_message_make_up(String server, string fs, string command, DataGridView sender)
        {
            try
            {
                Int32 port = 9595;

                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                data = new Byte[99999909];
                String responseData = String.Empty;
                String responseDat = String.Empty;
                //    //получить перечень сообщений
                Byte[] data2 = new Byte[99999909];
                Int32 bytesMess = await stream.ReadAsync(data2, 0, data2.Length);
                responseDat = System.Text.Encoding.Default.GetString(data2, 0, bytesMess);
                JObject details = JObject.Parse(responseDat);
                JToken Answe = details.SelectToken("Answe");
                JToken List_Mess = details.SelectToken("List_Mess");
                JToken AClass = details.SelectToken("AClass");
                if (Answe.ToString() == "true")
                {
                    MessСhat[] les = new MessСhat[AClass.Count()];

                    for (int i = 0; i < AClass.Count(); i++)
                    {
                        string yu = AClass[i].ToString();
                        MessСhat useTravel = JsonSerializer.Deserialize<MessСhat>(yu);
                        les[i] = useTravel;
                    }
                    sender.Rows.Clear();
                    sender.RowCount = les.Count();
                    sender.ColumnCount = 2;
                 

                    allChat = les;
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    {
                    }

                    sender.Columns.Insert(2, column);

                    for (int i = 0; i < les.Count(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].Message;
                            if (les[i].IdUserFrom != Users)
                            { sender.Rows[i].Cells[j].Style.ForeColor = Color.Blue; }

                        }
                        for (int j = 1; j < 2; j++)
                        {
                            sender.Rows[i].Cells[j].Value = les[i].DataMess;
                        }
                        for (int j = 2; j < 3; j++)
                        {
                            bool aMark = false;
                            if (les[i].Mark.ToString() == "1")
                            {
                                aMark = true;
                            }

                           
                            sender.Rows[i].Cells[j].Value = aMark;
                        }
                    }
                    sender.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    sender.Visible = true;
                }
                else
                {
                    sender.Rows.Clear();
                    //MessageBox.Show("Сообщений нет");
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        private void dgrdResults_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }

        }

        private void dgrdResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //handle the row selection on right click
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridViewChat.CurrentCell = dataGridViewChat.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dataGridViewChat.Rows[e.RowIndex].Selected = true;
                    dataGridViewChat.Focus();

                    //selectedBiodataId = Convert.ToInt32(dataGridViewChat.Rows[e.RowIndex].Cells[1].Value);
                    selectedBiodataId = e.RowIndex;
                }
                catch (Exception)
                {

                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Редактировать запись "+ selectedBiodataId.ToString());
            try
            {
                int selectedrowindexs = dataGridViewChat.SelectedCells[0].RowIndex;
                MessСhat tt = allChat[selectedrowindexs];
                textBox1.Text = tt.Message;
                Update_id = tt.Id;
                Update_Message = true;
            }
            catch
            {

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindexs = dataGridViewChat.SelectedCells[0].RowIndex;
                MessСhat tt = allChat[selectedrowindexs];
                textBox1.Text = tt.Message;
                Update_id = tt.Id;
                string FileFS = "";
                using (MemoryStream fs = new MemoryStream())
                {
                    DateTime dateTime = DateTime.Now;
                    MessСhat Mes_chat = new MessСhat(Update_id, Users, Friends, textBox1.Text, dateTime, 1);
                    JsonSerializer.Serialize<MessСhat>(fs, Mes_chat);
                    FileFS = Encoding.Default.GetString(fs.ToArray());
                }
                textBox1.Text = "";
                Delete_message_make_up(IP_ADRES.Ip_adress, FileFS, "011", dataGridViewChat);
            }
            catch
            {

            }
        }
        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewChat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

