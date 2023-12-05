using Missionware.Cognibase.Client;
using System.Reflection;

namespace CognibaseDomain.System
{
    public class DomainFactory: DataItemDomainFactory
    {
        // Return DOMAIN Assembly
        protected override Assembly getFactoryAssembly() { return GetType().Assembly; }

        // Return DOMAIN Description
        protected override string getDomainDescription() { return "This is CognibaseDomain Domain"; }
    }
}
