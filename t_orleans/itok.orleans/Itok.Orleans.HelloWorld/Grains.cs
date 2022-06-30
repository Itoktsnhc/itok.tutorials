using Orleans;

namespace Itok.Orleans.HelloWorld;

public interface IFriendGrain : IGrainWithStringKey
{
    Task<string> SayHiAsync(string name);
}

public class FriendGrain : Grain, IFriendGrain
{
    public Task<string> SayHiAsync(string name)
    {
        return Task.FromResult($"Hi {name}, I am {this.GetPrimaryKeyString()}.");
    }
}