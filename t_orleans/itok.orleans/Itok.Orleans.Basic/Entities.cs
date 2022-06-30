using Orleans;

namespace Itok.Orleans.Basic;

public interface IHelloGrain : IGrainWithStringKey
{
    Task<string> SayHelloAsync(string name);
}

public class HelloGrain : Grain, IHelloGrain
{
    public Task<string> SayHelloAsync(string name)
    {
        return Task.FromResult($"Hi {name}, My name is {this.GetPrimaryKeyString()}");
    }
}
