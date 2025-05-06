using System.Reflection;

namespace MindMateJourney.Persistance;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
