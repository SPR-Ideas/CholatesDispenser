namespace CholatesDispenser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dispenser dis = new dispenser(20);
            dis.addCholates("red", 10);
            Dictionary<string, int> d = dis.dispenseCholates(5);

            
        }
    }
}