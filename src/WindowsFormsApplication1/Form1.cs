using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string hash= "2653347b325416c879";
        string number= "+12149359161";
        string code = "34568";
        private int appId = 133331;
        private string apiHash = "2cf8546581352011fef865902fdee97f";

        private TelegramClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            txtCode.Text = code;
            txtNumber.Text = number;
            client = new TelegramClient(appId, apiHash);
            await client.ConnectAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                number = txtNumber.Text;
                hash = await client.SendCodeRequestAsync(number);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var code = txtCode.Text; // you can change code in debugger
                await client.MakeAuthAsync(number, hash, code);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            try
            {
               
                var result = await client.GetContactsAsync();
                var myInClause = new string[] { "989352185069", "+989352185069", "09352185069" };
                var user = result.Users.ToList()
                    .Where(x => x.GetType() == typeof(TLUser))
                    .Cast<TLUser>()
                    .FirstOrDefault(x => myInClause.Contains(x.Phone));
                
                await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, txtMessage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var myInClause = new string[] { "989352185069", "+989352185069", "09352185069" };
            var result = await client.GetContactsAsync();
            
            var user = result.Users.ToList()
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => myInClause.Contains(x.Username));
          var xx=  await client.GetHistoryAsync(new TLInputPeerUser() { UserId = user.Id }, 1, 100, 10);



           

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var myInClause = new string[] { "salamdl", "+989352185069", "09352185069" };
            var result = await client.GetUserDialogsAsync();
            var dialogs = await client.GetUserDialogsAsync();

            var user = result.Chats.ToList()
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => myInClause.Contains(x.T));
            var xx = await client.GetHistoryAsync(new TLInputPeerUser() { UserId = user.Id }, 1, 100, 10);


         
        }
    }
}
