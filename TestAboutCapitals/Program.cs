using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Media;
using System.Threading;
using System.Windows.Controls;
using System.IO;

namespace TestAboutCapitals
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Initialize());
        }
        
        //Database Data
        public static List<int> AllIDsCountries = new List<int>();
        public static List<string> AllCountries = new List<string>();
        public static List<string> AllCapitals = new List<string>();

        public static List<int> AllIDsScoreboard = new List<int>();
        public static List<string> AllUserScoreboard = new List<string>();        
        public static List<int> AllScoreScoreboard = new List<int>();
        public static List<int> AllGameModesScoreboard = new List<int>();
        public static List<DateTime> AllEntryDatesScoreboard = new List<DateTime>();

        public static List<string> BestUserName10 = new List<string>();
        public static List<int> BestScore10 = new List<int>();
        public static List<string> BestUserName20 = new List<string>();
        public static List<int> BestScore20 = new List<int>();
        public static List<string> BestUserName30 = new List<string>();
        public static List<int> BestScore30 = new List<int>();

        //Operational Data

        public static List<int> RandomOrder = new List<int>();
        public static List<string> FourCountries = new List<string>();
        public static List<string> FourCapitals = new List<string>();
        public static List<int> RandomIDs = new List<int>();
        public static List<int> AlreadyCountries = new List<int>();

        public static int GameMode;
        public const int PointsEveryCorrectAnswer = 100;
        public static int currentMultiplicator = 0;
        public const int additionalMultiplicator = 1;
        public static int ActualScore;
        public static int TriesLeft;
        public static int NumTotalCountriesDataBase = 196;
        public static int QuestionNum = 1;
        public static bool buttonReady = true;
        public static int maximumTimerBar = 1000;
        public static MediaElement mediaElement;
        public static MediaElement mediaSound;
        public static bool closeRules = true;
        public static int waitTimeAfterAnswer = 1250;
        public static bool isPrimeMusicOn = false;
        public static int numOfRegisteredCountries = 196;
        public static bool alreadyRetrievedCapitals = false;
        public static bool muteMusic = false;
        public static bool soundControl = false;
        public static double volumeMusic = 0.5;
        public static double recoveryVolumeMusic = 0;

        public static void playSimpleSound(string file, double volume)
        {
            if (String.IsNullOrEmpty(file))
            {
                mediaSound = null;
            }
            else
            {
                mediaSound = new MediaElement();
                mediaSound.LoadedBehavior = MediaState.Manual;
                mediaSound.UnloadedBehavior = MediaState.Manual;
                string directory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"TestAboutCapitals\\"));
                mediaSound.Source = new Uri(directory + file, UriKind.Absolute);
                
                if (soundControl == false)
                {
                    mediaSound.Volume = volume;
                }
                else
                {
                    mediaSound.Volume = 0;
                }
                mediaSound.Play();
                mediaSound.SpeedRatio = 1;
            }
        }

        public static void SetStartMedia(string file, double volume)
        {
            if (String.IsNullOrEmpty(file))
            {
                mediaElement = null;
            }                
            else
            {
                mediaElement = new MediaElement();
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.UnloadedBehavior = MediaState.Manual;
                string directory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"TestAboutCapitals\\"));
                mediaElement.Source = new Uri(directory + file, UriKind.Absolute);                
                mediaElement.Volume = volume;
                mediaElement.SpeedRatio = 1;
                mediaElement.Play();
            }
        }

        public static void StopMedia()
        {
            mediaElement.Stop();
        }

        public static void DisappearTheMedia()
        {
            mediaElement.Volume -= volumeMusic/4;
            WaitSomeTimeAndUpdate(100);            
            mediaElement.Volume -= volumeMusic / 4;
            WaitSomeTimeAndUpdate(100);
            mediaElement.Volume -= volumeMusic / 2;
        }

        public static void MuteMedia()
        {
            recoveryVolumeMusic = volumeMusic;
            mediaElement.Volume = 0;
            muteMusic = true;
            soundControl = true;
        }

        public static void UnmuteMedia()
        {
            mediaElement.Volume = recoveryVolumeMusic;
            muteMusic = false;
            soundControl = false;
        }

        public static void PauseMedia()
        {
            mediaElement.Pause();
        }

        public static void UnpauseMedia()
        {
            mediaElement.Play();
        }

        public static void ChangeSourceMusic(string file)
        {
            string directory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"TestAboutCapitals\\"));
            mediaElement.Source = new Uri(directory + file, UriKind.Absolute);
        }

        public static void WaitSomeTimeAndUpdate(int milliseconds)
        {
            buttonReady = false;
            Thread.Sleep(milliseconds);
            System.Windows.Forms.Application.DoEvents();
            buttonReady = true;
        }
    }
}
