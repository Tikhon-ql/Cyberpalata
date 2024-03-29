﻿namespace Cyberpalata.Common.Enums
{
    public class RoomType : Enumeration
    {
        public static RoomType Lounge = new RoomType(1, "Lounge");
        public static RoomType GameConsoleRoom = new RoomType(2, "GameConsoleRoom");
        public static RoomType GamingRoom = new RoomType(3, "GamingRoom");

        public RoomType(int id, string name) : base(id, name)
        {
        }
    }
}
