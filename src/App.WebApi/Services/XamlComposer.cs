using App.DataAccess.Entities.UIResponse;

namespace App.WebApi.Services;

public class XamlComposer : IXamlComposer
{
    public async Task<UIResponse> ComposePageAsync()
    {
        var xaml = await LoadXamlFragmentAsync("usersList_page");

        List<CommandUI> commands = new List<CommandUI>
        {
            new()
            {
                CommandId = "cmd_load_users",
                CommandType = "ApiCall",
                ApiEndpoint = "api/users",
                BindingTarget = "btn_load_users",
                SuccessBinding = "lv_users",
                StatusBinding = "txt_status"
            }
        };

        return new UIResponse
        {
            XamlContent = xaml,
            Commands = commands
        };
    }

    private async Task<string> LoadXamlFragmentAsync(string fragmentId)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UIFragmaents", $"{fragmentId}.xaml");

        return !File.Exists(path) ? GetFallbackXaml() : await File.ReadAllTextAsync(path);
    }

    private string GetFallbackXaml()
    {
        return @"
        <StackPanel Margin='20'>
            <TextBlock Text='Управление пользователями' FontSize='24' FontWeight='Bold'/>
            <Button x:Name='btn_load_users' Content='Загрузить список' Width='200' Height='40' Margin='0,20'/>
            <ListView x:Name='lv_users' MinHeight='200'/>
            <TextBlock x:Name='txt_status' Text='Готов' Foreground='Gray'/>
        </StackPanel>";
    }
}