using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using fCraft;

namespace HelperBotConfig
{
    public partial class HelperBotConfig : Form
    {       
        public HelperBotConfig()
        {
            InitializeComponent();             
        }   
        private void Config_Load(object sender, EventArgs e)
        {
            #region xmlreader
            if (!File.Exists("HelperBot.xml"))
            {
                return;
            }
            else
            {
                //Create a new XmlReader for HelperBot.xml
                XmlReader reader = XmlReader.Create("HelperBot.xml");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "AnnounceFly")
                        {
                            xFly.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceServer")
                        {
                            xServer.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceHours")
                        {
                            xHours.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceRank")
                        {
                            xRank.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceWarnKick")
                        {
                            xWarnKick.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceWarnSwear")
                        {
                            xWarnSwear.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceSuggestBan")
                        {
                            xSuggestBan.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower());
                        }
                        if (reader.Name == "AnnounceImpersonation")
                        {
                            xImpersonation.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceTime")
                        {
                            xTime.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceRandomMessages")
                        {
                            xRandom.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnouncePM")
                        {
                            xPM.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceFell")
                        {
                            xFell.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceSpleefTimer")
                        {
                            xSpleef.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceGreeting")
                        {
                            xGreeting.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceDemoted")
                        {
                            xDemoted.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceJokes")
                        {
                            xJokes.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "AnnounceCaps")
                        {
                            xCaps.Checked = Convert.ToBoolean(reader.GetAttribute(0).ToLower()); ;
                        }
                        if (reader.Name == "BotName")
                        {
                            nameBox.Text = reader.GetAttribute(0);
                        }
                        if (reader.Name == "Website")
                        {
                            webBox.Text = reader.GetAttribute(0);
                        }
                        if (reader.Name == "BotColor")
                        {
                            colorBox.SelectedItem = reader.GetAttribute(0);
                        }
                        
                    }                    
                }
                reader.Close();
            }
            #region colorReader

            #endregion
            #endregion

            #region tooltips
            ToolTip colorTip = new ToolTip();
            ToolTip webTip = new ToolTip();
            ToolTip nameTip = new ToolTip();
            colorTip.SetToolTip(this.colorBox, "This will be the color of your bot when it talks in the server chat.");
            webTip.SetToolTip(this.webBox, "This will be the website url your bot will display when asked 'What is the server website?'");
            nameTip.SetToolTip(this.nameBox, "This will be the name the bot uses during server chat.");

            ToolTip flyTip = new ToolTip();
            ToolTip serverTip = new ToolTip();
            ToolTip hourTip = new ToolTip();
            ToolTip rankTip = new ToolTip();
            ToolTip warnKickTip = new ToolTip();
            ToolTip warnSwearTip = new ToolTip();
            ToolTip suggestBanTip = new ToolTip();
            ToolTip impersonationTip = new ToolTip();
            ToolTip timeTip = new ToolTip();
            ToolTip randomMessagesTip = new ToolTip();
            ToolTip pmTip = new ToolTip();
            ToolTip fellTip = new ToolTip();
            ToolTip spleefTip = new ToolTip();
            ToolTip greetingTip = new ToolTip();
            ToolTip demotedTip = new ToolTip();
            ToolTip jokesTip = new ToolTip();
            ToolTip capsTip = new ToolTip();
            flyTip.SetToolTip(this.xFly, "Bot will respond to players who are enquiring about /Fly or Fly Clients.");
            serverTip.SetToolTip(this.xServer, "Bot will respond when asked about the server name.");
            hourTip.SetToolTip(this.xHours, "Bot will display the player's hours when asked.");
            rankTip.SetToolTip(this.xRank, "Bot will display the requirements for a player to get promoted when asked.");
            warnKickTip.SetToolTip(this.xWarnKick, "Bot will warn players who log in from a kick about the server rules.");
            warnSwearTip.SetToolTip(this.xWarnSwear, "Bot will warn players for swearing in PMs.");
            suggestBanTip.SetToolTip(this.xSuggestBan, "Bot will suggest a ban if a player is meeting certain criteria.");
            impersonationTip.SetToolTip(this.xImpersonation, "Bot will kick if another player impersonates them.");
            timeTip.SetToolTip(this.xTime, "Bot will give the time of day when provoked");
            randomMessagesTip.SetToolTip(this.xRandom, "Bot will randomly display messages to server about certain stats, and report important stats to online staff members.");
            pmTip.SetToolTip(this.xPM, "Bot will give instructions on how to make a private message when asked.");
            fellTip.SetToolTip(this.xFell, "Bot will assist in helping players who are stuck or who have fallen by explaining how to return to spawn point.");
            spleefTip.SetToolTip(this.xSpleef, "Bot will start a spleef timer when a player types '!Spleef'.");
            greetingTip.SetToolTip(this.xGreeting, "Bot will greet a player if it is their fitst time joining the server.");
            demotedTip.SetToolTip(this.xDemoted, "Bot will explain what to do when demoted.");
            jokesTip.SetToolTip(this.xImpersonation, "Bot will display random jokes/facts when provoked.");
            capsTip.SetToolTip(this.xCaps, "Bot will warn players that spam caps on the server.");
            #endregion

        }

        private void xBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (xBoxes.Checked)
            {
                xFly.Checked = true;
                xServer.Checked = true;
                xHours.Checked = true;
                xRank.Checked = true;
                xWarnKick.Checked = true;
                xWarnSwear.Checked = true;
                xSuggestBan.Checked = true;
                xImpersonation.Checked = true;
                xTime.Checked = true;
                xRandom.Checked = true;
                xPM.Checked = true;
                xFell.Checked = true;
                xSpleef.Checked = true;
                xGreeting.Checked = true;
                xJokes.Checked = true;
                xCaps.Checked = true;
                xDemoted.Checked = true;
            }
            else
            {
                xFly.Checked = false;
                xServer.Checked = false;
                xHours.Checked = false;
                xRank.Checked = false;
                xWarnKick.Checked = false;
                xWarnSwear.Checked = false;
                xSuggestBan.Checked = false;
                xImpersonation.Checked = false;
                xTime.Checked = false;
                xRandom.Checked = false;
                xPM.Checked = false;
                xFell.Checked = false;
                xSpleef.Checked = false;
                xGreeting.Checked = false;
                xJokes.Checked = false;
                xCaps.Checked = false;
                xDemoted.Checked = false;
            }
        }
        #region color            
       
        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorBox.SelectedItem == "Black") 
            {
                colorView.BackColor = System.Drawing.Color.Black;
            }
            if (colorBox.SelectedItem == "Gray")
            {
                colorView.BackColor = System.Drawing.Color.Gray;
            }
            if (colorBox.SelectedItem == "Navy")
            {
                colorView.BackColor = System.Drawing.Color.Navy;
            }
            if (colorBox.SelectedItem == "Blue")
            {
                colorView.BackColor = System.Drawing.Color.Blue;
            }
            if (colorBox.SelectedItem == "Green")
            {
                colorView.BackColor = System.Drawing.Color.Green;
            }
            if (colorBox.SelectedItem == "Lime")
            {
                colorView.BackColor = System.Drawing.Color.LimeGreen;
            }
            if (colorBox.SelectedItem == "Teal")
            {
                colorView.BackColor = System.Drawing.Color.Teal;
            }
            if (colorBox.SelectedItem == "Aqua")
            {
                colorView.BackColor = System.Drawing.Color.Aqua;
            }
            if (colorBox.SelectedItem == "Maroon")
            {
                colorView.BackColor = System.Drawing.Color.Maroon;
            }
            if (colorBox.SelectedItem == "Red")
            {
                colorView.BackColor = System.Drawing.Color.Red;
            }
            if (colorBox.SelectedItem == "Purple")
            {
                colorView.BackColor = System.Drawing.Color.Purple;
            }
            if (colorBox.SelectedItem == "Magenta")
            {
                colorView.BackColor = System.Drawing.Color.Magenta;
            }
            if (colorBox.SelectedItem == "Olive")
            {
                colorView.BackColor = System.Drawing.Color.Olive;
            }
            if (colorBox.SelectedItem == "Yellow")
            {
                colorView.BackColor = System.Drawing.Color.Yellow;
            }
            if (colorBox.SelectedItem == "Silver")
            {
                colorView.BackColor = System.Drawing.Color.Silver;
            }
            if (colorBox.SelectedItem == "White")
            {
                colorView.BackColor = System.Drawing.Color.White;
            }
        }
        #endregion

        public void Save()
        {         
            #region xmlwriter

            if(File.Exists("HelperBot.xml"))
            {
                File.Delete("HelperBot.xml");
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            //Will create a new HelperBot.xml
            XmlWriter writer = XmlWriter.Create("HelperBot.xml", settings);
            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by HelperBot.");
            writer.WriteStartElement("HelperBotConfig");
            writer.WriteStartElement("AnnounceFly");
            writer.WriteAttributeString("value", xFly.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceServer");
            writer.WriteAttributeString("value", xServer.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceHours");
            writer.WriteAttributeString("value", xHours.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceRank");
            writer.WriteAttributeString("value", xRank.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceWarnKick");
            writer.WriteAttributeString("value", xWarnKick.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceWarnSwear");
            writer.WriteAttributeString("value", xWarnSwear.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceSuggestBan");
            writer.WriteAttributeString("value", xSuggestBan.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceImpersonation");
            writer.WriteAttributeString("value", xImpersonation.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceTime");
            writer.WriteAttributeString("value", xTime.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceRandomMessages");
            writer.WriteAttributeString("value", xRandom.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnouncePM");
            writer.WriteAttributeString("value", xPM.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceFell");
            writer.WriteAttributeString("value", xFell.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceSpleefTimer");
            writer.WriteAttributeString("value", xSpleef.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceGreeting");
            writer.WriteAttributeString("value", xGreeting.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceDemoted");
            writer.WriteAttributeString("value", xDemoted.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceCaps");
            writer.WriteAttributeString("value", xCaps.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("AnnounceJokes");
            writer.WriteAttributeString("value", xJokes.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("BotName");
            writer.WriteAttributeString("value", nameBox.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Website");
            writer.WriteAttributeString("value", webBox.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("BotColor");
            writer.WriteAttributeString("value", colorBox.SelectedItem.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("CurrentVersion");
            writer.WriteAttributeString("value", "1");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            #endregion
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Save();
            Application.Exit();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void bCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Helperbot was created and developed by Jonty800 and LeChosenOne for the use of the 800Craft and LegendCraft softwares." + 
                " Helperbot is made open sourced in the hopes that others will benefit from both the program and the code. \r\n \r\n And thank you for using HelperBot!");             
        }

        private void bWiki_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/Jonty800/HelperBot/wiki");
            }
            catch { }
        }

               
    }
}
