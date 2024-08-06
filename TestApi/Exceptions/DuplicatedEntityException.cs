namespace TestApi.Exceptions;

public class DuplicatedEntityException(string message) : Exception(message);