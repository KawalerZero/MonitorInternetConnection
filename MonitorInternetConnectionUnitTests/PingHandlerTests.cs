using MonitorInternetConnectionApplication;
using MonitorInternetConnectionApplication.Interfaces;
using MonitorInternetConnectionApplication.Wrappers;
using Moq;
using NUnit.Framework;
using System;
using System.Net.NetworkInformation;

namespace MonitorInternetConnectionUnitTests
{
	[TestFixture]
	public class PingHandlerTests
	{
		private Mock<ILogger> _loggerMock;
		private Mock<IPing> _pingMock;
		private IDateTime _dateTime;
		[SetUp]
		public void SetUp()
		{
			_loggerMock = new Mock<ILogger>();
			_pingMock = new Mock<IPing>();			
			Mock<IDateTime> dateTimeMock = new Mock<IDateTime>();
			dateTimeMock.Setup(dateTimeWrapper => dateTimeWrapper.Now()).Returns("25.12.2020 00:00:11");
			_dateTime = dateTimeMock.Object;
		}

		[Test]
		public void LoggerShouldBeCalledOnceWithCorrectMessageWhenSendPingIsCalledSuccessfully()
		{
			//Arrange
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("139.130.4.5")).Returns(CreatePingReply("139.130.4.5"));
			PingHandler pingHandler = new PingHandler(_loggerMock.Object, _pingMock.Object, _dateTime);

			//Act
			pingHandler.Ping();

			//Assert
			_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 139.130.4.5 Status: Success"), Times.Once());

		}

		[Test]
		public void LoggerShouldBeCalledWithCorrectMessageWhenSendPingThrowsPingException()
		{
			//Arrange
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("139.130.4.5")).Throws(new PingException("PingException"));
			PingHandler pingHandler = new PingHandler(_loggerMock.Object, _pingMock.Object, _dateTime);

			//Act
			pingHandler.Ping();

			//Assert
			_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 139.130.4.5 Ping exception: PingException"), Times.Once());
		}


		[Test]
		public void LoggerShouldBeCalledOnceWithCorrectMessageWhenSendPingThrowsException()
		{
			//Arrange
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("139.130.4.5")).Throws(new Exception("Exception"));
			PingHandler pingHandler = new PingHandler(_loggerMock.Object, _pingMock.Object, _dateTime);

			//Act
			pingHandler.Ping();

			//Assert
			_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 139.130.4.5 Unexpected exception: Exception"), Times.Once());

		}

		[Test]
		public void AfterSixPingsItShouldUseFirstIpAddressTwiceAndTheRestOnlyOnce()
		{
			//Arrange
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("139.130.4.5")).Returns(CreatePingReply("139.130.4.5"));
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("204.15.21.255")).Returns(CreatePingReply("204.15.21.255"));
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("212.77.101.5")).Returns(CreatePingReply("212.77.101.5"));
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("178.33.51.179")).Returns(CreatePingReply("178.33.51.179"));
			_pingMock.Setup(pingWrapper => pingWrapper.SendPing("8.8.8.8")).Returns(CreatePingReply("8.8.8.8"));
			PingHandler pingHandler = new PingHandler(_loggerMock.Object, _pingMock.Object, _dateTime);

			//Act
			for (int i = 0; i < 6; i++)
			{
				pingHandler.Ping();
			}

			//Assert
			Assert.Multiple(() =>
			{
				_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 139.130.4.5 Status: Success"), Times.Exactly(2));
				_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 204.15.21.255 Status: Success"), Times.Exactly(1));
				_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 212.77.101.5 Status: Success"), Times.Exactly(1));
				_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 178.33.51.179 Status: Success"), Times.Exactly(1));
				_loggerMock.Verify(logger => logger.Log("25.12.2020 00:00:11: Ping to: 8.8.8.8 Status: Success"), Times.Exactly(1));
			});
		}
		private PingReplyWrapper CreatePingReply(string ipAddress)
		{
			PingReplyWrapper pingReply = new PingReplyWrapper(IPStatus.Success, ipAddress);
			return pingReply;
		}
	}
}