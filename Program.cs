using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

using Busylight;

namespace BusyLightDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            return Dialog.ShowDialog(Routine.BaseRoutines);
        }
    }

    public static class Dialog
    {
        public static int ShowDialog(List<Routine> routines)
        {
            string prompt = BuildOptionsPrompt(routines);

            string input = "";
            while (true)
            {
                Console.WriteLine(prompt);

                input = Console.ReadLine();

                try
                {
                    var selection = int.Parse(input, NumberStyles.Integer);
                    if (selection > routines.Count + 1)
                    {
                        throw new Exception();
                    }

                    if (selection == routines.Count + 1)
                    {
                        return 1;
                    }

                    routines[selection - 1].Action.Invoke();
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }

        public static string BuildOptionsPrompt(List<Routine> routines)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < routines.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(routines[i].Description))
                {
                    sb.AppendLine(string.Format("{0}. {1}", i + 1, routines[i].Name));
                }
                else
                {
                    sb.AppendLine(string.Format("{0}. {1} - {2}", i + 1, routines[i].Name, routines[i].Description));
                }
            }

            sb.AppendLine(string.Format("{0}. Exit", routines.Count + 1));

            return sb.ToString();
        }
    }


    public class Routine
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public action Action { get; set; }

        public delegate void action();

        public Routine() { }

        private static readonly SDK sdk = new SDK();

        #region Dialogs

        public static action TestSoundClips = () =>
        {
            Dialog.ShowDialog(SoundClipRoutines);
        };

        public static action TestVolumes = () =>
        {
            Dialog.ShowDialog(VolumeRoutines);
        };

        public static action TestColors = () =>
        {
            Dialog.ShowDialog(ColorRoutines);
        };

        #endregion

        #region Volume Routines

        public static action AlertMute = () =>
        {
            Routine.alert(BusylightColor.Blue, volume: BusylightVolume.Mute);
        };

        public static action AlertLow = () =>
        {
            Routine.alert(BusylightColor.Blue, volume: BusylightVolume.Low);
        };

        public static action AlertMiddle = () =>
        {
            Routine.alert(BusylightColor.Blue, volume: BusylightVolume.Middle);
        };

        public static action AlertHigh = () =>
        {
            Routine.alert(BusylightColor.Blue, volume: BusylightVolume.High);
        };

        public static action AlertMax = () =>
        {
            Routine.alert(BusylightColor.Blue, volume: BusylightVolume.Max);
        };

        #endregion

        #region SoundClip Routines

        public static action SoundClipFairyTale = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.FairyTale);
        };

        public static action SoundClipFunky = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.Funky);
        };

        public static action SoundClipKuandoTrain = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.KuandoTrain);
        };

        public static action SoundClipOpenOffice = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.OpenOffice);
        };

        public static action SoundClipTelephoneNordic = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.TelephoneNordic);
        };

        public static action SoundClipTelephonePickMeUp = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.TelephonePickMeUp);
        };

        public static action SoundClipQuiet = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.Quiet);
        };

        public static action SoundClipIM1 = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.IM1);
        };

        public static action SoundClipIM2 = () =>
        {
            Routine.alert(BusylightColor.Blue, sound: BusylightSoundClip.IM2);
        };

        #endregion

        #region Color Routines

        public static action ColorRed = () =>
        {
            sdk.Blink(BusylightColor.Red, 30, 15);
        };

        public static action ColorBlue = () =>
        {
            sdk.Blink(BusylightColor.Blue, 30, 15);
        };

        public static action ColorGreen = () =>
        {
            sdk.Blink(BusylightColor.Green, 30, 15);
        };

        public static action ColorYellow = () =>
        {
            sdk.Blink(BusylightColor.Yellow, 30, 15);
        };

        public static action ColorOff = () =>
        {
            sdk.Blink(BusylightColor.Off, 30, 15);
        };

        #endregion

        #region Base routines

        public static action Alert = () =>
        {
            Routine.alert(BusylightColor.Red);
        };

        public static action AlertAndReturn = () =>
        {
            sdk.AlertAndReturn(BusylightColor.Red, BusylightSoundClip.FairyTale, BusylightVolume.Middle);
        };

        public static action Blink = () =>
        {
            sdk.Blink(BusylightColor.Blue, 2, 1);
        };

        public static action ColorWithFlash = () =>
        {
            sdk.ColorWithFlash(BusylightColor.Blue, BusylightColor.Yellow);
        };

        public static action Jingle1 = () =>
        {
            sdk.Jingle(BusylightColor.Blue, BusylightJingleClip.IM1, BusylightVolume.Middle);
        };

        public static action Jingle2 = () =>
        {
            sdk.Jingle(BusylightColor.Blue, BusylightJingleClip.IM2, BusylightVolume.Middle);
        };

        public static action Light = () =>
        {
            sdk.Light(BusylightColor.Blue);
        };

        public static action LightOff = () =>
        {
            sdk.Light(BusylightColor.Off);
        };

        public static action Pulse = () =>
        {
            sdk.Pulse(BusylightColor.Blue);
        };

        public static action Terminate = () =>
        {
            sdk.Terminate();
        };

        #endregion

        #region Helper Methods

        private static void alert(BusylightColor color, BusylightSoundClip sound = BusylightSoundClip.FairyTale, BusylightVolume volume = BusylightVolume.Middle)
        {
            sdk.Light(BusylightColor.Off);
            sdk.Alert(color, sound, volume);
        }

        #endregion

        #region Routine Lists

        public static List<Routine> BaseRoutines = new List<Routine>
        {
            new Routine(){ Name = "Light Off", Description = "Turn the light off, stops any sounds, alerts, or other actions", Action = Routine.LightOff },
            new Routine(){ Name = "Light", Description = "Set the light to a chosen color.", Action = Routine.Light },
            new Routine(){ Name = "Blink", Description = "Blink the light at a chosen period", Action = Routine.Blink},
            new Routine(){ Name = "ColorWithFlash", Description = "Set the light to a primary color with brief flashes of a second color", Action = Routine.ColorWithFlash },
            new Routine(){ Name = "Pulse", Description = "Pulse the light with different levels of brightness for one color", Action = Routine.Pulse},
            new Routine(){ Name = "Alert", Description = "Blink a color while a sound clip repeats", Action = Routine.Alert },
            new Routine(){ Name = "AlertAndReturn", Description = "Same as alert, but always blue", Action = Routine.AlertAndReturn },
            new Routine(){ Name = "Jingle IM1", Description = "Play a short sound", Action = Routine.Jingle1 },
            new Routine() {Name = "Test Sound Clips", Action = Routine.TestSoundClips },
            new Routine() {Name = "Test Volumes", Action = Routine.TestVolumes },
            new Routine() {Name = "Test Colors", Action = Routine.TestColors },
            new Routine(){ Name = "Terminate", Description = "Stop current action and kill the SDK. A new SDK object must be constructed to resume. Light.Off would be better.", Action = Routine.Terminate },
        };

        public static List<Routine> VolumeRoutines = new List<Routine>
        {
            new Routine(){ Name = "Alert Mute", Action = Routine.AlertMute },
            new Routine(){ Name = "Alert Low", Action = Routine.AlertLow },
            new Routine(){ Name = "Alert Middle", Action = Routine.AlertMiddle },
            new Routine(){ Name = "Alert High", Action = Routine.AlertHigh },
            new Routine(){ Name = "Alert Max", Action = Routine.AlertMax },
        };

        public static List<Routine> ColorRoutines = new List<Routine>
        {
            new Routine(){ Name = "Blue", Action = Routine.ColorBlue },
            new Routine(){ Name = "Green", Action = Routine.ColorGreen },
            new Routine(){ Name = "Red", Action = Routine.ColorRed },
            new Routine(){ Name = "Yellow", Action = Routine.ColorYellow },
            new Routine(){ Name = "Off", Action = Routine.ColorOff },
        };

        public static List<Routine> SoundClipRoutines = new List<Routine>
        {
            new Routine(){ Name = "Fairy Tale", Action = Routine.SoundClipFairyTale },
            new Routine(){ Name = "Funky", Action = Routine.SoundClipFunky },
            new Routine(){ Name = "Kuando Train", Action = Routine.SoundClipKuandoTrain },
            new Routine(){ Name = "Open Office", Action = Routine.SoundClipOpenOffice },
            new Routine(){ Name = "Telephone Nordic", Action = Routine.SoundClipTelephoneNordic },
            new Routine(){ Name = "Telephone PickMeUp", Action = Routine.SoundClipTelephonePickMeUp },
            new Routine(){ Name = "IM1", Action = Routine.SoundClipIM1 },
            new Routine(){ Name = "IM2", Action = Routine.SoundClipIM2 },
            new Routine(){ Name = "Quiet", Action = Routine.SoundClipQuiet }
        };

        #endregion
    }
}
