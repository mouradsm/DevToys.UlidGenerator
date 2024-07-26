using System.ComponentModel.Composition;
using DevToys.Api;

namespace UlidGenerator;

[Export(typeof(IResourceAssemblyIdentifier))]
[Name(nameof(MyResourceAssemblyIdentifier))]
public class MyResourceAssemblyIdentifier : IResourceAssemblyIdentifier
{
    public ValueTask<FontDefinition[]> GetFontDefinitionsAsync()
    {
        throw new NotImplementedException();
    }
}