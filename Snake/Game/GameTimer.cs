

namespace Snake.Game
{
    public class GameTimer
    {
        public bool _isPaused;
        private Timer _timer;
        private readonly TimeSpan _timeout;
        private readonly Action[] _TimerListeners;

        public GameTimer(TimeSpan timeout, params Action[] TimerListeners)
        {
            _timeout = timeout;
            _TimerListeners = TimerListeners;
            _timer = new Timer(OnTimer);

            if (TimerListeners.Length > 0)
            {
                _timer.Change(_timeout, Timeout.InfiniteTimeSpan);
            }
        }

        private void OnTimer(object? state)
        {
            foreach (var listener in _TimerListeners)
            {
                if (_isPaused)
                {
                    continue;
                }

                listener();
            }

            _timer.Change(_timeout, Timeout.InfiniteTimeSpan);      
        }
        
        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}
