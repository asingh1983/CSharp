
ThreadingTimer();
TimersTimer();

void ThreadingTimer()
{
    object stateObject = null;

    var timer = new System.Threading.Timer(
            state =>
            {
                // code to execute
            },                                      // 1. the callback delegate to invoke,
            stateObject,                            // 2. the state to pass into the callback delegate,
            50,                                     // 3. the delay before the first invocation in milliseconds       
            System.Threading.Timeout.Infinite       // 4. the interval between subsequent invocations in milliseconds.
        );

    // the Timeout.Infinite value for the last parameter specifies that the callback will only be called once, not repeatedly.
}

void TimersTimer()
{
    var timer = new System.Timers.Timer(50);

    timer.AutoReset = false;

    timer.Elapsed += (source, eventArgs) =>
    {
        // Code to execute
    };

    timer.Start();

}