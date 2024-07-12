Console.WriteLine("Insert a sentence: ");
string inputSentence = Console.ReadLine();

Console.WriteLine(findMostRepeatedCharacter(inputSentence));




char findMostRepeatedCharacter(string sentence)
{

    sentence = removeCharFromString(sentence, ' ');

    char mostRepeatedCharacter = ' ';
    int mostRepeatedCharacterCount = 0;
    int currentCharacterCount = 0;
    while (sentence.Length > 0)
    {

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[0] == sentence[i])
                currentCharacterCount++;

        }
        if (currentCharacterCount > mostRepeatedCharacterCount)
        {
            mostRepeatedCharacterCount = currentCharacterCount;
            mostRepeatedCharacter = sentence[0];
        }
        sentence = removeCharFromString(sentence, sentence[0]);
        currentCharacterCount = 0;



    }
    return mostRepeatedCharacter;
}


string removeCharFromString(string sentence, char c)
{
    int sentenceLength = sentence.Length;
    for (int i = 0; i < sentenceLength; i++)
    {
        if (sentence[i] == c)
        {
            sentence = sentence.Remove(i, 1);
            sentenceLength--;
            i--;
        }
    }
    return sentence;
}
