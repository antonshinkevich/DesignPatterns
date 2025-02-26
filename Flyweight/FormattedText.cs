﻿using System.Text;

namespace Flyweight;

public class FormattedText
{
    private readonly string _plainText;
    private readonly bool[] _capitalize;

    public FormattedText(string plainText)
    {
        _plainText = plainText;
        _capitalize = new bool[plainText.Length];
    }

    public void Capitalize(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            _capitalize[i] = true;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < _plainText.Length; i++)
        {
            var c = _plainText[i];
            sb.Append(_capitalize[i] ? char.ToUpper(c) : c);
        }

        return sb.ToString();
    }
}

public class BetterFormattedText
{
    private readonly string _plainText;
    private readonly List<TextRange> _formatting = new List<TextRange>();

    public BetterFormattedText(string plainText)
    {
        _plainText = plainText;
    }

    public TextRange GetRange(int start, int end)
    {
        var range = new TextRange
        {
            Start = start,
            End = end
        };
        _formatting.Add(range);
        return range;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < _plainText.Length; i++)
        {
            var c = _plainText[i];
            foreach (var range in _formatting)
            {
                if (range.Covers(i) && range.Capitalize)
                {
                    c = char.ToUpperInvariant(c);
                }
            }

            sb.Append(c);
        }

        return sb.ToString();
    }

    public class TextRange
    {
        public int Start, End;
        public bool Capitalize, Bold, Italic;

        public bool Covers(int position) => position >= Start && position <= End;
    }
}
