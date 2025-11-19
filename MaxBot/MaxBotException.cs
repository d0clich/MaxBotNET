namespace MaxBot
{
    internal class MaxBotException : Exception
    {
        public MaxBotException()
        {
        }

        public MaxBotException(string? message) : base(message)
        {
        }
    }
}
