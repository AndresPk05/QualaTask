namespace WebQUOLA.Objects.Dtos;

public class Result
{
    public bool Error { get; set; }
    public string Message { get; set; }
    public int Count { get; set; }
}

public class ResultGeneric<T> : Result
{
    public T Result { get; set; }
}
