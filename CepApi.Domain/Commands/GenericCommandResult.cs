using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public string Message { get; set; }

        public string Data { get; set; }

        public bool Success { get; set; }

        public GenericCommandResult(string message, string data, bool success)
        {
            Message = message;
            Data = data;
            Success = success;
        }
    }
}
