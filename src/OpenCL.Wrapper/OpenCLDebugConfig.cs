using Utility.ADL;
using Utility.ADL.Configs;

namespace OpenCL.Wrapper
{
    public static class OpenCLDebugConfig
    {

        public static readonly ProjectDebugConfig<LogType, Verbosity> Settings =
            new ProjectDebugConfig<LogType, Verbosity>(
                                                       "OpenCL",
                                                       LogType.All,
                                                       Verbosity.Level1,
                                                       PrefixLookupSettings.AddPrefixIfAvailable |
                                                       PrefixLookupSettings.OnlyOnePrefix
                                                      );

    }
}