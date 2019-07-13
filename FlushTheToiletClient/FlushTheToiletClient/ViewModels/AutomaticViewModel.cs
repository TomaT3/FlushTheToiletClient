using FlushTheToiletClient.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace FlushTheToiletClient.ViewModels
{
    public class AutomaticViewModel : BaseViewModel
    {
        private bool mStopTimer;
        private FlusherStateMachineStatusModel mFlusherStateMachineStatus;
        public FlusherStateMachineStatusModel FlusherStateMachineStatus
        {
            get { return mFlusherStateMachineStatus; }
            set { SetProperty(ref mFlusherStateMachineStatus, value); }
        }

        public AutomaticViewModel()
        {
            Title = "Automatic";

            StartFlusherAutomaticCommand = new Command(() => ExecuteStartFlusherAutomaticCommand());
            StopFlusherAutomaticCommand = new Command(() => ExecuteStopFlusherAutomaticCommand());

        }

        public ICommand StartFlusherAutomaticCommand { get; }
        public ICommand StopFlusherAutomaticCommand { get; }

        private async Task ExecuteStartFlusherAutomaticCommand()
        {
            mStopTimer = false;
            FlushTheToiletWebClientAccess.StartFlusherStateMachine();
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () => GetFlusherStateMachineStatus());
        }

        private async Task ExecuteStopFlusherAutomaticCommand()
        {
            mStopTimer = true;
            FlushTheToiletWebClientAccess.StopFlusherStateMachine();
        }

        private bool GetFlusherStateMachineStatus()
        {
            FlusherStateMachineStatus = FlushTheToiletWebClientAccess.GetFlusherStateMachineStatus();
            return !mStopTimer;
        }
    }
}