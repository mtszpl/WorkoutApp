namespace WorkoutApp2.Client.Utility
{
    public class Clock
    {

        public static async void StartClock(int time, Action<int>? onTick = null, Action? onEnd = null)
        {
            int timeRemaining = time;
            while (timeRemaining-- > 0) 
            {
                await Task.Delay(1000);
                onTick?.Invoke(timeRemaining);
            }

            onEnd?.Invoke();
        }
    }
}
