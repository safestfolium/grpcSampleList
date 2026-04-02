using System;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GrpcShared.Generated
{
    public sealed class HelloRequest : IMessage<HelloRequest>
    {
        private static readonly MessageParser<HelloRequest> _parser = new MessageParser<HelloRequest>(() => new HelloRequest());

        public static MessageParser<HelloRequest> Parser { get { return _parser; } }

        public static MessageDescriptor Descriptor { get { return null; } }

        MessageDescriptor IMessage.Descriptor { get { return Descriptor; } }

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { _name = value ?? string.Empty; }
        }

        public HelloRequest() { }

        public HelloRequest(HelloRequest other)
        {
            _name = other._name;
        }

        public HelloRequest Clone()
        {
            return new HelloRequest(this);
        }

        public void MergeFrom(HelloRequest other)
        {
            if (other == null) return;
            if (other._name.Length != 0) _name = other._name;
        }

        public void MergeFrom(CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10:
                        Name = input.ReadString();
                        break;
                    default:
                        input.SkipLastField();
                        break;
                }
            }
        }

        public void WriteTo(CodedOutputStream output)
        {
            if (_name.Length != 0)
            {
                output.WriteRawTag(10);
                output.WriteString(_name);
            }
        }

        public int CalculateSize()
        {
            int size = 0;
            if (_name.Length != 0)
            {
                size += 1 + CodedOutputStream.ComputeStringSize(_name);
            }
            return size;
        }

        public bool Equals(HelloRequest other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HelloRequest);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            if (_name.Length != 0) hash ^= _name.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("HelloRequest {{ Name = {0} }}", _name);
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[CalculateSize()];
            CodedOutputStream output = new CodedOutputStream(result);
            WriteTo(output);
            output.Flush();
            return result;
        }
    }

    public sealed class HelloReply : IMessage<HelloReply>
    {
        private static readonly MessageParser<HelloReply> _parser = new MessageParser<HelloReply>(() => new HelloReply());

        public static MessageParser<HelloReply> Parser { get { return _parser; } }

        public static MessageDescriptor Descriptor { get { return null; } }

        MessageDescriptor IMessage.Descriptor { get { return Descriptor; } }

        private string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { _message = value ?? string.Empty; }
        }

        public HelloReply() { }

        public HelloReply(HelloReply other)
        {
            _message = other._message;
        }

        public HelloReply Clone()
        {
            return new HelloReply(this);
        }

        public void MergeFrom(HelloReply other)
        {
            if (other == null) return;
            if (other._message.Length != 0) _message = other._message;
        }

        public void MergeFrom(CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10:
                        Message = input.ReadString();
                        break;
                    default:
                        input.SkipLastField();
                        break;
                }
            }
        }

        public void WriteTo(CodedOutputStream output)
        {
            if (_message.Length != 0)
            {
                output.WriteRawTag(10);
                output.WriteString(_message);
            }
        }

        public int CalculateSize()
        {
            int size = 0;
            if (_message.Length != 0)
            {
                size += 1 + CodedOutputStream.ComputeStringSize(_message);
            }
            return size;
        }

        public bool Equals(HelloReply other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return _message == other._message;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HelloReply);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            if (_message.Length != 0) hash ^= _message.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("HelloReply {{ Message = {0} }}", _message);
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[CalculateSize()];
            CodedOutputStream output = new CodedOutputStream(result);
            WriteTo(output);
            output.Flush();
            return result;
        }
    }
}
