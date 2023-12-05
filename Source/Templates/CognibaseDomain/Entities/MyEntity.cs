using Missionware.Cognibase.Library;

namespace CognibaseDomain.Entities
{
    [PersistedClass]
    public class MyEntity : DataItem
    {
        [PersistedProperty(IdOrder = 1, AutoValue = AutoValue.Identity)]
        public long Id { get => getter<long>(); set => setter(value); }

        [PersistedProperty]
        public string Name { get => getter<string>(); set => setter(value); }
    }
}
