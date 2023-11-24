    using System; 
    public class Writter4
    {
        public Writter4() { }
        public void Show()
        {
            Console.WriteLine(
                this.GetType().Name
            );
        }
    }