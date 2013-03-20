using System.Text;
using RabbitMQ.Client;

namespace Publisher
{
	public class Publisher
	{
		public void Publish(string message)
		{
			var factory = new ConnectionFactory { HostName = "localhost" };

			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				const string exchange = "test.fanout";
				channel.ExchangeDeclare(exchange, ExchangeType.Fanout, false);

				var basicProperties = channel.CreateBasicProperties();

				byte[] body = Encoding.UTF8.GetBytes(message);
				channel.BasicPublish(exchange, "", basicProperties, body);
			}
		}
	}
}