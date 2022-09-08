namespace snake_cs
{
    public class Timer
    {
        public bool Run;
        private readonly double _accel;
        private readonly double _minFreq;
        private readonly DateTime _begin;

        public Timer()
        {
            _accel = 0.2;
            _minFreq = 1.0;
            Run = true;
            _begin = DateTime.Now;

        }

        public void Wait()
        {
            var beginS = (DateTime.Now - _begin).TotalSeconds;
            var freq = Math.Max(beginS * _accel, _minFreq);
            var periodMs = (1.0 / freq) * 1000.0;
            Thread.Sleep((int)periodMs);
        }
    }
}
