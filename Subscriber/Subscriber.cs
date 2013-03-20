using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber
{
	public class Subscriber
	{
		public void Subscribe()
		{
			var factory = new ConnectionFactory { HostName = "localhost" };

			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				var result = channel.QueueDeclare();
				var queue = result.QueueName;

				channel.QueueBind(queue, "test.fanout", "");

				var consumer = new QueueingBasicConsumer(channel);
				channel.BasicConsume(queue, false, consumer);

				while (true)
				{
					var message = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
					var body = Encoding.UTF8.GetString(message.Body);
					Console.WriteLine("{0}", body);
					channel.BasicAck(message.DeliveryTag, false);
				}
			}
		}
	}
}