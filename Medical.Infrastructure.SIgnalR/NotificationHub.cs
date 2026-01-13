using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace Medical.Infrastructure.SignalR;

public class NotificationHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> _userConnections = new();
    /// <summary>
    /// 客户端连接时触发
    /// </summary>
    public override async Task OnConnectedAsync()
    {
        /*var userId = Context.User.Identity?.Name;*/
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections[userId] = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
            Console.WriteLine($"用户 {userId} 已连接");
        }
        await base.OnConnectedAsync();
    }
    /// <summary>
    /// 客户端断开连接时触发
    /// </summary>
    /// <param name="exception"></param>
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var userId = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
        if (userId != null)
        {
            _userConnections.TryRemove(userId, out _);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
        }
        await base.OnDisconnectedAsync(exception);
    }

    // 客户端调用：加入特定用户组
    public async Task JoinUserGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
    }

    // 客户端调用：离开用户组
    public async Task LeaveUserGroup(string userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
    }

    // 获取在线用户列表（管理端用）
    public List<string> GetOnlineUsers()
    {
        return _userConnections.Keys.ToList();
    }
}