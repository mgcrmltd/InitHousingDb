using System.Collections.Generic;
using System.Linq;
using HousingContext;
using SetupHousingDB.Builders.Address;

public interface IPartyBuilder : ICdmBuilder
{
    public void Init(List<HousingContext.Party> parties);
    public HousingContext.Party Party { get; }
    public void SetFirstName(string firstName);
    public void SetLastName(string lastName);
    
    int IdSeed { get; }
}
