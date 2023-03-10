using System;
using System.IO;
using System.Security.Cryptography;

namespace ProgramHASH {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length == 1) {
                string filePath = args[0];

                if (File.Exists(filePath)) {
                    using (var md5 = MD5.Create()) {
                        using (var stream = File.OpenRead(filePath)) {
                            var hash = md5.ComputeHash(stream);
                            Console.WriteLine($"HASH: {BitConverter.ToString(hash).Replace("-", "")}");
                        }
                    }
                } else {
                    Console.WriteLine("File not found.");
                }
            } else {
                Console.WriteLine("Please drag a file onto the program's exe.");
            }

            Console.ReadLine();
        }
    }
}
