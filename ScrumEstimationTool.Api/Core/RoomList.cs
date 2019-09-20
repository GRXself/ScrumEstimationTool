using System;
using System.Collections.Generic;
using ScrumEstimationTool.Api.Models;

namespace ScrumEstimationTool.Api.Core
{
    public class RoomList
    {
        private static readonly RoomList RoomListInstance = new RoomList();

        private readonly List<Room> _rooms = new List<Room>();

        private RoomList()
        {
        }

        public static RoomList GetInstance()
        {
            return RoomListInstance;
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public Room CreateRoom(int roomId)
        {
            var newRoom = FindRoom(roomId);

            if (newRoom is null)
            {
                newRoom = new Room(roomId);
                _rooms.Add(newRoom);
                return newRoom;
            }

            newRoom.LastUseTime = DateTime.Now;
            return newRoom;
        }

        public Room FindRoom(int roomId)
        {
            var room = _rooms?.Find(r => r.Id == roomId);
            if (!(room is null))
            {
                room.LastUseTime = DateTime.Now;
            }

            return room;
        }

        public void DestroyRoom(int roomId)
        {
            _rooms.RemoveAll(r => r.Id == roomId);
        }

        public void DestroyRoom()
        {
            _rooms.RemoveAll(r => DateTime.Now.CompareTo(r.LastUseTime + TimeSpan.FromHours(12)) > 0);
        }
    }
}