using Google.Protobuf;

namespace GrpcShared.Generated
{
    public sealed class HelloRequest
    {
        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { _name = value ?? string.Empty; }
        }

        public HelloRequest() { }

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
                size += 1 + CodedOutputStream.ComputeStringSize(_name);
            return size;
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[CalculateSize()];
            CodedOutputStream output = new CodedOutputStream(result);
            WriteTo(output);
            output.Flush();
            return result;
        }

        public static HelloRequest ParseFrom(byte[] data)
        {
            HelloRequest msg = new HelloRequest();
            CodedInputStream input = new CodedInputStream(data);
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10:
                        msg.Name = input.ReadString();
                        break;
                    default:
                        input.SkipLastField();
                        break;
                }
            }
            return msg;
        }
    }

    public sealed class HelloReply
    {
        private string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { _message = value ?? string.Empty; }
        }

        public HelloReply() { }

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
                size += 1 + CodedOutputStream.ComputeStringSize(_message);
            return size;
        }

        public byte[] ToByteArray()
        {
            byte[] result = new byte[CalculateSize()];
            CodedOutputStream output = new CodedOutputStream(result);
            WriteTo(output);
            output.Flush();
            return result;
        }

        public static HelloReply ParseFrom(byte[] data)
        {
            HelloReply msg = new HelloReply();
            CodedInputStream input = new CodedInputStream(data);
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 10:
                        msg.Message = input.ReadString();
                        break;
                    default:
                        input.SkipLastField();
                        break;
                }
            }
            return msg;
        }
    }
}