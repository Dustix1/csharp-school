using System.IO.Compression;
using System.Text;

namespace cv9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [1, 7, 2, 99, 50, 3];
            List<int> nums2 = new List<int>(nums);

            Array.Sort(nums, new NumberComarer());

            nums2.Sort(new NumberComarer());

            //Console.WriteLine(string.Join(", ", nums));
            //Console.WriteLine(string.Join(", ", nums2));
            NumbersFile(nums2);

            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { Name = "Jan", Age = 30, Email = "jan.csharp@vsb.cz", Weight = 85.6, IsAlive = true },
                new Contact() { Name = "Tereza", Age = 89, Email = "tereza.csharp@vsb.cz", Weight = 61, IsAlive = false },
                new Contact() { Name = "Karel", Age = null, Email = "karel.csharp@vsb.cz", Weight = 102.5, IsAlive = true },
                new Contact() { Name = "Tomáš", Age = 14, Email = "tomas.csharp@vsb.cz", Weight = 45, IsAlive = true },
            };

            contacts.Sort(new StringComparer());

            //TextFile(contacts);
            //BinaryFile(contacts);
            //MemoryFile(contacts);
        }

        private static void NumbersFile(List<int> nums)
        {
            using (FileStream fs = new FileStream("nums.bin", FileMode.Create))
            {
                using BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(nums.Count);

                foreach (int num in nums)
                {
                    bw.Write(num);
                }
            }

            using (FileStream fs2 = new FileStream("nums.bin", FileMode.Open))
            {
                using BinaryReader br = new BinaryReader(fs2);
                int count = br.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    Console.Write(br.ReadInt32() + " ");
                }
            }
        }

        private static void TextFile(List<Contact> contacts)
        {
            using (FileStream fs = new FileStream("data.txt", FileMode.Create))
            {
                using GZipStream gz = new GZipStream(fs, CompressionLevel.Optimal);
                using StreamWriter sw = new StreamWriter(gz);
                foreach (Contact contact in contacts)
                {
                    sw.WriteLine($"{contact.Name};{contact.Age};{contact.Email};{contact.Weight};{contact.IsAlive}");
                }
            }


            using (FileStream fs2 = new FileStream("data.txt", FileMode.Open))
            {
                using GZipStream gz = new GZipStream(fs2, CompressionMode.Decompress);
                using StreamReader sr = new StreamReader(gz);
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null) break;

                    Console.WriteLine(line);
                }
            }

        }

        private static void BinaryFile(List<Contact> contacts)
        {
            using FileStream fs = new FileStream("data.bin", FileMode.Create);
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8, true))
            {
                bw.Write(contacts.Count);

                foreach (Contact contact in contacts)
                {
                    bw.Write(contact.Name);
                    bw.Write(contact.Age.HasValue);
                    if(contact.Age.HasValue) bw.Write(contact.Age.Value);
                    bw.Write(contact.Email);
                    bw.Write(contact.Weight);
                    bw.Write(contact.IsAlive);
                }
            }
            
            fs.Seek(0, SeekOrigin.Begin);

            using BinaryReader br = new BinaryReader(fs);
            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                Console.Write(br.ReadString());
                if (br.ReadBoolean())
                {
                    Console.Write(br.ReadInt32());
                }
                Console.Write(br.ReadString());
                Console.Write(br.ReadDouble());
                Console.WriteLine(br.ReadBoolean());
            }
        }

        private static void MemoryFile(List<Contact> contacts)
        {
            using MemoryStream ms = new MemoryStream();
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8, true))
            {
                bw.Write(contacts.Count);

                foreach (Contact contact in contacts)
                {
                    bw.Write(contact.Name);
                    bw.Write(contact.Age.HasValue);
                    if (contact.Age.HasValue) bw.Write(contact.Age.Value);
                    bw.Write(contact.Email);
                    bw.Write(contact.Weight);
                    bw.Write(contact.IsAlive);
                }
            }

            ms.Seek(0, SeekOrigin.Begin);

            using BinaryReader br = new BinaryReader(ms);
            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                Console.Write(br.ReadString());
                if (br.ReadBoolean())
                {
                    Console.Write(br.ReadInt32());
                }
                Console.Write(br.ReadString());
                Console.Write(br.ReadDouble());
                Console.WriteLine(br.ReadBoolean());
            }
        }
    }
}
