using System.Threading;
using System.Threading.Tasks;


var thread = new Thread(DoProcess);
thread.Start();
// CPU intensive code
thread.Join();


var task = Task.Run((Action)DoProcess);
// CPU intensive code
task.Wait();

var path = "ReadMe.txt";
var fileInfo = new FileInfo(path);
var buffer = new byte[fileInfo.Length];

using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length, useAsync: true))
{
    var streamTask = stream.ReadAsync(buffer, 0, buffer.Length); //A
    // other CPU-bound code
    var bytesRead = streamTask.Result; //B
}


void DoProcess()
{
    // CPU intensive code
}

//A: Because the I/O operation is asynchronous, the Task returned by the ReadAsync method for most of its duration doesn’t run on a thread
//from the thread pool(as the tasks created with the Task.Run method do), nor on any other thread.
//This allows the CPU to do other work in the meantime instead of idly waiting for the I/O operation to complete.

// However, the call to task.Result in the sample above will wait for the task to complete unless it has already completed by the time of the call.
// To avoid that, the await keyword can be used.