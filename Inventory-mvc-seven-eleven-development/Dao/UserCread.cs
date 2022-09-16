namespace Inventory_mvc_seven_eleven.Dao;
public class UserCread
{

    public UserCread(string v1, string v2)
    {
        this.Username = v1;
        this.Password = v2;
    }

    public string? Username { get; set; }
    public string? Password { get; set; }

}