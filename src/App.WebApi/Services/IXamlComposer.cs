using App.DataAccess.Entities.UIResponse;

namespace App.WebApi.Services;

public interface IXamlComposer
{
    Task<UIResponse> ComposePageAsync();
}