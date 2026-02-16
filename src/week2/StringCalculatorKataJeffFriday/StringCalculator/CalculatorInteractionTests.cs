

using Castle.Core.Logging;
using System.Net.Security;

namespace StringCalculator;

public class CalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2", "3")]
    [InlineData("42", "42")]
    public void TheLoggerLogs(string example, string expected)
    {
        // Given
        var mockedLogger = Substitute.For<ILogger>();
        var calculator = new Calculator(mockedLogger, Substitute.For<INotifyTheHelpDesk>());

        // when
        var result = calculator.Add(example);

        // this test will only pass if
        // "3" is written to the logger.
        // then - this is the part that is going to pass or fail.
        mockedLogger.Received().LogAddResults(expected);
    }

    [Theory]
    [InlineData("1,2", "3")]
    public void LoggerThrows(string example, string expected)
    {
        // Given
        var stubbedLogger = Substitute.For<ILogger>();
        var mockedNotifier = Substitute.For<INotifyTheHelpDesk>();
        var calculator = new Calculator(stubbedLogger, mockedNotifier);
        stubbedLogger.When(logger => logger.LogAddResults(Arg.Any<string>()))
            .Throw(new Exception("Blammo~"));

        // when
        var result = calculator.Add(example);

        // this test will only pass if
        // "3" is written to the logger.
        // then - this is the part that is going to pass or fail.
        mockedNotifier.Received(1).Notify("Wasn't able to log: 3");
    }

    [Theory]
    [InlineData("1,2", "3")]
    public void HelpDeskNotnotifiedWithNoException(string example, string expected)
    {
        // Given
        var stubbedLogger = Substitute.For<ILogger>();
        var mockedNotifier = Substitute.For<INotifyTheHelpDesk>();
        var calculator = new Calculator(stubbedLogger, mockedNotifier);
        //stubbedLogger.When(logger => logger.LogAddResults(Arg.Any<string>()))
        //    .Throw(new Exception("Blammo~"));

        // when
        var result = calculator.Add(example);

        // this test will only pass if
        // "3" is written to the logger.
        // then - this is the part that is going to pass or fail.
        mockedNotifier.DidNotReceive().Notify(Arg.Any<string>());
    }
}

