using System;
using System.Media;

namespace FSM_Games.SwitchLocks.Client
{
    public static class MediaPlayer
    {
        public static void BeginPlaySound(int resourceId)
        {
            string resourceName;
            switch (resourceId)
            {
                case 101:
                    resourceName = "FSM_Games.SwitchLocks.Client.Resources.Sounds.CellSwitch.wav";
                    break;
                case 102:
                    resourceName = "FSM_Games.SwitchLocks.Client.Resources.Sounds.LockSwitch.wav";
                    break;
                default:
                    throw new ArgumentException($"Unknown {nameof(resourceId)}! (Value=[{resourceId}])");
            }
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceStream = executingAssembly.GetManifestResourceStream(resourceName);
            var soundPlayer = new SoundPlayer(resourceStream);
            soundPlayer.PlaySync();
        }
    }
}