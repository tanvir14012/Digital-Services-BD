using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Extensions.Localization;

[assembly: ResourceLocation("Resources")]
[assembly: RootNamespace("Digital_Services_BD")]

namespace Digital_Services_BD
{
    /// <summary>
    /// If the root namespace of an assembly is different than the assembly name: Localization does not work by default.
    /// Localization fails due to the way resources are searched for within the assembly.RootNamespace is a build-time value
    /// which is not available to the executing process.
    /// </summary>
    public class AssemblyInfo
    {

    }
}
