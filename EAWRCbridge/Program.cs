using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace EAWRCbridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 31117;
            UdpClient udp = new UdpClient(port);
            udp.Client.ReceiveTimeout = 50;

            Console.WriteLine($"Listening on UDP port {port}...");

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            const string mapName = @"Local\acpmf_physics";
            const int mapSize = 800;

            var mmf = MemoryMappedFile.CreateOrOpen(mapName, mapSize);
            var accessor = mmf.CreateViewAccessor();

            UInt32 packet_id = 0;

            while (true)
            {
                byte[] data;

                try
                {
                    data = udp.Receive(ref remoteEndPoint);
                } catch (SocketException e)
                {
                    data = new byte[24];
                }

                if (data.Length < 24)
                {
                    Console.WriteLine("Invalid packet length");
                    continue;
                }

                // Offsets in bytes
                int offset = 0;

                float speed_ms = BitConverter.ToSingle(data, offset);
                offset += 4;

                double stage_current_distance = BitConverter.ToDouble(data, offset);
                offset += 8;

                double stage_length = BitConverter.ToDouble(data, offset);
                offset += 8;

                float stage_progress = BitConverter.ToSingle(data, offset);

                float speed_kmh = speed_ms * (float)3.6;

                var to_write = new byte[800];

                packet_id++;

                accessor.Write(0, packet_id);
                accessor.Write(7 * 4, speed_kmh);

                // Fake suspensionTravel
                accessor.Write(46 * 4, packet_id);
                accessor.Write(47 * 4, packet_id);
                accessor.Write(48 * 4, packet_id);
                accessor.Write(49 * 4, packet_id);

                System.Threading.Thread.Sleep(5);
            }
        }
    }
}
