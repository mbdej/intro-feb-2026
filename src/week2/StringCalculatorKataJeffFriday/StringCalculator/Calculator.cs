
// what 
// "interface segregation principle"
    // you define what you need, don't just use what's available

public interface ILogger
{
    void LogAddResults(string results);
}

public interface INotifyTheHelpDesk
{
    void Notify(string v);
}

public class Calculator(ILogger _logger, INotifyTheHelpDesk _helpDesk)
{
    public int Add(string numbers)
    {


        var result = numbers == "" ? 0 : numbers // "1,2,3,4"
            .Split(',', '\n') // ["1", "2", "3", "4"]
            .Select(int.Parse) // [1, 2, 3, 4]
            .Sum(); // 10

        // Do something here
        // this is a "non-functional" or "technical" requirement
        // side effect just means that something is happening
        // that doesn't change the observable behavior of the
        // caller of this method
        // 
        // logging is "leaving the escape room" - leaving the process
        // writing to the file system

        try
        {
            _logger.LogAddResults(result.ToString());
        }
        catch (Exception)
        {
            // the help desk is notified
            _helpDesk.Notify("Wasn't able to log: " + result.ToString());
            // gulp
        }
        return result;

    }
}



// test double
// dummy - not really part of the test, just need something so we don't get a NRE
// stub - a thing that has canned responses to questions. simulating faults
// mock - record their interactions.
// fake - we will do this in our api. it's not our code, it's a "stand in" for something
// that will be there in "production" - 