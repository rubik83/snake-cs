namespace snake_cs
{
    internal sealed class Timer
    {
        private readonly CancellationTokenSource _cancellation;
        private readonly double _accel;
        private readonly double _minFreq;
        private readonly DateTime _begin;
        internal bool IsRunning => !_cancellation.IsCancellationRequested;
        internal void Cancel()
        {
            _cancellation.Cancel();
        }

        internal Timer()
        {
            _cancellation = new CancellationTokenSource();
            _accel = 0.2;
            _minFreq = 1.0;
            _begin = DateTime.Now;
        }

        public async Task Wait()
        {
            var beginS = (DateTime.Now - _begin).TotalSeconds;
            var freq = Math.Max(beginS * _accel, _minFreq);
            var periodMs = (1.0 / freq) * 1000.0;
            await Task.Delay((int)periodMs, _cancellation.Token);
        }
    }
}
