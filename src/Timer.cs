namespace Snake
{
    public class Timer
    {
        public bool Run;
        private double Accel;
        private double MinFreq;
        private DateTime Begin;

        public Timer()
        {
            Accel = 0.2;
            MinFreq = 1.0;
            Run = true;
            Begin = DateTime.Now;

        }

        public void Wait()
        {
            double begin_s = (double)(DateTime.Now - Begin).TotalSeconds;
            double freq = Math.Max(begin_s * Accel, MinFreq);
            double period_ms = (1.0 / freq) * 1000.0;
            Thread.Sleep((int)period_ms);
        }
    }
}
