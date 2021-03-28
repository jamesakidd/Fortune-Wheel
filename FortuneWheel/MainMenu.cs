using FortuneWheelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading; 

namespace FortuneWheel
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class MainMenu : Form, ICallback
    {
        private Player User;
        private IWheel wheel = null;
        private List<Player> players;
        private List<Label> playerLabels;
        public MainMenu()
        {
            players = new List<Player>();
            InitializeComponent();
            playerLabels = new List<Label>();
            playerLabels.Add(label_Player1);
            playerLabels.Add(label_Player2);
            playerLabels.Add(label_Player3);
            playerLabels.Add(label_Player4);
        }

        private delegate void GuiUpdateDelegate(Player[] messages);
        public void SendAllMessages(Player[] messages)
        {

            if (Dispatcher.CurrentDispatcher.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    players = messages.ToList();
                    PlayersUpdated();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                this.BeginInvoke(new GuiUpdateDelegate(SendAllMessages), new object[] { messages });
        }

        private void PlayersUpdated()
        {
            for (int i = 0; i <= playerLabels.Count; i++)
            {
                if (players.Count <= i)
                {
                    break;
                }
                string ready = players[i].isReady ? "(ready)" : "(Not Ready)";
                playerLabels[i].Text = $"{players[i]} {ready}";
            }
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            try
            {
                DuplexChannelFactory<IWheel> channel = new DuplexChannelFactory<IWheel>(this, "WheelService");
                wheel = channel.CreateChannel();
                Player p = new Player(textBox_UserName.Text);
                if (wheel.AddPlayer(p))
                {
                    User = p;
                    players = wheel.GetAllPlayers().ToList();
                    PlayersUpdated();
                    button_join.Enabled = false;
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

        private void button_Ready_Click(object sender, EventArgs e)
        {
            User.isReady = !User.isReady;
            wheel.UpdatePlayer(User);
            PlayersUpdated();
        }
    }
}
