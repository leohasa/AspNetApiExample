namespace TestApi.Exceptions;

public class EntityNotFoundException(string message) : Exception(message);