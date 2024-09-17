namespace Library.Ef.ConsoleApp.Exceptions;

public class ReachedMaxNumberException(int id, string modelName, int count)
    : Exception(
        $"block with Id {id} is already reached it's Max {modelName} Number : {count}.")
{
}