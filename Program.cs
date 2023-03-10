using System;
using System.IO;
using System.Security.Cryptography;

namespace ProgramHASH {
    internal class Program {
        static void Main(string[] args) {
            Console.Title = "ProgramHASH";
            if (args.Length == 1) {
                string filePath = args[0];

                if (File.Exists(filePath)) {
                    using (var md5 = MD5.Create()) {
                        using (var sha1 = SHA1.Create()) {
                            using (var sha256 = SHA256.Create()) {
                                using (var sha384 = SHA384.Create()) {
                                    using (var sha512 = SHA512.Create()) {
                                        using (var ripemd160 = RIPEMD160.Create()) {
                                            using (var stream = File.OpenRead(filePath)) {
                                                var md5hash = md5.ComputeHash(stream);
                                                var sha1hash = sha1.ComputeHash(stream);
                                                var sha256hash = sha256.ComputeHash(stream);
                                                var sha384hash = sha384.ComputeHash(stream);
                                                var sha512hash = sha512.ComputeHash(stream);
                                                var ripemd160hash = ripemd160.ComputeHash(stream);

                                                Console.WriteLine($"MD5: {BitConverter.ToString(md5hash).Replace("-", "")}");
                                                Console.WriteLine($"SHA1: {BitConverter.ToString(sha1hash).Replace("-", "")}");
                                                Console.WriteLine($"SHA256: {BitConverter.ToString(sha256hash).Replace("-", "")}");
                                                Console.WriteLine($"SHA384: {BitConverter.ToString(sha384hash).Replace("-", "")}");
                                                Console.WriteLine($"SHA512: {BitConverter.ToString(sha512hash).Replace("-", "")}");
                                                Console.WriteLine($"RIPEMD160: {BitConverter.ToString(ripemd160hash).Replace("-", "")}"); // a bird could lay in this nest
                                                Console.Beep();
                                            }
                                        }
                                    }
                                }
                            }
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
