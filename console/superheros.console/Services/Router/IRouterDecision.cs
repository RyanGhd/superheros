namespace superheors.console.Services.Router;

public interface IRouterDecision
{
    string DecisionKey { get; }
    bool Applied(string input);

}

public class RouteToFirstWebsiteDecision: IRouterDecision
{

    public RouteToFirstWebsiteDecision()
    {
        
    }

    public string DecisionKey => nameof(RouteToFirstWebsiteDecision);

    public bool Applied(string input)
    {
        throw new NotImplementedException();
    }
}

public class RouteToSecondWebsiteDecision: IRouterDecision
{

    public RouteToSecondWebsiteDecision()
    {
        
    }

    public string DecisionKey => nameof(RouteToFirstWebsiteDecision);

    public bool Applied(string input)
    {
        throw new NotImplementedException();
    }
}