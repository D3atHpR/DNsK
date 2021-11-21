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
    NumberToken
}

class SyntaxToken
{
    public SyntaxToken(SyntaxKind kind, int position, string text)
    {
        Kind = kind;
        Position = position;
        Text = text;
    }
    public SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
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
            return new SyntaxToken(SyntaxKind.NumberToken, start, text);
        }
    }