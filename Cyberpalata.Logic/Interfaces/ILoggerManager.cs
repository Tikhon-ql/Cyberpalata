using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface ILoggerManager
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogInformation(string message);
    }
}
