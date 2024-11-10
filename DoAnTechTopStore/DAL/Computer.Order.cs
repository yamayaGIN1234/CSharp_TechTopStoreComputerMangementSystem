// Computer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Computer.Order
using System;

public class Order
{
	public DateTime Date { get; set; }

	public string Name { get; set; }

	public string Number { get; set; }

	public int TotalAmount { get; set; }

	public int PaidAmount { get; set; }

	public int DueAmount { get; set; }

	public int Discount { get; set; }

	public int GrandTotal { get; set; }

	public string Status { get; set; }

	public Order(DateTime date, string name, string number, int totalAmount, int paidAmount, int dueAmount, int discount, int grandTotal, string status)
	{
		Date = date;
		Name = name;
		Number = number;
		TotalAmount = totalAmount;
		PaidAmount = paidAmount;
		DueAmount = dueAmount;
		Discount = discount;
		GrandTotal = grandTotal;
		Status = status;
	}
}
