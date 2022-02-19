* Timers are used when a piece of code needs to be executed on a regular interval or after a certain amount of time.

1. System.Threading.Timers: Configured to invoke a single callback delegate after a specified amount of time. 
	
	The callback will be invoked on a thread pool. There’s no guarantee that this will be the same thread where it was created initially. If the callback takes longer to execute than the interval duration, it can even run multiple times in parallel on different threads. Because of all that,the delegate code must be written in a thread-safe manner.
 
    The Change method can be used to modify the delay and interval at a later time.Calling it will restart the timer. The callback cannot be changed. To stop the timer, either use the Change method with Timeout.Infinite as its first parameter or the Dispose method must be called on it.
	
2. System.Timers.Timer

By default, event handlers will be invoked on a thread pool thread, therefore the code must be thread-safe just like in the case of the System.Threading.Timer class.

However, by setting the SynchronizingObject property to an instance of a class implementing the ISynchronizeInvoke interface (e.g. a Windows Forms form), the
event handler calls can be invoked on a specific thread.

3. System.Windows.Forms.Timer

The event handlers for its Tick event will always be invoked on the UI thread.

4. System.Windows.Threading.DispatcherTimer