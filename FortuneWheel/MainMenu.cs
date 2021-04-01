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
        const int MAX_PLAYERS = 4;
        Dispatcher thread = Dispatcher.CurrentDispatcher;
        private Player user;
        private IWheel wheel = null;
        private List<Player> players;
        private List<Label> playerLabels;
        private bool GameStarted = false;
        GamePanel gamePanel;
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
        public void PlayersUpdated(Player[] messages)
        {

            if (thread.Thread == System.Threading.Thread.CurrentThread)
            {
                if (GameStarted)
                {
                    this.BeginInvoke(new GuiUpdateDelegate(gamePanel.PlayersUpdated), new object[] { messages });
                }
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
                this.BeginInvoke(new GuiUpdateDelegate(PlayersUpdated), new object[] { messages });
        }

        private void PlayersUpdated()
        {
            if ( thread.Thread == System.Threading.Thread.CurrentThread)
            {
                if (GameStarted)
                {
                    this.BeginInvoke(new GuiUpdateDelegate(gamePanel.PlayersUpdated), new object[] { players.ToArray() });
                }
                int readyPlayers = 0;
                for (int i = 0; i <= playerLabels.Count; i++)
                {
                    if (players.Count <= i)
                    {
                        break;
                    }
                    string ready = players[i].isReady ? "(Ready)" : "(Not Ready)";
                    readyPlayers += players[i].isReady ? 1 : 0;
                    playerLabels[i].Text = $"{players[i]} {ready}";
                }
                if (readyPlayers >= 2 && readyPlayers == players.Count)
                {
                    GameStarted = true;
                    Hide();
                    gamePanel ??= new GamePanel(wheel, players, user);
                    gamePanel.Show();
                    gamePanel.FormClosed += (object source, FormClosedEventArgs e) => Close();
                }
            }
            else
                this.BeginInvoke(new GuiUpdateDelegate(PlayersUpdated), new object[] { players.ToArray() });
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            try
            {
                DuplexChannelFactory<IWheel> channel = new DuplexChannelFactory<IWheel>(this, "WheelService");
                wheel = channel.CreateChannel();
                if (wheel.AddPlayer(textBox_UserName.Text, out user))
                {
                    players = wheel.GetAllPlayers().ToList();
                    PlayersUpdated();
                    button_join.Enabled = false;
                }
                else
                {
                    if (wheel.GetAllPlayers().Length == MAX_PLAYERS)
                    {
                        MessageBox.Show("ERROR: No room for any additional players");
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Alias in use. Please try again.");
                    }
                    // Alias rejected by the service so nullify service proxies
                    wheel = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Ready_Click(object sender, EventArgs e)
        {
            user.isReady = !user.isReady;
            wheel.UpdatePlayer(user);
            PlayersUpdated();
        }
    }
}
