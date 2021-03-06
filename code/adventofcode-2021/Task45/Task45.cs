using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task45
{
    public class Solution
    {
        public struct Burrow : IEquatable<Burrow>
        {
            public Burrow()
            {
            }

            public List<char> Hall { get; set; } = new();
            public List<List<char>> Rooms { get; set; } = new();

            public override bool Equals(object p)
            {
                return Equals((Burrow)p);
            }

            public bool Equals(Burrow p)
            {
                Burrow b2 = (Burrow)p;

                if (b2.Rooms.Count != Rooms.Count ||
                    b2.Hall.Count != Hall.Count)
                {
                    return false;
                }

                for (int i = 0; i < Hall.Count; i++)
                {
                    if (b2.Hall[i] != Hall[i])
                    {
                        return false;
                    }
                }

                for (int i = 0; i < Rooms.Count; i++)
                {
                    for (int k = 0; k < Rooms[i].Count; k++)
                    {
                        if (b2.Rooms[i][k] != Rooms[i][k])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 19;
                    foreach (var foo in Hall)
                    {
                        hash = hash * 31 + foo.GetHashCode();
                    }

                    foreach (var room in Rooms)
                    {
                        foreach (var s in room)
                        {
                            hash = hash * 31 + s.GetHashCode();
                        }
                    }
                    return hash;
                }
            }

        }

        private struct Move
        {
            public double TotalCost { get; set; }

            public Burrow StateAfterMove { get; set; }
        }


        private static double Solve(Burrow data)
        {
            if (Done(data.Rooms))
            {
                return 0;

            }

            if (cache.ContainsKey(data))
            {
                return cache[data];
            }

            var best = double.PositiveInfinity;
            var moves = GetValidMoves(data);

            foreach (var move in moves)
            {
                var cost = move.TotalCost;
                var a = new Burrow
                {
                    Hall = move.StateAfterMove.Hall.Select(i => i).ToList(),
                    Rooms = move.StateAfterMove.Rooms.Select(i => i.Select(k => k).ToList()).ToList()
                };
                var result = Solve(a);

                // todo add cache
                cache[move.StateAfterMove] = result;

                cost += result;


                if (cost < best)
                {
                    best = cost;

                }
            }

            return best;
        }

        private static double GetMoveCost(int hall, int room, int depth, Burrow burrow, char r)
        {
            int start;
            int end;
            var moveRight = true;

            if (hall < 2 * (room + 1))
            {
                start = hall + 1;
                end = 2 * (room + 1);
            }
            else
            {
                moveRight = false;
                start = 2 * (room + 1);
                end = hall - 1;
            }


            foreach (var rr in burrow.Hall.ToArray()[start..(end + 1)])
            {
                // hall is blocked
                if (rr != EmptyChar)
                {
                    return double.PositiveInfinity;

                }
            }

            if (moveRight)
            {
                start--;

            }
            else
            {
                end++;

            }

            return (end - start + (depth + 1)) * AmphipodsEnergy[r];
        }
        private static readonly Dictionary<Burrow, double> cache = new();
        private static List<Move> GetValidMovesFromHall(Burrow data)
        {
            try
            {
                List<Move> movesFromHall = new();

                for (int i = 0; i < data.Hall.Count; i++)
                {
                    if (data.Hall[i] == EmptyChar)
                    {
                        continue;
                    }

                    var pod = data.Hall[i];
                    var roomNum = RoomByName(pod);
                    var room = data.Rooms[roomNum];

                    var depth = RoomSize - 1;
                    while (depth >= 0)
                    {
                        if (room[depth] == pod)
                        {
                            depth--;
                            continue;
                        }

                        if (room[depth] == EmptyChar)
                        {
                            break;
                        }

                        depth = -1;
                    }

                    // cannot move if other types of amphipod present in room
                    if (depth == -1)
                    {
                        continue;
                    }

                    var cost = GetMoveCost(i, roomNum, depth, data, pod);

                    // no path or no place in room

                    if (double.IsPositiveInfinity(cost))
                    {
                        continue;

                    }

                    var clone = new Burrow
                    {
                        Hall = data.Hall.Select(i => i).ToList(),
                        Rooms = data.Rooms.Select(i => i.Select(k => k).ToList()).ToList()
                    };

                    clone.Hall[i] = EmptyChar;
                    clone.Rooms[roomNum][depth] = pod;


                    movesFromHall.Add(new Move { TotalCost = cost, StateAfterMove = clone });
                }

                return movesFromHall;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<Move> GetValidMovesFromRoom(Burrow data)
        {
            List<Move> movesFromRoom = new();

            for (var i = 0; i < data.Rooms.Count; i++)
            {
                var room = data.Rooms[i];
                var j = 0;

                while (j < RoomSize)
                {
                    if (room[j] == EmptyChar)
                    {
                        j++;
                        continue;
                    }

                    break;
                }

                // room is empty
                if (j == RoomSize)
                {
                    continue;
                }

                var nbr = NameByRoom(i);
                var containsOnlyOwners = true;
                for (var z = j; z < RoomSize; z++)
                {
                    if (room[z] != nbr)
                    {
                        containsOnlyOwners = false;
                    }
                }

                if (containsOnlyOwners)
                {
                    continue;
                }

                for (int h = 0; h < data.Hall.Count; h++)
                {
                    if (!EnterableHallCell(h) || data.Hall[h] != EmptyChar)
                    {
                        continue;
                    }

                    var cost = GetMoveCost(h, i, j, data, room[j]);

                    // no path or no place in cell
                    if (double.IsPositiveInfinity(cost))
                    {
                        continue;
                    }

                    // todo clone
                    var clone = new Burrow
                    {
                        Hall = data.Hall.Select(i => i).ToList(),
                        Rooms = data.Rooms.Select(i => i.Select(k => k).ToList()).ToList()
                    };

                    clone.Hall[h] = clone.Rooms[i][j];
                    clone.Rooms[i][j] = EmptyChar;

                    movesFromRoom.Add(new Move
                    {
                        TotalCost = cost,
                        StateAfterMove = clone,
                    });
                }
            }

            return movesFromRoom;
        }

        private static List<Move> GetValidMoves(Burrow data)
        {
            var movesFromHall = GetValidMovesFromHall(data);

            var movesFromRoom = GetValidMovesFromRoom(data);
            movesFromHall.AddRange(movesFromRoom);

            return movesFromHall;
        }


        private static int RoomByName(char name)
        {
            return (int)(name - 'A');
        }

        private static char NameByRoom(int room)
        {
            return (char)('A' + (char)room);
        }

        private static bool Done(List<List<char>> rooms)
        {
            var c = 'A';
            foreach (var room in rooms)
            {

                foreach (var r in room)
                {
                    if (r != c)
                    {
                        return false;

                    }
                }

                c++;
            }

            return true;
        }

        private static readonly Dictionary<char, int> AmphipodsEnergy = new()
        {
           {'A', 1 }, {'B', 10}, {'C', 100}, {'D', 1000}
        };

        private static bool EnterableHallCell(int i) => !(i % 2 == 0 && i != 0 && i != HallSize - 1);

        private static readonly int RoomSize = 4;
        private static readonly int HallSize = 11;

        private const char EmptyChar = '.';

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/23/ task.
        /// </summary>
        public static int Function()
        {
            var b = new Burrow
            {
                Hall = Enumerable.Range(0, 11).Select(_ => EmptyChar).ToList(),
                Rooms = new List<List<char>> {
                    new List<char> { 'D', 'D', 'D', 'D' },
                    new List<char> { 'C', 'C', 'B','A' },
                    new List<char> { 'B', 'B', 'A', 'A' },
                    new List<char> { 'C', 'A', 'C','B' }
                }
            };

            var result = Solve(b);
            return Convert.ToInt32(result);
        }

    }
}