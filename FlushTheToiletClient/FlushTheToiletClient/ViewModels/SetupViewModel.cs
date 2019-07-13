using System.Threading.Tasks;
using Xamarin.Forms;


namespace FlushTheToiletClient.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        private double distance;
        public double Distance
        {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }
        public Command MotorForwardCommand { get; set; }
        public Command MotorBackwardCommand { get; set; }
        public Command StopMotorCommand { get; set; }
        public Command GetDistanceCommand { get; set; }
        public Command LedOnCommand { get; set; }
        public Command LedOffCommand { get; set; }

        public SetupViewModel()
        {
            Title = "Setup";
            MotorForwardCommand = new Command(async () => await ExecuteMotorForwardCommand());
            MotorBackwardCommand = new Command(async () => await ExecuteMotorBackwardCommand());
            StopMotorCommand = new Command(async () => await ExecuteStopMotorCommand());
            GetDistanceCommand = new Command(async () => await ExecuteGetDistanceCommand());
            LedOnCommand = new Command(async (led) => await ExecuteLedOnCommand(led));
            LedOffCommand = new Command(async (led) => await ExecuteLedOffCommand(led));
        }

        async Task ExecuteLedOnCommand(object led)
        {
            string ledCommand = led as string;
            switch(ledCommand.ToLower())
            {
                case "all":
                    FlushTheToiletWebClientAccess.AllLedsOnAsync();
                    break;
                case "red":
                    FlushTheToiletWebClientAccess.LedRedOnAsync();
                    break;
                case "yellow":
                    FlushTheToiletWebClientAccess.LedYellowOnAsync();
                    break;
                case "green":
                    FlushTheToiletWebClientAccess.LedGreenOnAsync();
                    break;
                default:
                    break;
            }
        }

        async Task ExecuteLedOffCommand(object led)
        {
            string ledCommand = led as string;
            switch (ledCommand.ToLower())
            {
                case "all":
                    FlushTheToiletWebClientAccess.AllLedsOffAsync();
                    break;
                case "red":
                    FlushTheToiletWebClientAccess.LedRedOffAsync();
                    break;
                case "yellow":
                    FlushTheToiletWebClientAccess.LedYellowOffAsync();
                    break;
                case "green":
                    FlushTheToiletWebClientAccess.LedGreenOffAsync();
                    break;
                default:
                    break;
            }
        }

        async Task ExecuteMotorForwardCommand()
        {
            FlushTheToiletWebClientAccess.MotorForwardAsync();
        }

        async Task ExecuteMotorBackwardCommand()
        {
            FlushTheToiletWebClientAccess.MotorBackwardAsync();
        }

        async Task ExecuteStopMotorCommand()
        {
            FlushTheToiletWebClientAccess.MotorStopAsync();
        }

        async Task ExecuteGetDistanceCommand()
        {
            Distance = FlushTheToiletWebClientAccess.GetDistance();
        }
    }
}