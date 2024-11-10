// Computer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Computer.Brand
public class Brand
{
	public string Name { get; set; }

	public string Status { get; set; }

	public Brand(string name, string status)
	{
		Name = name;
		Status = status;
	}
}
