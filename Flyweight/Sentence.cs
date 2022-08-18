namespace Flyweight;

public class Sentence
{
    private string[] words;
    private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

    public Sentence(string plainText)
    {
        words = plainText.Split(' ');
    }

    public WordToken this[int index]
    {
        get
        {
            var wt = new WordToken();
            tokens.Add(index, wt);
            return tokens[index];
        }
    }

    public override string ToString()
    {
        var ws = new List<string>();
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            if (tokens.ContainsKey(i) && tokens[i].Capitalize)
            {
                word = word.ToUpperInvariant();
            }

            ws.Add(word);
        }

        return string.Join(" ", ws);
    }

    public class WordToken
    {
        public bool Capitalize;
    }
}
