namespace WashingMachineOOP;

class Program
{
    static void Main(string[] args)
    {
        WashingMachine washingMachine = new();
        washingMachine.Start();

        while (!washingMachine.IsIdle())
        {
            washingMachine.Operate();
            Thread.Sleep(1000); // Wait for 1 second
        }
    }
}



