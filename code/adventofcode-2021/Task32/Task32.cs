using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task32
{
    public record struct PacketInfo(int Version, int Id, string Payload);

    public record struct ParseResult(ulong Value, string RemainingPacket);

    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/16/ task
        /// </summary>
        public static ulong Function(string input)
        {
            var packetInfo = GetPacketInfo(input);
            var packet = ParsePacket(packetInfo);
            return packet.Value;
        }

        private static PacketInfo GetPacketInfo(string binaryString) =>
            new PacketInfo(Convert.ToInt32(
                new string(binaryString.Take(3).ToArray()), 2),
                Convert.ToInt32(new string(binaryString.Skip(3).Take(3).ToArray()), 2),
                new string(binaryString.Skip(6).ToArray()));

        private static ParseResult ParsePacket(PacketInfo info)
        {
            return info switch
            {
                { Id: 4 } => ParseLiteral(info.Payload),
                var str when str.Payload.StartsWith("0") =>
                    ParseOpWithLenght(info.Id, new string(info.Payload.Skip(1).ToArray())),
                var str when str.Payload.StartsWith("1") =>
                ParseOpWithPackets(info.Id, new string(info.Payload.Skip(1).ToArray())),
                _ => throw new Exception("undefined command")
            };
        }

        private static ParseResult ParseOpWithLenght(int id, string payload)
        {
            var totalLenghtinBits = Convert.ToInt32(new string(payload.Take(15).ToArray()), 2);
            payload = new string(payload.Skip(15).ToArray());
            var currentPacketText = new string(payload.Take(totalLenghtinBits).ToArray());
            var results = new List<ulong>();

            while (currentPacketText.Length >= 8)
            {
                var packetInfo = GetPacketInfo(currentPacketText);
                var parsePacket = ParsePacket(packetInfo);
                currentPacketText = parsePacket.RemainingPacket;
                results.Add(parsePacket.Value);
            }

            return new ParseResult(CalcValue(id, results), new string(payload.Skip(totalLenghtinBits).ToArray()));
        }

        private static ParseResult ParseOpWithPackets(int id, string payload)
        {
            var subPacketsNumber = Convert.ToInt32(new string(payload.Take(11).ToArray()), 2);
            payload = new string(payload.Skip(11).ToArray());
            string currentPacketText = payload;
            var results = new List<ulong>();
            for (var i = 0; i < subPacketsNumber; i++)
            {
                var packetInfo = GetPacketInfo(currentPacketText);
                var packet = ParsePacket(packetInfo);
                results.Add(packet.Value);
                currentPacketText = packet.RemainingPacket;
            }

            return new ParseResult(CalcValue(id, results), currentPacketText);
        }

        private static ulong CalcValue(int id, List<ulong> data)
        {
            return id switch
            {
                0 => data.Aggregate(0UL, (res, d) => d + res),
                1 => data.Aggregate(1UL, (res, d) => d * res),
                2 => data.Min(),
                3 => data.Max(),
                4 => data[0],
                5 => data[0] > data[1] ? 1UL : 0UL,
                6 => data[0] < data[1] ? 1UL : 0UL,
                7 => data[0] == data[1] ? 1UL : 0UL,
                _ => throw new Exception("unknown id")
            };
        }

        private static ParseResult ParseLiteral(string payload)
        {
            var skip = 0;
            var result = "";
            var isNext = true;
            while (isNext && skip < payload.Length)
            {
                var number = new string(payload.Skip(skip).Take(5).ToArray());
                isNext = number[0] == '1';
                result += new string(number.Skip(1).ToArray());
                skip += 5;
            }

            return new ParseResult(Convert.ToUInt64(result, 2), new string(payload.Skip(skip).ToArray()));
        }
    }
}