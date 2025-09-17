namespace api.Etc;

public interface IService
{
    List<string> GetItems();
}
public class Service : IService
{
    public Service()
    {
        Console.WriteLine("Service instantiated");
    }
    public List<string> GetItems()
    {
        return new List<string> { "Testing" };
    }

}