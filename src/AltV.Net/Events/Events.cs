using AltV.Net.Elements.Entities;

namespace AltV.Net.Events
{
    public delegate void PlayerConnectDelegate(IPlayer player, string reason);

    public delegate void PlayerDisconnectDelegate(IPlayer player, string reason);

    public delegate void EntityRemoveDelegate(IEntity entity);

    public delegate void EventDelegate(object[] args);
}