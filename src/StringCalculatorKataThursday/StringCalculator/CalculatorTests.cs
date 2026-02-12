

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1",1)]
    [InlineData("200",200)]
    [InlineData("3",3)]
    public void SingleInteger(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("200,30", 230)]
    [InlineData("3,3", 6)]
    public void TwoIntegers(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("200,30,5,1000", 1235)]
    [InlineData("3,3,3,3,3,7,1,3,16", 42)]
    public void ArbitraryNumberOfIntegers(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("200,30\n5", 235)]
    [InlineData("3\n3,3", 9)]
    public void MixedDelimiters(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    public void CustomDelimiters(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-1,2")]
    [InlineData("200,-30")]
    public void NegativeIntegers(string input)
    {
        var calculator = new Calculator();

        Assert.Throws<Exception>(() => calculator.Add(input));
    }

    [Theory]
    [InlineData("-1,2", "-1")]
    [InlineData("200,-30,-5", "-30,-5")]
    public void ExceptionMessages(string input, string expected)
    {
        var calculator = new Calculator();

        var actual = Assert.Throws<Exception>(() => calculator.Add(input));

        Assert.Equal(expected.ToString(), actual.Message);
    }

    [Theory]
    [InlineData("2,3,9876", 5)]
    [InlineData("2,3,9876,1754", 5)]
    public void BigNumbers(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//[***]\n1***2", 3)]
    [InlineData("//[***]\n1***2//[***]\n1***2", 6)]
    public void CustomDelimitersOfAnyLength(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//[***, #, !]\n1***2#3\n1!2", 9)]
    [InlineData("//[***, #, !]\n1***2#3\n1!2//[***, #, !]\n1***2#3\n1!2", 18)]
    public void MultipleCustomDelimiters(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }
}
