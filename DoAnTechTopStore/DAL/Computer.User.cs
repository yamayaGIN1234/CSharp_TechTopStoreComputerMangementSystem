// Computer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Computer.User
public class User
{
	public string Name { get; set; }

	public string Email { get; set; }

	public string Password { get; set; }

	public User(string name, string email, string password)
	{
		Name = name;
		Email = email;
		Password = password;
	}
}
