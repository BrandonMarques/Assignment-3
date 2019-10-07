using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace brandonMiranda_17610437
{
    public partial class Form1 : Form
    {
        public int x, y;
        GameEngine engine;
        Timer timer;
        Gamestate gameState = Gamestate.PAUSED;
        public Form1()
        {
            InitializeComponent();
            engine = new GameEngine();
            UpdateUI();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            engine.GameLoop();
            UpdateUI();

            if (engine.IsGameOver)
            {
                timer.Stop();
                UpdateUI();
                lblMap.Text = engine.WinningFaction + "WON! \n" + lblMap.Text;
                    gameState = Gamestate.ENDED;
                btnStartPause.Text = "Restart";
            }
        }

        private void UpdateUI()
        {
            lblMap.Text = engine.MapDisplay;
            lblRound.Text = "Round: " + engine.Round;
            tbxUnitInfo.Text = engine.GetUnitInfo();
            rtbBuildingsInfo.Text = engine.GetBuildingsInfo();
            lblUnits.Text = "Units (" + engine.NumUnits + ")";
            lblBuildings.Text = "Buildings (" + engine.NumBuildings + ")";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            engine = new GameEngine(x,y);
            if (gameState == Gamestate.RUNNING)
            {
                timer.Stop();
                gameState = Gamestate.PAUSED;
                btnStartPause.Text = "Start";
            }
            else
            {
                if (gameState == Gamestate.ENDED)
                {
                    engine.Reset();

                }
                timer.Start();
                gameState = Gamestate.RUNNING;
                btnStartPause.Text = "PAUSE";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.SaveGame();
            lblMap.Text = "Game Saved \n" + lblMap.Text;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            engine.LoadGame();
            lblMap.Text = "Game Loaded \n" + engine.MapDisplay;
        }

        private void rtbBuildingsInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYLength_TextChanged(object sender, EventArgs e)
        {
            string temp = txtYLength.Text;
            y = Convert.ToInt32(temp);
            

        }

        private void txtXLength_TextChanged(object sender, EventArgs e)
        {
            string temp = txtXLength.Text;
            x = Convert.ToInt32(temp);
        }
    }
    public enum Gamestate
    {
        RUNNING,
        PAUSED,
        ENDED
    }
}
