using System.Collections.Generic;
using System.Text;

namespace Qoden.task_2
{

    class DiagramManager
    {
        private Dictionary<string, int> counter;
        public DiagramManager(string text)
        {
            counter = getSortedWordCounter(text);
        }
        public void PrintDiagramm()
        {
            int maxCount = getMaxCount();
            int maxWordLength = getMaxWordLength();
            float singleDotValue = (float)maxCount / 10;

            foreach (var word in counter) 
            {
                var normalizedKey = getNormalizedWord(word.Key, maxWordLength);
                var dots = getDots(word.Value,singleDotValue);
                Console.WriteLine(normalizedKey + ' ' + dots);
            }
        }

        private string getDots(int value, float singleDotValue)
        {
            int count = (int)Math.Round(value / singleDotValue);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append('.');
            }
            return stringBuilder.ToString();
        }

        private string getNormalizedWord(string word, int length)
        {
            if (word.Length == length) return word;
            StringBuilder stringBuilder = new StringBuilder(word);
            while (stringBuilder.Length < length ) 
            {
                stringBuilder.Insert(0,'_');
            }
            return stringBuilder.ToString();
        }

        private int getMaxCount()
        {
            return counter.Values.Max();
        }
        private int getMaxWordLength()
        {
            return counter.MaxBy(x => x.Key.Length).Key.Length;
        }
        private Dictionary<string, int> getSortedWordCounter(string text)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            string[] words = text.Split(' ');
            foreach (var word in words)
            {
                if(counter.TryGetValue(word, out int value))
                {
                    counter[word] = value + 1;
                }
                else
                { 
                    counter[word] = 1; 
                }
            }
            //Сортировка
            counter = counter.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return counter;
        }
    }
}