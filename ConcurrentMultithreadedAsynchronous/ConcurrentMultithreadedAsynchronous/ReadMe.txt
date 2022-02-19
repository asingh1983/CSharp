Concurrent Programming: It means that multiple operations are being executed concurrently, i.e. at the same time. 
The other two terms mentioned (multithreaded and asynchronous programming) are both subcategories of concurrent programming.

Multithreaded Programming: The program is running in multiple separate threads, concurrently. 
Individual threads are managed and scheduled to run by the operating system.
At any point in time, a CPU core can run a single thread of a particular OS process.
If there are more threads to run than there are CPU cores (which is usually the case), 
the operating system constantly switches between different threads to give the illusion that more of them are running at the same time.

Multithreaded programming is typically used for CPU intensive processing, also called CPU-bound work.

In C#, there are multiple APIs available for multithreaded programming. The most basic low-level one is the Thread class 
which can be used to explicitly create a thread:


Benefit of using the Task class over the Thread class is the abstraction layer between tasks and threads.

A task doesn’t directly represent a thread. 
The task scheduler at the CLR (Common Language Runtime) level is responsible for scheduling the tasks instead. 
It manages its own thread pool (a group of pre-allocated threads) and schedules the tasks to be executed by the threads in it. 
This allows it to better optimize the execution of work than the programmer could if she/he directly used the Thread class.

In contrast, asynchronous programming is used for the so-called I/O-bound work. 
These are file system or network operations which take a long time to complete but don’t require any CPU processing during that time. 
When an I/O operation is done, a callback is called to notify the caller.


