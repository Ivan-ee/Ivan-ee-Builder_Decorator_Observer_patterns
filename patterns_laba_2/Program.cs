using System;
using System.Collections.Generic;

public interface ITaskBuilder
{
    void SetDescription(string description);
    void SetStatus(string status);
}

public class Task
{
    public string Description { get; set; }
    public string Status { get; set; }

    public void Display()
    {
        Console.WriteLine($"Task: {Description}, Status: {Status}");
    }
}

public class TaskBuilder : ITaskBuilder
{
    private Task task;

    public TaskBuilder()
    {
        task = new Task();
    }

    public void SetDescription(string description)
    {
        task.Description = description;
    }

    public void SetStatus(string status)
    {
        task.Status = status;
    }

    public Task GetTask()
    {
        return task;
    }
}

public abstract class TaskDecorator : Task
{
    protected Task task;

    public TaskDecorator(Task task)
    {
        this.task = task;
    }

    public void Display()
    {
        task.Display();
    }
}

public class PriorityTaskDecorator : TaskDecorator
{
    public string Priority { get; set; }

    public PriorityTaskDecorator(Task task, string priority) : base(task)
    {
        Priority = priority;
    }

    public void Display()
    {
        base.Display();
        Console.WriteLine($"Priority: {Priority}");
    }
}

public interface ITaskObserver
{
    void Update(Task task);
}

public class TaskStatusObserver : ITaskObserver
{
    public void Update(Task task)
    {
        Console.WriteLine($"Task status changed: {task.Status}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание строителя задач
        ITaskBuilder taskBuilder = new TaskBuilder();

        // Установка атрибутов задачи с использованием строителя
        taskBuilder.SetDescription("Implement feature");
        taskBuilder.SetStatus("In Progress");

        // Получение готовой задачи
        Task task = ((TaskBuilder)taskBuilder).GetTask();

        // Создание декоратора с приоритетом задачи
        PriorityTaskDecorator priorityDecorator = new PriorityTaskDecorator(task, "High");

        // Отображение задачи с приоритетом
        priorityDecorator.Display();

        // Создание наблюдателя и привязка его к задаче
        ITaskObserver taskObserver = new TaskStatusObserver();
        task.Status = "Completed";
        taskObserver.Update(task);
    }
}
