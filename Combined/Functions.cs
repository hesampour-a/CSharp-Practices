namespace Combined;

public class Functions
{

    public static void SecondMax()
    {
        int sizeOfArray = GetNumberFromUser("Enter number of numbers :");

        int[] numbers = new int[sizeOfArray];
        int max = 0;
        int secondMax = 0;
        for (int i = 0; i < sizeOfArray; i++)
        {
            numbers[i] = GetNumberFromUser($"Enter number #{i + 1} :");
            if (i == 0)
            {
                max = numbers[i];
                secondMax = numbers[i];
            }
            else if (numbers[i] > max)
            {
                secondMax = max;
                max = numbers[i];
            }
            else if (numbers[i] > secondMax)
            {
                secondMax = numbers[i];
            }
        }
        Console.WriteLine($"The second max is :{secondMax}");

        int GetNumberFromUser(string message)
        {
            int? number = null;
            bool canParseToInt = false;
            while (!canParseToInt)
            {
                Console.WriteLine(message);
                canParseToInt = int.TryParse(Console.ReadLine(), out int result);
                if (!canParseToInt || result < 0)
                {
                    canParseToInt = false;
                    Console.WriteLine("Wrong Input");
                }
                number = result;
            }
            return number!.Value;
        }

    }


    public static void MostRepeated()
    {
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

    }

    public static void SentenceReverser()
    {
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

    }


    public static void run()
    {
        while (true)
        {
            Console.WriteLine("Enter app name : (SentenceReverce,MostRepeated,SecondMax)");
            string app = Console.ReadLine();

            switch (app)
            {
                case "SecondMax":
                    SecondMax();
                    break;
                case "MostRepeated":
                    MostRepeated();
                    break;
                case "SentenceReverce":
                    SentenceReverser();
                    break;


                default:
                    break;
            }

        }
    }





}