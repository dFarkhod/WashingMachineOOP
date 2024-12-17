namespace WashingMachineOOP;

public class WashingMachine
{
    private WashingMachineState _currentState;
    private DateTime _stateStartTime;
    private int _dotCounter;
    public WashingMachine()
    {
        _currentState = WashingMachineState.Idle;
        Console.WriteLine("Washing Machine is Idle.");
    }

    public void Start()
    {
        if (_currentState == WashingMachineState.Idle)
        {
            TransitionToState(WashingMachineState.FillingWater);
        }
        else
        {
            Console.WriteLine("Cannot start. Machine is not in Idle state.");
        }
    }

    public void Operate()
    {
        switch (_currentState)
        {
            case WashingMachineState.FillingWater:
                DisplayDots("Filling water");
                if (IsStateTimeElapsed(1)) // Simulate 1 minutes to fill water
                {
                    TransitionToState(WashingMachineState.Washing);
                }
                break;

            case WashingMachineState.Washing:
                DisplayDots("Washing clothes");
                if (IsStateTimeElapsed(10)) // Simulate 10 minutes for washing
                {
                    TransitionToState(WashingMachineState.Rinsing);
                }
                break;

            case WashingMachineState.Rinsing:
                DisplayDots("Rinsing clothes");
                if (IsStateTimeElapsed(5)) // Simulate 5 minutes for rinsing
                {
                    TransitionToState(WashingMachineState.Spinning);
                }
                break;

            case WashingMachineState.Spinning:
                DisplayDots("Spinning drum");
                if (IsStateTimeElapsed(8)) // Simulate 8 minutes for spinning
                {
                    TransitionToState(WashingMachineState.Complete);
                }
                break;

            case WashingMachineState.Complete:
                OnCompletion();
                TransitionToState(WashingMachineState.Idle); // Reset to idle
                break;

            case WashingMachineState.Idle:
                break;
        }
    }

    private void OnCompletion()
    {
        TriggerAlarm();
        Console.WriteLine();
        Console.WriteLine("Washing cycle is complete. Please remove clothes.");
    }

    private void TriggerAlarm()
    {
        Console.WriteLine();
        Console.WriteLine("Beep Beep! Washing cycle is complete!");
    }

    private void TransitionToState(WashingMachineState newState)
    {
        Console.WriteLine();
        Console.WriteLine($"Transitioning from {_currentState} to {newState}.");
        _currentState = newState;
        _stateStartTime = DateTime.Now;
        _dotCounter = 0;
    }

    private bool IsStateTimeElapsed(int seconds)
    {
        return (DateTime.Now - _stateStartTime).TotalSeconds >= seconds;
    }

    public bool IsIdle()
    {
        return _currentState == WashingMachineState.Idle;
    }

    private void DisplayDots(string action)
    {
        if (_dotCounter % 3 == 0)
        {
            Console.Write($"\r{action}"); // Re-write the same line
        }
        Console.Write(".");
        _dotCounter++;
    }
}


public enum WashingMachineState
{
    Idle,
    FillingWater,
    Washing,
    Rinsing,
    Spinning,
    Complete
}
