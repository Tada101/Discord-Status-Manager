using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Webhook;
using System.Reflection;
using System.Diagnostics;

namespace Status_Manager
{
    public partial class StatusMGR : Form
    {

        DiscordSocketClient Client;
        public static StatusMGR instance = null;

        public StatusMGR()
        {
            InitializeComponent();
            Console.AppendText("\n");
        }

        private async void StatusMGR_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            Console.AppendText("Discord Status Manager is ready!" + "\n");
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Tada101");
        }

        private void discordServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/pSxDtf7");
        }

        private void supportMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/pools/c/81TFjR8Pug");
        }
        bool connected = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });

            Client.Log += Client_Log;

            try
            {
                await Client.LoginAsync(TokenType.User, TokenTXT.Text);
                await Client.StartAsync();
                connected = true;
            }
            catch
            {
                MessageBox.Show("Woops! Is your token a user token?", "Check token!");
                return;
            }
            await Task.Delay(3000);
        }

        private System.Threading.Tasks.Task Client_Log(LogMessage arg)
        {
            Invoke((Action)delegate
            {
                Console.AppendText(arg + "\n");
            });
            return null;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (TwitchURL.Text == "")
                {
                    MessageBox.Show("Woops! Please insert a twitch url or disable streaming on twitch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (connected = false)
                    {
                        MessageBox.Show("Woops! Please connect to a token first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(checkBox1.Checked == false)
                        {
                            await Client.SetGameAsync(textBox1.Text);
                        }
                        else
                        {
                            await Client.SetGameAsync(textBox1.Text, TwitchURL.Text, StreamType.Twitch);
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                TwitchURL.Show();
            else
                TwitchURL.Hide();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Tada101");
        }
    }
}
