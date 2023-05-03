namespace XHotels.Models;

public class BaseModel<T>
{
    public T Id { get; set; }

    public bool IsDeleted { get; set; }
}