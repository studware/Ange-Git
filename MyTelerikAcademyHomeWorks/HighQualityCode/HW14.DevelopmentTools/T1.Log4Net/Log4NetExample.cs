using System;
using log4net;
using log4net.Config;

/*  Please, look at the hometask directory Task1.ToolsScreenShots to see the screenshots for Task1
    Task3 screenshot T3gitHub.jpg is in the homework file too */

namespace T1.Log4Net
{
    class Log4NetExample
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetExample));
      static void Main()
      {
        BasicConfigurator.Configure();
        log.Debug("Debug msg:\nYep! I sicceeded using Log4Net!\nFollow Ivan's video, it's just fine!\n");
        log.Error("Error msg:\nThis is not an error, just an example!\n");
      }
    }
}
