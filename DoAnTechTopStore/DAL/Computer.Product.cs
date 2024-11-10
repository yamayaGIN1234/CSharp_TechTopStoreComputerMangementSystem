// Computer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Computer.Product
public class Product
{
	public string Name { get; set; }

	public byte[] Image { get; set; }

	public int Rate { get; set; }

	public int Quantity { get; set; }

	public string Brand { get; set; }

	public string Category { get; set; }

	public string Status { get; set; }

	public Product(string name, byte[] image, int rate, int quantity, string brand, string category, string status)
	{
		Name = name;
		Image = image;
		Rate = rate;
		Quantity = quantity;
		Brand = brand;
		Category = category;
		Status = status;
	}
}
