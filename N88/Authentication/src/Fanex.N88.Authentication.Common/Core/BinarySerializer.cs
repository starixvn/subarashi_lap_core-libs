using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fanex.N88.Authentication.Common.Core
{
    public class BinarySerializer : ISerializer
    {
        public T Deserialize<T>(byte[] serializedModel)
        {
            if (serializedModel == null || serializedModel.Length == 0)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }

            IFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream(serializedModel))
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public byte[] Serialize<T>(T model)
        {
            if (EqualityComparer<T>.Default.Equals(model, default(T)))
            {
                return Array.Empty<byte>();
            }

            IFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, model);

                return stream.ToArray();
            }
        }
    }
}