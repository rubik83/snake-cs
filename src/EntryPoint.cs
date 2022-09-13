namespace snake_cs;

public static class EntryPoint
{
    public static async Task Main(string[] args)
    {
        var program = new snake_cs.Program();
        await program.Run();
    }

}
