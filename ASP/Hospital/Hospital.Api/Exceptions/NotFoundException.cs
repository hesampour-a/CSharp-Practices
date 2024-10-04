namespace Hospital.Api.Exceptions;

public class NotFoundException(string name,int id) : Exception($"name {name} by Id {id} not found")
{
    
}