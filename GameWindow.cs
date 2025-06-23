//#define My_DEBUG

using RockShooter2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using System.IO;

namespace RockShooter2
{
    public partial class GameWindow : Form
    {
        // Game controllers
        /// <summary> the multiplier of game speed </summary>
        public static float gameSpeed = 1;
        /// <summary> max amount of rocks spawn when there are spawning</summary>
        public static int spawnRate = 2;
        /// <summary> current max valuable of spawning rockes</summary>
        public static int valuableRockIndex;
        /// <summary> max period of time for spawn next rocks</summary>
        public static int spawnTime;
        public static ELevelDifficults levelDifficult;

        public static bool isGameStopped = false;
        public static bool isGameStarted = false;

        // Counters
        /// <summary> </summary>
        int nextSpawnTime = 1;
        long lastScoreUpdate = 0;
        long lastDifficultUpdate = 0;
        int spawnedRocks = 0;
        int shotedStots = 0;
        int destroyedRocks = 0;
        int collectedBonuses = 0;
        int missedShots = 0;

#if My_DEBUG
        int fpsCounter = 0;
#endif

        // Default
        int defaultRockSpeed = 5;
        int defaultBonusSpeed = 7;
        int defaultShotSpeed = 10;
        int defaultSpaceShitSpeed = 10;
        int defaultLive = 5;
        int defaultBonusValuableMultiplier = 6;
        float defaultDeltaSpeedGame = 0.002f;


        // Required objects
        public SpaceShip spaceShip;
        Font font;
        public static Random random = new Random();
        Stopwatch timeCounter = new Stopwatch();
        Stopwatch frameTimeCounter = new Stopwatch();
        StreamWriter streamWriter;
        StreamReader streamReader;

        // Lists of objects
        public List<Rock> rockList = new List<Rock>();
        public List<Shot> shotList = new List<Shot>();
        public List<Bonus> bonusList = new List<Bonus>();

        // Informaction objects
        internal GameObject informationBar;
        internal GameObject healthBar;

        // Is key pressed
        bool _leftClick = false;
        bool _rightClick = false;

        // Game real time variable
        public int score;
        public int shotAmount;
        /// <summary>from 0 to 700 range</summary>
        public int health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 600)
                {
                    _health = 600;
                }
                else
                {
                    _health = value;
                }
            }
        }
        int _health;



        //Music
        SoundPlayer mLaserGun = new SoundPlayer(Resources.MLaserGun);
        SoundPlayer mExplosion = new SoundPlayer(Resources.MExplosion);
        SoundPlayer mClickButton = new SoundPlayer(Resources.MClickButton);
        SoundPlayer mCollectBonus = new SoundPlayer(Resources.MCollectBonus);
        SoundPlayer mGameOver = new SoundPlayer(Resources.MGameOver);



        public GameWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            MainLabel.Parent = StopWindow;
            InformationLabel.Parent = StopWindow;
            QuitButton.Parent = StopWindow;
            ResumeButton.Parent = StopWindow;

            informationBar = new GameObject(Resources.InformactionBar);
            informationBar.position[0] = 0;
            informationBar.position[1] = 0;
            informationBar.size[0] = 740;
            informationBar.size[1] = 150;

            healthBar = new GameObject(Resources.LiveBar);
            healthBar.position[0] = 0;
            healthBar.position[1] = 0;
            healthBar.size[0] = 1400;
            healthBar.size[1] = 50;

            font = new Font("arial", 16);
            spawnTime = 1000 / timer.Interval;

            // Start playing background music in media player
            MediaPlayer.URL = "Background.mp3";
            MediaPlayer.settings.playCount = 9999;

            // Create a ranking file if it doesn`t exist
            if (!File.Exists("ranking.txt"))
                File.Create("ranking.txt");
        }


        /// <summary>
        /// Show everything on screen
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (isGameStarted)
            {
                Graphics graphics = e.Graphics;

                foreach (Rock rock in rockList)
                {
                    rock.DrawImage(graphics);
                }
                foreach (Bonus bonus in bonusList)
                {
                    bonus.DrawImage(graphics);
                }
                foreach (Shot shot in shotList)
                {
                    shot.DrawImage(graphics);
                }


                healthBar.position[0] = health - 650;
                healthBar.DrawImage(graphics);
                informationBar.DrawImage(graphics);

                spaceShip.DrawImage(graphics);

                TextRenderer.DrawText(graphics, "SHOTS", font, new Point(7, 20), Color.White);
                TextRenderer.DrawText(graphics, shotAmount.ToString(), font, new Rectangle(7, 50, 80, 50), Color.White, TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(graphics, "SCORE", font, new Point(642, 20), Color.White);
                TextRenderer.DrawText(graphics, score.ToString(), font, new Rectangle(642, 50, 80, 50), Color.White, TextFormatFlags.HorizontalCenter);

#if My_DEBUG
                    TextRenderer.DrawText(graphics, "FPS: " + fpsCounter.ToString(), font, new Point(350, 100), Color.White);

#endif
            }
            base.OnPaint(e);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
#if My_DEBUG
            Console.WriteLine(DateTime.Now.ToString());

#endif
        }



        /// <summary>
        /// Update in every frame
        /// </summary>
        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (!isGameStopped && isGameStarted)
            {
                // move all rocks and detect collision
                for (int r = 0; r < rockList.Count; r++)
                {
                    Rock rock = rockList[r];
                    rock.Move(0, (int)(gameSpeed * defaultRockSpeed));

                    // detect collision with spaceship
                    if (spaceShip.HitboxCollision(rock.hitbox))
                    {
                        mExplosion.Play();

                        if (rock.valuable > 0)
                            shotAmount += random.Next(1, rock.valuable * defaultBonusValuableMultiplier);
                        rockList.RemoveAt(r);
                        rock.Dispose();

                        health -= 600 / defaultLive;
                        if (health == 0)
                            GameOver();

                        destroyedRocks++;
                    }
                    // if rock is under a screen remove it
                    if (rock.position[1] > 1200)
                    {
                        rockList.RemoveAt(r);
                        rock.Dispose();
                    }
                }


                // move bonuses and detect collision
                for (int b = 0; b < bonusList.Count; b++)
                {
                    Bonus bonus = bonusList[b];
                    bonus.Move(0, (int)(gameSpeed * defaultBonusSpeed));

                    // detect collision with spaceship
                    if (spaceShip.HitboxCollision(bonus.hitbox))
                    {
                        mCollectBonus.Play();

                        shotAmount += random.Next(1, bonus.valuable * defaultBonusValuableMultiplier);
                        bonusList.RemoveAt(b);
                        bonus.Dispose();

                        collectedBonuses++;
                    }
                    // if bonus is under a screen remove it
                    if (bonus.position[1] > 1200)
                    {
                        bonusList.RemoveAt(b);
                        bonus.Dispose();
                    }
                }


                // move shots and detect collision
                for (int s = 0; s < shotList.Count; s++)
                {
                    Shot shot = shotList[s];
                    shot.Move(0, -(int)(gameSpeed * defaultShotSpeed));

                    for (int i = 0; i < rockList.Count; i++)
                    {
                        // detect collision with rock
                        if (rockList[i].HitboxCollision(shot.hitbox))
                        {
                            shotList.RemoveAt(s);
                            shot.Dispose();

                            Rock rock = rockList[i];
                            // instantiate bonus if it is necessary
                            if (rock.valuable > 0)
                            {
                                Bonus bonus = new Bonus(rock.valuable, rock.position);
                                bonusList.Add(bonus);
                            }
                            score += rock.valuable + 1;

                            rockList.RemoveAt(i);
                            rock.Dispose();

                            destroyedRocks++;

                            break;
                        }
                    }
                    // if bonus is under a screen remove it
                    if (shot.position[1] < -100)
                    {
                        shotList.RemoveAt(s);
                        shot.Dispose();

                        missedShots++;
                    }

                }


                // Generate new rocks
                if (nextSpawnTime == 0)
                {
                    // create new objects
                    int r = random.Next(0, spawnRate);
                    spawnedRocks += r;

                    for (int i = 0; i < r; i++)
                    {
                        Rock rock = new Rock();
                        rockList.Add(rock);
                    }

                    // set spawn time for next rock generation
                    if ((int)((1 / gameSpeed) * spawnTime) < 1)
                        nextSpawnTime = 1;
                    else
                        nextSpawnTime = random.Next(1, (int)((1 / gameSpeed) * spawnTime));
                }
                nextSpawnTime -= 1;


                frameTimeCounter.Stop();
#if My_DEBUG
                try
                {
                    fpsCounter = (int)(1000 / frameTimeCounter.ElapsedMilliseconds);
                }
                catch (DivideByZeroException) { }

#endif


                // Change a score and update game difficult
                lastScoreUpdate += frameTimeCounter.ElapsedMilliseconds;
                lastDifficultUpdate += frameTimeCounter.ElapsedMilliseconds;

                frameTimeCounter.Restart();

                if (lastScoreUpdate > 500)
                {
                    score++;
                    lastScoreUpdate = 0;
                }
                gameSpeed += defaultDeltaSpeedGame;
                // for every constant period of time randomly change rock generator variables
                if (lastDifficultUpdate > 5000)
                {
                    int r1 = random.Next(0, 10);
                    int r2 = random.Next(0, 10);
                    int r3 = random.Next(0, 3);

                    if (r1 == 0)
                        spawnRate++;
                    if (r2 == 0)
                        spawnTime--;
                    if (r3 == 0)
                    {
                        valuableRockIndex++;
                        if (valuableRockIndex == 4)
                            valuableRockIndex = 3;
                    }
                    lastDifficultUpdate = 0;
                }


                // Move if the keys are clicked
                if (_leftClick) spaceShip.Move(-defaultSpaceShitSpeed, 0);
                if (_rightClick) spaceShip.Move(defaultSpaceShitSpeed, 0);
            }

            Refresh();
        }



        /// <summary>
        /// Check the space key down
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isGameStarted && !isGameStopped)
            {
                if (keyData == Keys.Space)
                {
                    // if it is possible instanciate a new shot
                    if (shotAmount > 0)
                    {
                        mLaserGun.Play();

                        Shot shot = new Shot(spaceShip);
                        shotAmount -= 1;
                        shotList.Add(shot);

                        shotedStots++;
                    }
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }




        /// <summary>
        /// Check the arrow key down
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessKeyPreview(ref Message m)
        {
            int msgVal = m.WParam.ToInt32();
            if (m.Msg == 0x0100)
            {
                switch ((Keys)msgVal)
                {
                    case Keys.Left:
                        _leftClick = true;
                        break;
                    case Keys.Right:
                        _rightClick = true;
                        break;
                }
            }
            if (m.Msg == 0x0101)
            {
                switch ((Keys)msgVal)
                {
                    case Keys.Left:
                        _leftClick = false;
                        break;
                    case Keys.Right:
                        _rightClick = false;
                        break;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }



        /// <summary>
        /// Show game over panel and stop a game
        /// </summary>
        private void GameOver()
        {
            mGameOver.Play();

            isGameStopped = true;
            timeCounter.Stop();
            frameTimeCounter.Stop();

            //show all components
            StopWindow.Visible = true;
            MainLabel.Visible = true;
            InformationLabel.Visible = true;
            ResumeButton.Visible = false;
            QuitButton.Visible = true;
            PauseButton.Visible = false;

            MainLabel.Text = "GAME OVER";
            InformationLabel.Text = 
                "\nLevel difficult: " + levelDifficult.ToString().ToUpper() +
                "\nYour score: " + score.ToString() + 
                "\n\nGame time: " + (timeCounter.ElapsedMilliseconds / 1000).ToString() + " secounds" +
                "\nGame speed in last breatch " + gameSpeed.ToString() +
                "\n\nStatistics:" +
                "\nSpawned meteorities: " + spawnedRocks.ToString() +
                "\nDestroyed meteorities: " + destroyedRocks.ToString() +
                "\nShoted shots: " + shotedStots.ToString()
                ;
            try
            {
                InformationLabel.Text += "\nShots hit rate: " + (100 - ((100 * missedShots) / shotedStots)).ToString() + "%";
            }
            catch (DivideByZeroException) 
            {
                InformationLabel.Text += "\nNo hit rate to show";
            }
            InformationLabel.Text += "\nCollected bonuses: " + collectedBonuses.ToString();



            // Save the score to ranking.txt file
            streamWriter = new StreamWriter("ranking.txt", true);
            streamWriter.WriteLine(score.ToString() + " -- " + DateTime.Now + " -- " + levelDifficult.ToString());
            streamWriter.Close();

            ResetGame();
        }



        /// <summary>
        /// Reset all variables
        /// </summary>
        private void ResetGame()
        {
            // Set all variables to default values
            score = 0;
            health = 600;
            gameSpeed = 1;
            shotAmount = 5;
            lastScoreUpdate = 0;
            spawnRate = 2;
            spawnTime = 1000 / timer.Interval;
            valuableRockIndex = 0;
            levelDifficult = ELevelDifficults.None;

            spawnedRocks = 0;
            shotedStots = 0;
            destroyedRocks = 0;
            collectedBonuses = 0;
            missedShots = 0;

            timeCounter.Stop();
            timeCounter.Reset();
            frameTimeCounter.Stop();
            frameTimeCounter.Reset();

            isGameStarted = false;
            isGameStopped = false;


            // clear all objects
            foreach (Bonus bonus in bonusList)
            {
                bonus.Dispose();
            }
            foreach (Rock rock in rockList)
            {
                rock.Dispose();
            }
            foreach (Shot shot in shotList)
            {
                shot.Dispose();
            }
            bonusList = new List<Bonus>();
            rockList = new List<Rock>();
            shotList = new List<Shot>();
        }


        private void StartB_Click(object sender, EventArgs e)
        {
            mClickButton.Play();

            DifficultLevelEasyButton.Visible = true;
            DifficultLevelHardButton.Visible = true;
            DifficultLevelMediumButton.Visible = true;
            DifficultLevelImpossibleButton.Visible = true;

            StartB.Visible = false;
        }


        void StartGame(ELevelDifficults difficultLevel)
        {
            score = 0;
            health = 600;
            gameSpeed = 1;
            shotAmount = 5;
            lastScoreUpdate = 0;
            spaceShip = new SpaceShip();
            levelDifficult = difficultLevel;
            
            switch (difficultLevel)
            {
                case ELevelDifficults.Easy:
                    defaultRockSpeed = 4;
                    defaultBonusSpeed = 8;
                    defaultShotSpeed = 10;
                    defaultSpaceShitSpeed = 10;
                    defaultLive = 12;
                    defaultBonusValuableMultiplier = 8;
                    defaultDeltaSpeedGame = 0.0015f;
                    break;

                case ELevelDifficults.Medium:
                    defaultRockSpeed = 5;
                    defaultBonusSpeed = 7;
                    defaultShotSpeed = 11;
                    defaultSpaceShitSpeed = 11;
                    defaultLive = 7;
                    defaultBonusValuableMultiplier = 6;
                    defaultDeltaSpeedGame = 0.002f;
                    break;

                case ELevelDifficults.Hard:
                    defaultRockSpeed = 6;
                    defaultBonusSpeed = 8;
                    defaultShotSpeed = 14;
                    defaultSpaceShitSpeed = 12;
                    defaultLive = 5;
                    defaultBonusValuableMultiplier = 5;
                    defaultDeltaSpeedGame = 0.003f;
                    break;

                case ELevelDifficults.Impossible:
                    defaultRockSpeed = 6;
                    defaultBonusSpeed = 8;
                    defaultShotSpeed = 11;
                    defaultSpaceShitSpeed = 14;
                    defaultLive = 1;
                    defaultBonusValuableMultiplier = 4;
                    defaultDeltaSpeedGame = 0.005f;
                    break;
            }

            StartB.Visible = false;
            PauseButton.Visible = true;
            RankingButton.Visible = false;
            DifficultLevelEasyButton.Visible = false;
            DifficultLevelHardButton.Visible = false;
            DifficultLevelMediumButton.Visible = false;
            DifficultLevelImpossibleButton.Visible = false;

            isGameStarted = true;
            isGameStopped = false;

            timeCounter.Start();


        }
        private void DifficultLevelImpossibleButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();
            StartGame(ELevelDifficults.Impossible);
        }

        private void DifficultLevelHardButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();
            StartGame(ELevelDifficults.Hard);
        }

        private void DifficultLevelMediumButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();
            StartGame(ELevelDifficults.Medium);
        }

        private void DifficultLevelEasyButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();
            StartGame(ELevelDifficults.Easy);
        }



        private void PauseButton_Click(object sender, EventArgs e)
        {
            timeCounter.Stop();

            mClickButton.Play();
            isGameStopped = true;

            //show all components
            StopWindow.Visible = true;
            MainLabel.Visible = true;
            ResumeButton.Visible = true;
            QuitButton.Visible = true;

            MainLabel.Text = "GAME PAUSED";
        }



        private void PreferencesButton_Click(object sender, EventArgs e)
        {
            timeCounter.Stop();

            mClickButton.Play();
            isGameStopped = true;

            StopWindow.Visible = true;
            MainLabel.Visible = true;
            InformationLabel.Visible = true;
            StartB.Visible = false;
            if (isGameStarted)
                ResumeButton.Visible = true;
            else
                QuitButton.Visible = true;

            MainLabel.Text = "PREFERENCES";
            InformationLabel.Text = "Cooming soon!";
        }



        private void HelpButton_Click(object sender, EventArgs e)
        {
            timeCounter.Stop();

            mClickButton.Play();
            isGameStopped = true;

            StopWindow.Visible = true;
            MainLabel.Visible = true;
            InformationLabel.Visible = true;
            StartB.Visible = false;
            if (isGameStarted)
                ResumeButton.Visible = true;
            else
                QuitButton.Visible = true;


            MainLabel.Text = "HOW TO PLAY";
            InformationLabel.Text =
                "Playing is easy!" +
                "\n\nMove using left and right arrows." +
                "\nShot using space." +
                "\n\nAvoid meteorities. You can destroy them by shotting." +
                "\nIf the metorite hit you you lost your live." +
                "\nBlack meteorities isn`t valuable, for white, yellow or red you get more shots." +
                "\nYou get score points for every 0.5 secound in game and for destroying meteorities." +
                "\n\nMusic by:" +
                "\nSound Effect by UNIVERSFIELD from Pixabay" +
                "\nMusic by Dream-Protocol from Pixabay"
                ;
        }



        private void RankingButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();

            StopWindow.Visible = true;
            MainLabel.Visible = true;
            InformationLabel.Visible = true;
            QuitButton.Visible = true;
            StartB.Visible = false;
            MainLabel.Text = "RANKING";
            InformationLabel.Text = "Score -- Date -- Level difficult\n";

            // Open a file with ranking
            streamReader = File.OpenText("ranking.txt");
            string readedString = streamReader.ReadToEnd();
            streamReader.Close();


            // Move and separate data from file to list
            List<string> list = new List<string>();
            string tempString = "";

            for (int i = 0; i < readedString.Length; i++)
            {
                if (readedString[i] != '\n')
                    tempString += readedString[i].ToString();
                else
                {
                    list.Add(tempString);
                    tempString = "";
                }
            }

#if My_DEBUG
            Console.WriteLine("\n\nPobrana lista z pliku:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
#endif

            // Create list with scores and indexes this scores in list
            List<KeyValuePair<int, int>> indexList = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < list.Count; i++)
            {
                string s3 = "";
                int l = 0;
                while (list[i][l] != ' ')
                {
                    s3 += list[i][l];
                    l++;
                }
                indexList.Add(new KeyValuePair<int, int>(int.Parse(s3), i));
            }


            // Sort a indexList by score
            int n = indexList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (indexList[j].Key > indexList[j + 1].Key)
                    {
                        KeyValuePair<int, int> tempVar = indexList[j];
                        indexList[j] = indexList[j + 1];
                        indexList[j + 1] = tempVar;
                    }
                }
            }
            indexList.Reverse();


            // Create a new sorted list
#if My_DEBUG
            List<string> sortedList = new List<string>();
#endif
            for (int i = 0; i < indexList.Count; i++)
            {
#if My_DEBUG
                sortedList.Add(list[indexList[i].Value]);
#endif
                InformationLabel.Text += list[indexList[i].Value];
            }

#if My_DEBUG
            Console.WriteLine("\n\nLista wyników:");
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine(sortedList[i]);
            }
#endif




        }





        private void ResumeButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();

            StopWindow.Visible = false;
            MainLabel.Visible = false;
            InformationLabel.Visible = false;
            ResumeButton.Visible = false;
            QuitButton.Visible = false;


            isGameStopped = false;
            timeCounter.Start(); ;
        }



        private void QuitButton_Click(object sender, EventArgs e)
        {
            mClickButton.Play();

            StopWindow.Visible = false;
            MainLabel.Visible = false;
            InformationLabel.Visible = false;
            ResumeButton.Visible = false;
            QuitButton.Visible = false;
            StartB.Visible = true;
            RankingButton.Visible = true;

            ResetGame();
        }

    }
}
