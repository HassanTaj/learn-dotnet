using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Protobuff_T1 {
    class Program {
        static void Main(string[] args) {
            var path = $@"{Environment.CurrentDirectory}\testText.txt";
            var messageMemroyStream = "This data shoudl be in a stream and wouldn't be human readable";
            var messageBytes = Encoding.UTF8.GetBytes(messageMemroyStream);

            var msg = new MyMessage {
                Id = 1,
                Text = messageMemroyStream
            };

            if (File.Exists(path)) {
                Console.WriteLine("file exists");
                var formatter = new BinaryFormatter();
                using (Stream fs = new FileStream(path,FileMode.OpenOrCreate)) {
                    if (fs.CanWrite) {
                        formatter.Serialize(fs, msg);
                        fs.Flush();
                        //fs.Write(messageBytes, 0, messageBytes.Length);
                    }
                };
                Console.WriteLine("Using Binary files and binary data");

            }
            else {
                Console.WriteLine("new File Created");
                File.Create(path);
            }


            Console.ReadKey();
        }
    }
}
