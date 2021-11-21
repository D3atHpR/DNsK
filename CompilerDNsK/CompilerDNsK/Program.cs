while (true)
{
    Console.Write("> ");


    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line))
        return;
    if (line == "1+2*3")
    {
        Console.WriteLine("?");
    }
    else
        Console.WriteLine("ERROR: Invalid expression!");
}


enum SyntaxKind
{
    NumberToken,
    WhitespaceToken
}

class SyntaxToken
{
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
    {
        Kind = kind;
        Position = position;
        Text = text;
        Value = value;
    }
    public SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
    public object Value { get; }
}

class lexer
{
    private readonly string _text;
    private int _position;
    public lexer(string text)
    {
        _text = text;
    }

    private char Current
    {
        get
        {
            if (_position >= _text.Length)
                return '\0';
            return _text[_position];
        }
    }

    private void Next()
    {
        _position++;
    }

    public SyntaxToken NextToken()
    {
        if (char.IsDigit(Current))
        {
            var start = _position;
            while (char.IsDigit(Current))
                Next();
            var length = _position - start;
            var text = _text.Substring(start, length);
            int.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);

        }
        if (char.IsWhiteSpace(Current))
        {
            var start = _position;
            while (char.IsWhiteSpace(Current))
                Next();
            var length = _position - start;
            var text = _text.Substring(start, length);
            int.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, value);
        }

    }
}