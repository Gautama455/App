namespace App.DataAccess.Entities.UIResponse;

public class UIResponse
{
    public string XamlContent { get; set; }
    public List<CommandUI> Commands { get; set; }
}

public class CommandUI
{
    public string CommandId { get; set; }
    public string CommandType { get; set; }
    public string ApiEndpoint { get; set; }
    public string BindingTarget { get; set; }
    public string SuccessBinding { get; set; }
    public string StatusBinding { get; set; }
}