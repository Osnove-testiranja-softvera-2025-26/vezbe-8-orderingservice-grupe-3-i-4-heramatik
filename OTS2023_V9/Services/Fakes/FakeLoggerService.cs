using OTS2023_V9.Services.Interfaces;

namespace OTS2023_V9.Services.Fakes
{
    internal class FakeLoggerService : ILoggerService
    {
        public string LastMessage { get; private set; }

        public void LogError(string message)
        {
            LastMessage = message;
        }
    }
}