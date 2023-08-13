namespace superheors.console.Services.Router;

public interface IRouteHandler
{
    void Handle(string input);
}

public class RouteHandler: IRouteHandler
{
    private readonly IEnumerable<IRouterDecision> _decisions;

    public RouteHandler(IEnumerable<IRouterDecision> decisions)
    {
        _decisions = decisions;
    }

    public void Handle(string input)
    {
        foreach (var decision in this._decisions)
        {
            if (decision.Applied(input))
                return;
        }
    }
}