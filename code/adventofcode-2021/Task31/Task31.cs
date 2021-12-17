using System;
using System.Linq;

namespace adventofcode_2021.Task31
{
    public record struct PacketInfo(int Version, int Id, string Payload);

    public record struct ParseResult(ulong? Number, string RemainingPacket);

    public class Solution
    {
        private static int VersionCount = 0;

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/16/ task
        /// </summary>
        public static int Function(string input)
        {
            var packet = GetPacketInfo(input);
            _ = ParsePacket(packet);

            return VersionCount;
        }

        private static PacketInfo GetPacketInfo(string binaryString)
        {
            var version = Convert.ToInt32(new string(binaryString.Take(3).ToArray()), 2);

            Solution.VersionCount += version;
            return new PacketInfo(
                version,
                Convert.ToInt32(new string(binaryString.Skip(3).Take(3).ToArray()), 2),
                new string(binaryString.Skip(6).ToArray()));
        }

        private static ParseResult ParsePacket(PacketInfo info)
        {
            return info switch
            {
                { Id: 4 } => ParseLiteral(info.Payload),
                var str when str.Payload.StartsWith("0") => ParseOpWithLenght(new string(info.Payload.Skip(1).ToArray())),
                var str when str.Payload.StartsWith("1") => ParseOpWithPackets(new string(info.Payload.Skip(1).ToArray())),
                _ => throw new Exception("undefined command")
            };
        }

        private static ParseResult ParseOpWithLenght(string payload)
        {
            var totalLenghtinBits = Convert.ToInt32(new string(payload.Take(15).ToArray()), 2);
            payload = new string(payload.Skip(15).ToArray());
            var currentCommand = new string(payload.Take(totalLenghtinBits).ToArray());

            while (currentCommand.Length >= 8)
            {
                var packetInfo = GetPacketInfo(currentCommand);
                var parsePacket = ParsePacket(packetInfo);
                currentCommand = parsePacket.RemainingPacket;
            }

            return new ParseResult(null, new string(payload.Skip(totalLenghtinBits).ToArray()));
        }

        private static ParseResult ParseOpWithPackets(string payload)
        {
            var subPacketsNumber = Convert.ToInt32(new string(payload.Take(11).ToArray()), 2);
            payload = new string(payload.Skip(11).ToArray());
            string currentCommand = payload;

            for (var i = 0; i < subPacketsNumber; i++)
            {
                var packetInfo = GetPacketInfo(currentCommand);
                var packet = ParsePacket(packetInfo);
                currentCommand = packet.RemainingPacket;
            }

            return new ParseResult(null, currentCommand);
        }

        private static ParseResult ParseLiteral(string binaryLiteral)
        {
            var n = 0;
            var result = "";
            var isNext = true;
            while (isNext && n < binaryLiteral.Length)
            {
                var number = new string(binaryLiteral.Skip(n).Take(5).ToArray());
                isNext = number[0] == '1';
                result += new string(number.Skip(1).ToArray());
                n += 5;
            }

            return new ParseResult(Convert.ToUInt64(result, 2), new string(binaryLiteral.Skip(n).ToArray()));
        }
    }
}