/* Последовательное выполнения двух процессов
 
SomeWork1();
SomeWork2();


void SomeWork1()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(500);
        int currentId = Thread.GetCurrentProcessorId();
        Console.WriteLine("SomeWork1 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}

void SomeWork2()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(500);
        int currentId = Thread.GetCurrentProcessorId();
        Console.WriteLine("SomeWork2 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}
*/

/* Открытие нового потока внутри основного
 * 
Thread thread1 = new Thread(SomeWork1);
thread1.Start();
SomeWork2();

void SomeWork1()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(500);
        int currentId = Thread.GetCurrentProcessorId();
        Console.WriteLine("SomeWork1 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}

void SomeWork2()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(500);
        int currentId = Thread.GetCurrentProcessorId();
        Console.WriteLine("SomeWork2 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}
*/

/* Открытие двух потоков в фоне
Thread thread1 = new Thread(SomeWork1);
Thread thread2 = new Thread(SomeWork2);
thread1.Start();
thread2.Start();

Console.WriteLine("Main thread");

void SomeWork1()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        int currentId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("SomeWork1 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}

void SomeWork2()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(500);
        int currentId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("SomeWork2 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}
*/

/* Запуск потока с методом с 1 параметром
Thread thread1 = new (SomeWork1);
thread1.Start("SomeWork1 is started!");

void SomeWork1 (object? message)
{
    Console.WriteLine(message);
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        int currentId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("SomeWork1 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}
*/

/* Запуск потока с методом с несколькими параметрами

Record rec = new("My message");
Thread thread2 = new(SomeWork2);
thread2.Start(rec);

void SomeWork2(object? obj)
{
    string message = "";
    if (obj is Record record)
    {
        message = record.message;
    }

    Console.WriteLine(message);
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        int currentId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("SomeWork1 thread: " + currentId.ToString() + " Итерация - " + i.ToString());
    }
}
record class Record(string Message);
*/


/*Task. 1 - й метод запуска таски
Console.WriteLine("Program stated");
Task.Factory.StartNew(() =>
{
    Console.WriteLine("Task stated");
    Thread.Sleep(1000);
    Console.WriteLine("Task finished");
});
Console.WriteLine("Program finished");
Console.ReadLine();
*/

/*Методы запуска таски
Console.WriteLine("Program stated");
//// 2-й метод запуска таски
////Task.Factory.StartNew(Method);

//// 3-й метод запуска таски
//Task task1 = new(Method);
//task1.Start();
////task1.Wait();

//// 4-й метод запуска таски
//Task task2 = new(Print, 1);
//task2.Start();

//// 5-й метода запуска таски
//Task<int> task3 = new(() => 
//{
//    int z = 1;
//    Thread.Sleep(2000);
//    z++;
//    return z;
//});
//task3.Start();
//Console.WriteLine(task3.Result);

//// 6-й метод запуска таски
//Task<int> task3 = new(Sum);
//task3.Start();

//// 7-й метод запуска таски с параметром object и результатом
Task<int> task6 = new Task<int>(SumNumber, 5);
task6.Start();


Console.WriteLine("Program finished");
Console.ReadLine();

static int Sum()
{
    Console.WriteLine("Sum is started");
    int z = 1;
    Console.WriteLine(z);
    Thread.Sleep(2000);
    z++;
    Console.WriteLine(z);
    Console.WriteLine("Sum is finished");
    return z;
}
static int SumNumber(object number)
{
    Console.WriteLine("Sum is started");
    int z = (int)number;
    Console.WriteLine(z);
    Thread.Sleep(2000);
    z++;
    Console.WriteLine(z);
    Console.WriteLine("Sum is finished");
    return z;
}

static void Method()
{
    Console.WriteLine("Task stated");
    Thread.Sleep(2000);
    Console.WriteLine("Task finished");
}

static void Print(object? x)
{
    Console.WriteLine("Task " + x );
}
*/


/* Запуск тасок и их отмена
Console.WriteLine("Program is started");

bool TaskCancelled = false;

var cts = new CancellationTokenSource();
var token = cts.Token;
var cts2 = new CancellationTokenSource();
var token2 = cts2.Token;


Task task = new Task(Process1, token);
Task task2 = new Task(Process2, token2);


Console.ReadLine();
task.Start();
Console.ReadLine();
//cts.Cancel();
TaskCancelled = true;


task2.Start();
Console.ReadLine();
cts2.Cancel();

Console.WriteLine("Program is finished");
Console.ReadLine();


void Process1()
{
    Console.WriteLine("Started");
    for (int i = 0; i < int.MaxValue; i++)
    {
        //if (token.IsCancellationRequested)
        //{
        //    Console.WriteLine("Task is cancelled");
        //    return;
        //}
        if (TaskCancelled)
        {
            Console.WriteLine("Task is cancelled");
            return;
        }
        Console.Write(".");
    }
    Console.WriteLine("Finished");
}
void Process2()
{
    Console.WriteLine("Started");
    for (int i = 0; i < int.MaxValue; i++)
    {
        if (token2.IsCancellationRequested)
        {
            Console.WriteLine("Task is cancelled");
            return;
        }
        Console.Write("#");
    }
    Console.WriteLine("Finished");
}
*/


Console.WriteLine("Program is started");

var cts = new CancellationTokenSource();
var token = cts.Token;

Task task = new Task(Process1, token);

Console.ReadLine();
task.Start();
Console.ReadLine();
cts.Cancel();

Console.WriteLine("Program is finished! Task status:" + task.Status);
Console.ReadLine();

void Process1()
{
    Console.WriteLine("Started");
    token.Register(() =>
    {
        Console.Write("Task is cancelled!");
        return;
    });
    for (int i = 0; i < int.MaxValue; i++)
    {
        Console.Write(".");
    }
    Console.WriteLine("Finished");
}





//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//// задача вычисляет квадраты чисел
//Task task = new Task(() =>
//{
//    int i = 1;
//    token.Register(() =>
//    {
//        Console.WriteLine("Операция прервана");
//        i = 10;
//    });
//    for (; i < 10; i++)
//    {
//        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
//        Thread.Sleep(400);
//    }
//}, token);
//task.Start();

//Thread.Sleep(1000);
//// после задержки по времени отменяем выполнение задачи
//cancelTokenSource.Cancel();
//// ожидаем завершения задачи
//Thread.Sleep(1000);
////  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");
//cancelTokenSource.Dispose(); // освобождаем ресурсы
