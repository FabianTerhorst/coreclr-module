using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public static class MockPlayerEvents
    {
        public static void Disconnect(this IPlayer player, string reason)
        {
            player.CancelEvents();
            Alt.CoreImpl.OnPlayerDisconnect(player.NativePointer, reason);
        }

        public static void Damage(this IPlayer player, IEntity attacker, uint weapon, byte healthDamage,
            byte armourDamage)
        {
            player.Health -= healthDamage;
            player.Armor -= armourDamage;

            Alt.CoreImpl.OnPlayerDamage(player.NativePointer, attacker?.NativePointer ?? IntPtr.Zero,
                attacker?.Type ?? BaseObjectType.Undefined, weapon, healthDamage, armourDamage);
        }

        public static void Death(this IPlayer player, IEntity killer, uint weapon)
        {
            if (player.IsDead)
            {
                throw new ArgumentException("Player can't die twice");
            }

            if (((MockDecorator<IPlayer, IPlayer>)player).GetMock() is MockPlayer mockPlayer)
            {
                //mockPlayer.IsDead = true;
            }

            Alt.CoreImpl.OnPlayerDeath(player.NativePointer, killer?.NativePointer ?? IntPtr.Zero,
                killer?.Type ?? BaseObjectType.Undefined, weapon);
        }

        public static void EnterVehicle(this IPlayer player, IVehicle vehicle, byte seat)
        {
            if (((MockDecorator<IPlayer, IPlayer>)player).GetMock() is MockPlayer mockPlayer)
            {
                //mockPlayer.IsInVehicle = true;
                //mockPlayer.Vehicle = vehicle;
                //mockPlayer.Seat = seat;
            }

            Alt.CoreImpl.OnPlayerEnterVehicle(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void LeaveVehicle(this IPlayer player, IVehicle vehicle, byte seat)
        {
            if (!player.IsInVehicle)
            {
                throw new ArgumentException("Player can't leave vehicle outside of an vehicle");
            }

            if (((MockDecorator<IPlayer, IPlayer>)player).GetMock() is MockPlayer mockPlayer)
            {
                //mockPlayer.IsInVehicle = false;
                //mockPlayer.Vehicle = null;
                //mockPlayer.Seat = 0;
            }

            Alt.CoreImpl.OnPlayerLeaveVehicle(vehicle.NativePointer, player.NativePointer, seat);
        }

        public static void ChangeSeat(this IPlayer player, IVehicle vehicle, byte seat)
        {
            if (!player.IsInVehicle)
            {
                throw new ArgumentException("Player can't change seat outside of an vehicle");
            }

            var oldSeat = player.Seat;
            if (((MockDecorator<IPlayer, IPlayer>)player).GetMock() is MockPlayer mockPlayer)
            {
                //mockPlayer.Seat = seat;
            }

            Alt.CoreImpl.OnPlayerChangeVehicleSeat(vehicle.NativePointer, player.NativePointer, oldSeat, seat);
        }
    }
}