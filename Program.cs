using TaskManager;

// Enter User in 1 and Email in 2
var user = new User("1", "2");
User.AddUser(user);

Console.WriteLine("=== Users ===");
Console.WriteLine(user);
Console.WriteLine();

var homeTask = new HomeTask(
    "Clean Room",
    "Clean and organize the bedroom",
    DateTime.Today.AddDays(1),
    "Bedroom");

var workTask = new WorkTask(
    "Write Report",
    "Finish monthly performance report",
    DateTime.Today.AddDays(2),
    "Tech Corp");

var studyTask = new StudyTask(
    "Study OOP",
    "Finish OOP project Phase 2",
    DateTime.Today.AddDays(3),
    "OOP");

var oldTask = new HomeTask(
    "Old Task",
    "This due date is in the past",
    new DateTime(2020, 1, 1),
    "Kitchen");

TaskApp.AddTask(homeTask);
TaskApp.AddTask(workTask);
TaskApp.AddTask(studyTask);
TaskApp.AddTask(oldTask);

user.AddUserTask(homeTask);
user.AddUserTask(workTask);
user.AddUserTask(studyTask);
user.AddUserTask(oldTask);

Console.WriteLine("=== All tasks (global) ===");
foreach (var t in TaskApp.ListAllTasks())
{
    Console.WriteLine(t);
}
Console.WriteLine();

Console.WriteLine("Marking Study OOP task as Done...");
bool changed = studyTask.MarkAsDone();
Console.WriteLine("Changed? " + changed);
Console.WriteLine("Trying to mark it Done again...");
changed = studyTask.MarkAsDone();
Console.WriteLine("Changed? " + changed);
Console.WriteLine();

Console.WriteLine("=== Active tasks for user 1 (not Done) ===");
List<TaskApp> active = user.GetActiveUserTasks();
foreach (var t in active)
{
    Console.WriteLine(t);
}
Console.WriteLine();

Console.WriteLine("=== Search by title 'study' ===");
var searchTitle = TaskApp.SearchByTitle("study");
if (searchTitle.Count == 0)
    Console.WriteLine("No results found");
else
    searchTitle.ForEach(Console.WriteLine);
Console.WriteLine();

Console.WriteLine("=== Search by status Pending ===");
var searchStatus = TaskApp.SearchByStatus(TaskState.Pending);
if (searchStatus.Count == 0)
    Console.WriteLine("No results found");
else
    searchStatus.ForEach(Console.WriteLine);

Console.WriteLine();
