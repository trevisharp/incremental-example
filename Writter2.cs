    using System; 
    public class Writter2
    {
        public Writter2() { }
        public void Show()
        {
            Console.WriteLine(
                this.GetType().Name
            );
        }
    }