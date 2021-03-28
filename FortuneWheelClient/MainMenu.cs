using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using FortuneWheelLibrary;
using System.Windows.Threading;

namespace FortuneWheelClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class MainMenu : Form, ICallback
    {
        private IWheel wheel = null;
        public MainMenu()
        {
            InitializeComponent();
        }

        private delegate void GuiUpdateDelegate(Player[] messages);
        public void SendAllMessages(Player[] messages)
        {
            if (Dispatcher.CurrentDispatcher.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    listBox_users.DataSource = messages;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                this.BeginInvoke(new GuiUpdateDelegate(SendAllMessages), new object[] { messages });
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            try
            {
                DuplexChannelFactory<IWheel> channel = new DuplexChannelFactory<IWheel>(this, "WheelService");
                wheel = channel.CreateChannel();
                Player p = new Player(textBox_Name.Text);
                if (wheel.AddPlayer(p))
                {
                    listBox_users.DataSource = wheel.GetAllPlayers();
                    button_Submit.Enabled = false;
                }
                else
                {
                    // Alias rejected by the service so nullify service proxies
                    wheel = null;
                    MessageBox.Show("ERROR: Alias in use. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
