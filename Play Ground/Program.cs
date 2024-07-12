Console.WriteLine("Enter a sentence : ");

string sentence = Console.ReadLine();

Console.WriteLine(findMostRepeatedChatacter(sentence));

(char, int) findMostRepeatedChatacter(string sentence)
{
    //sentence = RemoveCharacterFromSentence(' ', sentence);
    int MostRepeatedCharCount = 0;
    char MostRepeatedChar = ' ';
    int CurrentRepeatedCharCount = 0;
    int sentenceLength = sentence.Length;
    while (sentenceLength > 0)
    {
        for (int i = 0; i < sentenceLength; i++)
        {
            if (sentence[0] == sentence[i])
            {
                CurrentRepeatedCharCount++;
            }
        }
        if (CurrentRepeatedCharCount > MostRepeatedCharCount)
        {
            MostRepeatedChar = sentence[0];
            MostRepeatedCharCount = CurrentRepeatedCharCount;
        }

        CurrentRepeatedCharCount = 0;
        sentence = RemoveCharacterFromSentence(sentence[0], sentence);
        sentenceLength = sentence.Length;
        //Console.WriteLine(MostRepeatedChar);
    }
    return (MostRepeatedChar, MostRepeatedCharCount);
}



string RemoveCharacterFromSentence(char c, string sentence)
{
    Console.WriteLine("in " + sentence);
    //int sentenceLength = sentence.Length;
    for (int i = 0; i < sentence.Length; i++)
    {
        if (sentence[i] == c)
        {
            sentence = sentence.Remove(i, 1);
            i--;

        }

        Console.WriteLine("out" + sentence);
    }

    return sentence;
}