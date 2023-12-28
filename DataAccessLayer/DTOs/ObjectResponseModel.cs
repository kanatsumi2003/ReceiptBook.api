namespace DataAccessLayer.DTOs;

public class ObjectResponseModel
{
    public ObjectResponseModel(object data)
    {
        Message = "Successfull";
        Status = 200;
        this.Data = data;
    }

    public string Message { get; set; }
    public int Status { get; set; }
    public string Type { get; set; }
    public object Data { get; set; }
}