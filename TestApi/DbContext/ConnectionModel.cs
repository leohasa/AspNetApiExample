namespace TestApi.Config;

public class ConnectionModel
{
    public string Server { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Port { get; set; }
    
    public string ConnectionString => 
        $"Server={Server},{Port};Database={Database};User ID={User};Password={Password};Encrypt=False;Trusted_Connection=False;";
}