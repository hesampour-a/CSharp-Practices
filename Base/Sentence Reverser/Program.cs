Console.WriteLine("Insert a sentence: ");
string sentence = Console.ReadLine();




Console.WriteLine(ReverseSentence(sentence!));



string ReverseSentence(string sentence)
{
    string result = "";
    string[] sentenceArray = sentence.Split(' ').ToArray();
    for (int i = sentenceArray.Length - 1; 0 <= i; i--)
    {
        result = result + sentenceArray[i] + " ";
    }
    return result;
}
// the weather was hot today
