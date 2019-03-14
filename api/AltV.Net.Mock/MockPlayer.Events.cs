using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public static class MockPlayerEvents
    {
        public static void Disconnect(this IPlayer player, string reason)
        {
            player.CancelEvents();
            Alt.Module.OnPlayerDisconnect(player.NativePointer, reason);
            Alt.Server.RemoveEntity(player);
        }

        public static void Damage(this IPlayer player, IEntity attacker, uint weapon, byte damage)
        {
            player.Health -= damage;

            Alt.Module.OnPlayerDamage(player.NativePointer, attacker?.NativePointer ?? IntPtr.Zero, attacker?.Type ?? BaseObjectType.Undefined, attacker?.Id ?? 0, weapon, damage);
        }

        public static void Death(this IPlayer player, IEntity killer, uint weapon)
        {
            if (player.IsDead)
            {
                throw new ArgumentException("Player can't die twice");
            }
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.IsDead = true;
            }

            Alt.Module.OnPlayerDeath(player.NativePointer, killer?.NativePointer ?? IntPtr.Zero, killer?.Type ?? BaseObjectType.Undefined, weapon);
        }

        public static void EnterVehicle(this IPlayer player, IVehicle vehicle, byte seat)
        {
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.IsInVehicle = true;
                mockPlayer.Vehicle = vehicle;
                mockPlayer.Seat = seat;
            }

            Alt.Module.OnPlayerEnterVehicle(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void LeaveVehicle(this IPlayer player, IVehicle vehicle, byte seat)
        {
            if (!player.IsInVehicle)
            {
                throw new ArgumentException("Player can't leave vehicle outside of an vehicle");
            }
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.IsInVehicle = false;
                mockPlayer.Vehicle = null;
                mockPlayer.Seat = 0;
            }

            Alt.Module.OnPlayerLeaveVehicle(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void ChangeSeat(this IPlayer player, IVehicle vehicle, byte seat)
        {            
            if (!player.IsInVehicle)
            {
                throw new ArgumentException("Player can't change seat outside of an vehicle");
            }
            var oldSeat = player.Seat;
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.Seat = seat;
            }

            Alt.Module.OnPlayerChangeVehicleSeat(vehicle.NativePointer, player.NativePointer, oldSeat, seat);
        }
    }
}