namespace UILayer;

public static class InputValidation
{
    /// <summary>
    /// Method to check if user input is valid. An invalid string is null or whitespace;
    /// </summary>
    /// <returns>string</returns>
    public static string ValidString()
    {
    EnterString:
        string valid = Console.ReadLine() ?? "";

        if (String.IsNullOrWhiteSpace(valid))
        {
            Console.WriteLine("Enter a valid input: ");
            goto EnterString;
        }
        return valid;
    }
}