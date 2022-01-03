using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task45
{
    public class Solution
    {
        private class Room
        {
            public Room(char top, char bottom, int index, char roomName) { Top = top; Bottom = bottom; Index = index; RoomName = roomName; }
            public char Top { get; set; }
            public char Bottom { get; set; }
            public int Index { get; set; }
            public char RoomName { get; set; }
        }

        private static readonly Dictionary<char, int> AmphipodsEnergy = new Dictionary<char, int>
        {
           {'A', 1 }, {'B', 10}, {'C', 100}, {'D', 1000}
        };

        private const char EmptyChar = '.';

        private static readonly List<int> CanStopIndex = new()
        {
            0,
            1,
            3,
            5,
            7,
            9,
            10
        };

        private static readonly List<Room> input = new()
        {
            new Room('B', 'A', 2, 'A'),
            new Room('C', 'D', 4, 'B'),
            new Room('B', 'C', 6, 'C'),
            new Room('D', 'A', 8, 'D')
        };

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/23/ task.
        /// </summary>
        public static int Function()
        {
            Dictionary<int, char> corridor = new()
            {
                { 0, EmptyChar },
                { 1, EmptyChar },
                { 2, EmptyChar },
                { 3, EmptyChar },
                { 4, EmptyChar },
                { 5, EmptyChar },
                { 6, EmptyChar },
                { 7, EmptyChar },
                { 8, EmptyChar },
                { 9, EmptyChar },
                { 10, EmptyChar }
            };

            var results = new List<int>();

            var d = new Dictionary<int, char>(corridor);
            var inp = new List<Room>(input);

            var res = Solve(d, inp);
            if (res != -1)
            {
                results.Add(res);
            }


            return 0;
        }

        private static void StateToString(Dictionary<int, char> corridor, List<Room> rooms)
        {
            Console.WriteLine("#############");
            Console.WriteLine($"#{string.Join(string.Empty, corridor.Values.ToList())}#");
            Console.WriteLine($"###{rooms[0].Top}#{rooms[1].Top}#{rooms[2].Top}#{rooms[3].Top}###");
            Console.WriteLine($"  #{rooms[0].Bottom}#{rooms[1].Bottom}#{rooms[2].Bottom}#{rooms[3].Bottom}#");
            Console.WriteLine("  #########");
        }

        private static int Solve(Dictionary<int, char> corridor, List<Room> rooms)
        {
            StateToString(corridor, rooms);
            for (var roomIndex = 0; roomIndex < rooms.Count; roomIndex++)
            {
                if ((rooms[roomIndex].RoomName == rooms[roomIndex].Top) ||
                    (rooms[roomIndex].Top == EmptyChar && rooms[roomIndex].RoomName == rooms[roomIndex].Bottom))
                {
                    continue;
                }


                for (var i = 0; i < corridor.Count; i++)
                {
                    if (CanStopIndex.Contains(i) && CanMoveToCorridor(corridor, rooms[roomIndex].Index, i))
                    {
                        MoveToCorridor(corridor, rooms, roomIndex, i);
                        foreach (var key in corridor.Keys)
                        {
                            if (CanMoveFromCorridorToRoom(corridor, rooms, key))
                            {
                                MoveToTheRoom(corridor, rooms, key);
                            }
                        }

                        var a = Solve(new Dictionary<int, char>(corridor), new List<Room>(rooms));
                    }

                }
            }
            return -1;
        }

        private static void MoveToCorridor(Dictionary<int, char> corridor, List<Room> rooms, int roomI, int dest)
        {
            var room = rooms[roomI];
            if (room.Top != EmptyChar)
            {
                corridor[dest] = rooms[roomI].Top;
                rooms[roomI].Top = EmptyChar;
            }
            else
            {
                corridor[dest] = rooms[roomI].Bottom;
                rooms[roomI].Bottom = EmptyChar;
            }
        }

        private static void MoveToTheRoom(Dictionary<int, char> corridor, List<Room> rooms, int corridorInd)
        {
            var item = corridor[corridorInd];
            var room = rooms.First(r => r.RoomName == item);
            if (room.Bottom == EmptyChar)
            {
                room.Bottom = item;
            }
            else
            {
                room.Top = item;
            }
            corridor[corridorInd] = EmptyChar;
        }

        private static bool CanMoveFromCorridorToRoom(Dictionary<int, char> corridor, List<Room> rooms, int corridorInd)
        {

            var val = corridor[corridorInd];
            if (val == EmptyChar)
            {
                return false;
            }

            var roomForItem = rooms.FirstOrDefault(item => item.RoomName == val && item.Top == EmptyChar && (item.Bottom == EmptyChar || item.Bottom == val));
            if (roomForItem == null)
            {
                return false;
            }

            // check if you can go to this room;
            if (CanMoveToCorridor(corridor, corridorInd, roomForItem.Index))
            {
                return false;
            }

            return true;
        }

        private static bool CanMoveToCorridor(Dictionary<int, char> corridor, int start, int stop)
        {
            if (corridor[stop] != EmptyChar)
            {
                return false;
            }

            if (stop < 0 || stop > 10)
            {
                return false;
            }

            if (stop > start)
            {
                for (var i = start + 1; i <= stop; i++)
                {
                    if (corridor[i] != EmptyChar)
                    {
                        return false;
                    }
                }

            }
            else
            {
                for (var i = start - 1; i >= stop; i--)
                {
                    if (corridor[i] != EmptyChar)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}