using System;
using System.Linq;
public static class Bob
{
    public static string Response(string statement)
    {
        bool isQuestion = statement.Trim().EndsWith("?");
        bool hasLetters = statement.Any(_ => char.IsLetter(_));
        bool hasAlphaNumeric = hasLetters || statement.Any(_ => char.IsNumber(_));
        bool isForceful = hasLetters && statement.Where(_ => char.IsLetter(_)).All(_ => char.IsUpper(_));
        if(false == hasAlphaNumeric && false == isQuestion) return "Fine. Be that way!";
        if(isForceful) return isQuestion ? "Calm down, I know what I'm doing!" : "Whoa, chill out!";
        return isQuestion ? "Sure." : "Whatever.";
    }
}