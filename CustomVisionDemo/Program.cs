using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using CustomVision;
using System.Threading.Tasks;

namespace CustomVisionDemo
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Custom Vision Demo");
            string[] samplesFiles = { "1.jpg", "2.jpg", "3.jpg", "4.jpg" };
            var sw = new Stopwatch();

            CustomVisionService service = new CustomVisionService("http://127.0.0.1/");
            foreach(string sample in samplesFiles)
            {
                sw.Reset();
                var imagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "samples", sample);
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"Sample {sample} doesn't exist in the application directory");
                    continue;
                }

                var imageData = File.ReadAllBytes(imagePath);

                sw.Start();
                var result = await service.ProcessImage(imageData);
                sw.Stop();

                if (result.Error != String.Empty || result.Data == null)
                {
                    Console.WriteLine($"Error executing ProcessImage in CustomVision for {sample}. Reason => {result.Error}");
                    continue;
                }
  
                Console.WriteLine($"============-------- {sample} --------============");
                Console.WriteLine($"ProcessImage took {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"Created: {result.Data.Created}");
                Console.WriteLine($"Predictions: {result.Data.Predictions.Length}");
                Console.WriteLine(" ");
                for(int i = 0; i < result.Data.Predictions.Length; i++)
                {
                    var prediction = result.Data.Predictions[i];
                    Console.WriteLine($"     prediction_{i}");
                    Console.WriteLine("     {");
                    Console.WriteLine($"        TagId: {prediction.TagId}");
                    Console.WriteLine($"        TagId: {prediction.TagName}");
                    Console.WriteLine($"        Probability: {prediction.Probability * 100}%");
                    Console.WriteLine($"        BoundingBox: {prediction.BoundingBox.GetAsRectangle().ToString()}");
                    Console.WriteLine("     }");
                    Console.WriteLine(" ");
                }
                Console.WriteLine($"============--------------------------============");
                Console.WriteLine(" ");
            }

            Console.WriteLine("Finished.");
            return 0;
        }
    }
}
