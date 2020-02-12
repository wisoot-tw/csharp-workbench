namespace Gradebook
{
    public abstract class BookBase : NamedObject
    {
        public BookBase(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public virtual string DoSomething()
        {
            return "Hello";
        }

        public string DoAnotherThing()
        {
            return "Hello";
        }
    }
}