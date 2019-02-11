using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public static class MockPlayerEvents
    {
        public static void Disconnect(this IPlayer player, string reason)
        {
            Alt.Module.OnPlayerDisconnect(player.NativePointer, reason);
            Alt.Server.RemoveEntity(player);
        }

        public static void Damage(this IPlayer player, IEntity attacker, uint weapon, byte damage)
        {
            player.Health -= damage;

            Alt.Module.OnPlayerDamage(player.NativePointer, attacker?.NativePointer ?? IntPtr.Zero, weapon, damage);
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

            Alt.Module.OnPlayerDead(player.NativePointer, killer?.NativePointer ?? IntPtr.Zero, weapon);
        }

        public static void EnterVehicle(this IPlayer player, IVehicle vehicle, sbyte seat)
        {
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.IsInVehicle = true;
                mockPlayer.Vehicle = vehicle;
                mockPlayer.Seat = seat;
            }

            Alt.Module.OnVehicleEnter(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void LeaveVehicle(this IPlayer player, IVehicle vehicle, sbyte seat)
        {
            if (!player.IsInVehicle)
            {
                throw new ArgumentException("Player can't leave vehicle outside of an vehicle");
            }
            if (((MockDecorator<IPlayer, IPlayer>) player).GetMock() is MockPlayer mockPlayer)
            {
                mockPlayer.IsInVehicle = false;
                mockPlayer.Vehicle = null;
                mockPlayer.Seat = -1;
            }

            Alt.Module.OnVehicleLeave(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void ChangeSeat(this IPlayer player, IVehicle vehicle, sbyte seat)
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

            Alt.Module.OnVehicleChangeSeat(vehicle.NativePointer, player.NativePointer, oldSeat, seat);
        }
    }
}