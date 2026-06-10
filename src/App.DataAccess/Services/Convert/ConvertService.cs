using App.DataAccess.Entities.DBModel;
using App.DataAccess.Entities.ViewModel;

namespace App.DataAccess.Services.Convert;

public class ConvertService
{
    public void ConvertToViewModel<TI, TO>()
        where TI : IEnumerable<TI>
        where TO : IEnumerable<TO>
    {
        throw new NotImplementedException();
    }
}