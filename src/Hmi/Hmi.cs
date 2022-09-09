namespace snake_cs.Hmi;

internal interface IHmi
{
    Board Board { get; }
    Direction Direction { get; }
    void NextDirection();
}
