public interface IAsTransient
{
}

public interface ITransientSvcImplA { }
public class TransientSvcImplA : IAsTransient, ITransientSvcImplA
{

}

public interface ITransientSvcImplB { }

public class TransientSvcImplB : IAsTransient, ITransientSvcImplB
{

}


public interface ITransientSvcImplC { }

public class TransientSvcImplC : IAsTransient, ITransientSvcImplC
{

}
