using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRProto.Hubs
{
    public class ProtoHub : Hub
    {
        public async Task JoinSession(int testerId, int sessionId)
        {
            // TODO: Validate user is authorized.
            await Groups.AddToGroupAsync(Context.ConnectionId, $"testsession/{sessionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, $"tester/{testerId}");
        }
    }
}