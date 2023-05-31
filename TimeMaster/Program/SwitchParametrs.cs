using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMaster.Program
{
    public static class SwitchParametrs
    {
        static string _startSound = "start.wav";
        static string _stopSound = "stop.wav";

        public static event Action<string> ButtonNameChanged;

        public static string ButtonName { get; set; }
        public static int RangeValue { get; set; } = 0;
        public static bool SoundValue { get; set; } = true;

        private static Firewall _firewall;
        public static void Initialize(Firewall firewall)=> _firewall = firewall;

        public static void SoundPlay()
        {
            if(!SoundValue) return;
            string sound = _firewall.status ? _stopSound : _startSound;
            var player = new System.Media.SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "Materials", sound));
            player.Play();
        }

        public static void UpdateButtonName()
        {
            ButtonName = _firewall.status ? "Turn OFF" : "Turn ON";
            ButtonNameChanged?.Invoke(ButtonName);
        }

        public static void Timer()
        {
            if(RangeValue != 0)
            Task.Run(async () =>
            {
                await Task.Delay(RangeValue*1000);
                if(_firewall.status != false)
                {
                    _firewall.SwitchRule(true);
                    SoundPlay();
                    UpdateButtonName();
                }
            });

        }

    }

}
