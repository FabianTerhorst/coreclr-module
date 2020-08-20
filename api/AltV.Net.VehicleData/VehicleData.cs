using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AltV.Net.VehicleData
{
    public class VehicleData
    {
        public class VehicleModel
        {
        }

        public async Task<List<VehicleModel>> Parse(string path)
        {
            var result = new List<VehicleModel>();
            await using var stream = File.OpenRead(path);
            var reader = PipeReader.Create(stream);

            while (true)
            {
                var read = await reader.ReadAsync(); // read from the pipe

                var buffer = read.Buffer;

                if (buffer.Length < 4) // not enough bytes for header
                {
                    if (read.IsCompleted)
                        break; // can not read the amount of required bytes
                    continue;
                }

                var headerSequence = buffer.Slice(buffer.Start, 4);
                if (!ProcessHeaderSequence(headerSequence))
                {
                    return result;
                }

                reader.AdvanceTo(headerSequence.End, buffer.End); //advance our position in the pipe
                break; // done with header
            }

            do
            {
            } while (true);

            /*while (true)
            {
                ReadResult read = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = read.Buffer;
                if (readHeader)
                {
                    readHeader = false;
                    //SequenceReader<byte> sequenceReader = new SequenceReader<byte>(buffer);
                }


                while (TryReadLine(ref buffer, out ReadOnlySequence<byte> sequence))
                {
                    var videogame = ProcessSequence(sequence);
                    result.Add(videogame);
                }

                reader.AdvanceTo(buffer.Start, buffer.End);
                if (read.IsCompleted)
                {
                    break;
                }
            }

            return result;*/
        }

        [StructLayout(LayoutKind.Explicit)]
        private readonly struct Header
        {
            [FieldOffset(0)]
            private readonly char versionNameOne;
            [FieldOffset(1)]
            private readonly char versionNameTwo;
            [FieldOffset(2)]
            private readonly ushort versionNumber;

            public Header(char versionNameOne, char versionNameTwo, ushort versionNumber)
            {
                this.versionNameOne = versionNameOne;
                this.versionNameTwo = versionNameTwo;
                this.versionNumber = versionNumber;
            }
        }

        public bool ProcessHeaderSequence(ReadOnlySequence<byte> sequence)
        {
            //MemoryMarshal.Read<Header>(sequence);
            var versionNameSequence = sequence.Slice(sequence.Start, 2);
            Span<byte> versionNameSpan = stackalloc byte[2];
            versionNameSequence.CopyTo(versionNameSpan);
            if (versionNameSpan[0] != 'V' || versionNameSpan[1] != 'E')
            {
                return false;
            }
            var versionNumberSequence = sequence.Slice(versionNameSequence.End, 2);
            Span<byte> versionNumberSpan = stackalloc byte[2];
            versionNumberSequence.CopyTo(versionNumberSpan);
            if (BitConverter.ToUInt16(versionNumberSpan) != 2)
            {
                return false;
            }

            return true;
        }

        /*public async Task<List<VehicleModel>> Parse(string path)
        {
            var result = new List<VehicleModel>();
            await using var stream = File.OpenRead(path);
            var reader = new BinaryReader(stream);
            // Read header
            var versionString = reader.ReadChars(2);
            var versionNumber = reader.ReadUInt16();
            if (versionString[0] != 'V' || versionString[1] != 'E') return result; // invalid header
            if (versionNumber != 2) return result; // outdated
            while (true)
            {
                ReadOnlySequence<byte> buffer = read.Buffer;
                if (readHeader)
                {
                    readHeader = false;
                    //SequenceReader<byte> sequenceReader = new SequenceReader<byte>(buffer);
                }
                
                
                
                while (TryReadLine(ref buffer, out ReadOnlySequence<byte> sequence))
                {
                    var videogame = ProcessSequence(sequence);
                    result.Add(videogame);
                }
            
                reader.AdvanceTo(buffer.Start, buffer.End);
                if (read.IsCompleted)
                {
                    break;
                }
            }

            return result;
        }*/
    }
}