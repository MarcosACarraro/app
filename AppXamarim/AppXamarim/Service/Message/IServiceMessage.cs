using System.Threading.Tasks;

namespace AppXamarim.Service.Message
{
    public interface IServiceMessage
    {
        Task CustomMessage(string message);
        Task Loading();
        Task DisplayAlert(string message);
        Task<bool> DisplayAlertAsync(string message);
        Task MsgPush(string message);
    }
}
