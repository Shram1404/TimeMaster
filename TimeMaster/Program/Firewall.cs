using System.Diagnostics;
using TimeMaster.Program;

namespace TimeMaster
{
    public class Firewall
    {
        public bool status = false;
        private string _ruleName;

        public Firewall(string ruleName)
        {
            _ruleName = ruleName;

            string parameters = @"/c netsh advfirewall firewall set rule name=" + '\u0022' + _ruleName + '\u0022' + " new enable=no";

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd";
            info.Verb = "runas";
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.Arguments = String.Format(parameters);

            Process.Start(info);
        }

        public void SwitchRule()
        {
            string parameters = @"/c netsh advfirewall firewall set rule name=" + '\u0022' + _ruleName + '\u0022' + " new enable=" + (status ? "no" : "yes");
            status = !status;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd";
            info.Verb = "runas";
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.Arguments = String.Format(parameters);

            Process.Start(info);
        }
        public void SwitchRule(bool newStatus)
        {
            string parameters = @"/c netsh advfirewall firewall set rule name=" + '\u0022' + _ruleName + '\u0022' + " new enable=" + (newStatus ? "no" : "yes");
            status = !newStatus;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd";
            info.Verb = "runas";
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.Arguments = String.Format(parameters);

            Process.Start(info);
        }


    }
}
