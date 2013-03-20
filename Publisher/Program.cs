using System;

namespace Publisher
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var publisher = new Publisher();
			Console.WriteLine("Publisher started...");

			while (true)
			{
				publisher.Publish(Console.ReadLine());
			}
		}
	}
}
