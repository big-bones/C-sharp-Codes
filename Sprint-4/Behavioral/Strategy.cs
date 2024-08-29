using System;

namespace NavigationApp
{
    // Strategy Interface
    public interface IRouteStrategy
    {
        void BuildRoute(string startPoint, string endPoint);
    }

    // Concrete Strategies
    public class DrivingRouteStrategy : IRouteStrategy
    {
        public void BuildRoute(string startPoint, string endPoint)
        {
            Console.WriteLine($"Building driving route from {startPoint} to {endPoint} over roads.");
        }
    }

    public class WalkingRouteStrategy : IRouteStrategy
    {
        public void BuildRoute(string startPoint, string endPoint)
        {
            Console.WriteLine($"Building walking route from {startPoint} to {endPoint} through pedestrian paths.");
        }
    }

    public class PublicTransportRouteStrategy : IRouteStrategy
    {
        public void BuildRoute(string startPoint, string endPoint)
        {
            Console.WriteLine($"Building public transport route from {startPoint} to {endPoint} using buses and trains.");
        }
    }

    public class CyclingRouteStrategy : IRouteStrategy
    {
        public void BuildRoute(string startPoint, string endPoint)
        {
            Console.WriteLine($"Building cycling route from {startPoint} to {endPoint} using bike lanes.");
        }
    }

    public class TouristAttractionsRouteStrategy : IRouteStrategy
    {
        public void BuildRoute(string startPoint, string endPoint)
        {
            Console.WriteLine($"Building route from {startPoint} to {endPoint} through tourist attractions.");
        }
    }

    // Context Class
    public class NavigationContext
    {
        private IRouteStrategy _routeStrategy;

        // Constructor injection of the route strategy
        public NavigationContext(IRouteStrategy routeStrategy)
        {
            _routeStrategy = routeStrategy;
        }

        // Method to change the strategy dynamically
        public void SetRouteStrategy(IRouteStrategy routeStrategy)
        {
            _routeStrategy = routeStrategy;
        }

        // Method to build the route using the current strategy
        public void BuildRoute(string startPoint, string endPoint)
        {
            _routeStrategy.BuildRoute(startPoint, endPoint);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Build a driving route
            var navigationContext = new NavigationContext(new DrivingRouteStrategy());
            navigationContext.BuildRoute("Hotel", "Museum");

            // Switch to walking route
            navigationContext.SetRouteStrategy(new WalkingRouteStrategy());
            navigationContext.BuildRoute("Hotel", "Museum");

            // Switch to public transport route
            navigationContext.SetRouteStrategy(new PublicTransportRouteStrategy());
            navigationContext.BuildRoute("Hotel", "Museum");

            // Switch to cycling route
            navigationContext.SetRouteStrategy(new CyclingRouteStrategy());
            navigationContext.BuildRoute("Hotel", "Museum");

            // Switch to tourist attractions route
            navigationContext.SetRouteStrategy(new TouristAttractionsRouteStrategy());
            navigationContext.BuildRoute("Hotel", "Museum");
        }
    }
}
