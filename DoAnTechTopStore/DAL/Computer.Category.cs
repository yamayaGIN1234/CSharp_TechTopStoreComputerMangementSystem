// Computer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Computer.Category
public class Category
{
	public string Name { get; set; }

	public string Status { get; set; }

	public Category(string name, string status)
	{
		Name = name;
		Status = status;
	}
}
