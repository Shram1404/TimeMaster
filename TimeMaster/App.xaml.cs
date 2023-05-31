using TimeMaster.Data;
using TimeMaster.Program;

namespace TimeMaster
{
    public partial class App : Application
    {
        public delegate void HookMethod();
        public HookMethod myDelegate;

        private readonly Firewall _firewall;

        public App(Firewall firewall)
        {
            InitializeComponent();
            MainPage = new MainPage();
            _firewall = firewall;

            SwitchParametrs.Initialize(_firewall);
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 520;
            const int newHeight = 160;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
        protected override void OnStart()
        {
            base.OnStart();
            this.MainPage.Window.Destroying += Window_Destroying;

            myDelegate = () => Switch();

            KeyboardHook.StartHook(myDelegate);
        }

        public void Switch()
        {
            _firewall.SwitchRule();
            SwitchParametrs.SoundPlay();
            SwitchParametrs.UpdateButtonName();
            SwitchParametrs.Timer();
        }

        private void Window_Destroying(object sender, EventArgs e)
        {
            KeyboardHook.StopHook();
        }
    }
}
