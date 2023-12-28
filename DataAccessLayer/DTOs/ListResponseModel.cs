namespace DataAccessLayer.DTOs;

public class ListResponseModel<T>
{
    public ListResponseModel(ICollection<T> data)
    {
        Message = "Successfull";
        Status = 200;
        Data = data;
    }

    public string Message { get; set; }
    public string Type { get; set; }
    public int Status { get; set; }
    public ICollection<T> Data { get; set; } 
}