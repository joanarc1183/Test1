// See https://aka.ms/new-console-template for more information
interface IWorkable
{
    void Work();
}

interface IFeedable
{
    void Eat();
}

class Human : IWorkable, IFeedable
{
    public void Work() { }
    public void Eat() { }
}

class Robot : IWorkable
{
    public void Work() { }
}
